using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using Entidades;
using AccesoDatos;

#region Descripción
/**
 * UNED 2do Cuatrimestre 2025
 * Proyecto 1: Programa de Entregas
 * Estudiante: Johel Smaiker Granados Elizondo
 * Fecha: 15/06/2025
 * Referencias:
 * 00830 I Sesión Virtual Programación Avanzada- II Cuatrimestre 2025- Tutor Johan Acosta I https://www.youtube.com/watch?v=2IWiBqwDgKM&t=5835s
 * 00830 PROGRAMACION AVANZADA- SEGUNDA Sesión Virtual- II CUATRIMESTRE-TUTOR JOHAN ACOSTA IBAÑEZ https://www.youtube.com/watch?v=pk7YVwlEInM
 * (Deitel, 2007) Deitel, H. M.  (2007). Cómo programar en C#,  2nd Edition. [[VitalSource Bookshelf version]].  Retrieved from vbk://9789702610564
 */
#endregion

namespace CapaDePresentacion
{
    public partial class frmServidor : Form
    {
        TcpListener tcpListener; // Declara un TcpListener para escuchar conexiones entrantes
        Thread subprocesoEscuchaClientes; // Declara un subproceso para escuchar clientes
        EscribirEnTextBoxDelegado modificarTextotxtBitacora; // Declara un delegado para modificar el TextBox de bitácora
        ModificarListBoxDelegado modificarListBoxClientes; // Declara un delegado para modificar el ListBox de clientes conectados

        
        ArticuloAD accesoDatosArticulo; // Declara un objeto para acceder a los datos de artículos
        ClienteAD accesoDatosClientes; // Declara un objeto para acceder a los datos de clientes
        PedidoAD accesoDatosPedido; // Declara un objeto para acceder a los datos de pedidos
        DetallePedidoAD accesoDatosDetalle; // Declara un objeto para acceder a los datos de entregas       

        bool servidorIniciado; // Variable para controlar si el servidor ha sido iniciado

        #region Constructor

        public frmServidor()
        {
            InitializeComponent();            
            accesoDatosClientes = new ClienteAD(); // Inicializa el objeto de acceso a datos de clientes
            accesoDatosDetalle = new DetallePedidoAD(); // Inicializa el objeto de acceso a datos
            accesoDatosPedido = new PedidoAD(); //Inicializa el objeto de acceso a datos de pedidos
            accesoDatosArticulo = new ArticuloAD(); // Inicializa el objeto de acceso a datos de artículos
           
            modificarTextotxtBitacora = new EscribirEnTextBoxDelegado(EscribirEnTextbox); // Inicializa el delegado para modificar el TextBox de bitácora
            modificarListBoxClientes = new ModificarListBoxDelegado(ModificarListBox); // Inicializa el delegado para modificar el ListBox de clientes conectados
            lblEstado.ForeColor = Color.Red; // Establece el color del texto del label de estado del servidor a rojo
            btnDetener.Enabled = false; // Deshabilita el botón de detener servidor al iniciar el formulario           
        }
        #endregion

        //Delegado necesario para modificar controles de la interfaz gráfica desde un subproceso diferente al principal
        private delegate void EscribirEnTextBoxDelegado(string texto);
        private delegate void ModificarListBoxDelegado(string texto, bool agregar);

        #region Metodos

        //Metodo utilizado por el delegado para escribir en el TextBox de bitácora
        private void EscribirEnTextbox(string texto)
        {
            txtBitacora.AppendText(DateTime.Now.ToString() + " - " + texto);// Escribe el texto en el TextBox de bitácora con la fecha y hora actual
            txtBitacora.AppendText(Environment.NewLine); // Añade un salto de línea al final del texto
        }

        // Método utilizado por el delegado para modificar la interfaz gráfica desde un subproceso diferente al principal
        private void ModificarListBox(string texto, bool agregar)
        {
            if (agregar) // Si el parámetro agregar es verdadero, agrega el texto al ListBox
            {
                listClientes.Items.Add(texto); // Agrega el texto al ListBox de clientes conectados
            }
            else // Si el parámetro agregar es falso, elimina el texto del ListBox
            {
                listClientes.Items.Remove(texto); // Elimina el texto del ListBox de clientes conectados
            }
        }

        // Método para escuchar clientes que se conecta al servidor
        private void EscucharClientes()
        {
            tcpListener.Start(); // Inicia el TcpListener para escuchar conexiones entrantes                       
            try
            {
                while (servidorIniciado) // Mientras el servidor esté iniciado
                {
                    //Se bloquea el hilo hasta que un cliente se conecte
                    TcpClient cliente = tcpListener.AcceptTcpClient(); // Acepta una conexión entrante de un cliente
                    //Se crea un nuevo subproceso para manejar al cliente conectado
                    Thread subprocesoCliente = new Thread(new ParameterizedThreadStart(ComunicacionCliente)); // Crea un nuevo subproceso para manejar al cliente conectado
                    subprocesoCliente.Start(cliente); // Inicia el subproceso para manejar al cliente conectado
                }
            }
            catch (SocketException)
            {
                return; // Si ocurre una excepción, simplemente retorna y no hace nada
            }
            catch (Exception)
            {
                return; // Si ocurre cualquier otra excepción, simplemente retorna y no hace nada   
            }
        } // Fin del método EscucharClientes

        private void ComunicacionCliente(object cliente)
        {
            TcpClient tcpCliente = (TcpClient)cliente; // Convierte el objeto cliente a TcpClient
            StreamReader reader = new StreamReader(tcpCliente.GetStream()); // Crea un StreamReader para leer datos del cliente
            StreamWriter writer = new StreamWriter(tcpCliente.GetStream()); // Crea un StreamWriter para enviar datos al cliente

            while (servidorIniciado)
            {
                try
                {
                    var mensaje = reader.ReadLine(); // Lee un mensaje del cliente
                    MessageSocket<object> mensajeRecibido = JsonConvert.DeserializeObject<MessageSocket<object>>(mensaje); // Deserializa el mensaje recibido
                    SeleccionarMetodo(mensajeRecibido.Metodo, mensaje, ref writer); // Llama al método para seleccionar la acción a realizar según el mensaje recibido
                }
                catch (Exception e)
                {
                    break; // Si ocurre una excepción, sale del bucle y finaliza la comunicación con el cliente
                }
            }
            tcpCliente.Close(); // Cierra la conexión con el cliente
        } // Fin del método ComunicacionCliente

        /// <summary>
        /// Metodo donde se procesa el mensaje recibido del cliente y se selecciona el método a ejecutar
        /// </summary>
        /// <param name="pMetodo">Nombre del metodo que se debe invocar</param> 
        /// <param name="pMensaje">Mensaje enviado por el cliente</param>
        public void SeleccionarMetodo(string pMetodo, string pMensaje, ref StreamWriter pWriter)
        {
            switch (pMetodo)
            {
                case "Conectar":
                    MessageSocket<string> mensajeConectar = JsonConvert.DeserializeObject<MessageSocket<string>>(pMensaje); // Deserializa el mensaje de conexión
                    Conectar(mensajeConectar.Entidad);// Llama al método Conectar con el nombre de usuario del cliente
                    break; // Fin del caso "Conectar"
                case "ConsultarCliente":                    
                    ConsultarClientes(ref pWriter); // Llama al método ConsultarClientes para obtener la lista de clientes conectados
                    break; // Fin del caso "ConsultarCliente"
                case "ConsultarPedido":                    
                    ConsultarPedidos(ref pWriter); // Llama al método ConsultarPedidos para obtener la lista de pedidos
                    break; // Fin del caso "ConsultarPedido"
                case "ConsultarPedidoPorCliente":
                    MessageSocket<string> mensajePedidosPorCliente = JsonConvert.DeserializeObject<MessageSocket<string>>(pMensaje);
                    ConsultarPedidosPorCliente(mensajePedidosPorCliente.Entidad, ref pWriter);
                    break;               
                case "Desconectar":
                    MessageSocket<string> mensajeDesconectar = JsonConvert.DeserializeObject<MessageSocket<string>>(pMensaje); // Deserializa el mensaje de desconexión
                    Desconectar(mensajeDesconectar.Entidad); // Llama al método Desconectar con el nombre de usuario del cliente
                    break; // Fin del caso "Desconectar"

                case "RealizarPedido":
                    MessageSocket<DetallePedido> mensajeDetallePedidoPorCliente = JsonConvert.DeserializeObject<MessageSocket<DetallePedido>>(pMensaje);
                    RealizarPedidoPorCliente(mensajeDetallePedidoPorCliente.Entidad, ref pWriter);
                    break;                
                case "ConsultarArticulo":
                    MessageSocket<Articulo> mensajeConsultarArticulo = JsonConvert.DeserializeObject<MessageSocket<Articulo>>(pMensaje); // Deserializa el mensaje de consulta de artículo
                    ConsultarArticulos(ref pWriter); // Llama al método ConsultarArticulos para obtener la lista de artículos
                    break; // Fin del caso "ConsultarArticulo"            
                case "AgregarDetallePedido":
                    MessageSocket<DetallePedido> mensajeAgregarDetallePedido = JsonConvert.DeserializeObject<MessageSocket<DetallePedido>>(pMensaje); // Deserializa el mensaje de agregar detalle de pedido
                    GuardarDetallePedido(mensajeAgregarDetallePedido.Entidad, ref pWriter); // Llama al método GuardarDetallePedido para agregar el detalle del pedido
                    break; // Fin del caso "AgregarDetallePedido"                
                default:
                break; // Si el método no coincide con ninguno de los casos, simplemente sale del switch
            }
        } // Fin del método SeleccionarMetodo
                      

        //Metodo para conectar clientes al servidor y actualizar la interfaz gráfica
        private void Conectar(string pIdentificacionCliente)
        {
            txtBitacora.Invoke(modificarTextotxtBitacora, new object[] {pIdentificacionCliente + " se ha conectado..." }); // Escribe en el TextBox de bitácora que un cliente se ha conectado
            listClientes.Invoke(modificarListBoxClientes, new object[] { pIdentificacionCliente, true }); // Agrega el cliente al ListBox de clientes conectados
        } // Fin del método Conectar        

        private void Desconectar(string pIdentificacionCliente)
        {
            txtBitacora.Invoke(modificarTextotxtBitacora, new object[] { pIdentificacionCliente + " se ha desconectado..." }); // Escribe en el TextBox de bitácora que un cliente se ha desconectado
            listClientes.Invoke(modificarListBoxClientes, new object[] { pIdentificacionCliente, false }); // Elimina el cliente del ListBox de clientes conectados
        } // Fin del método Desconectar     

        // Método para consultar los clientes conectados y enviar la lista al cliente que lo solicitó
        private void ConsultarClientes(ref StreamWriter serverStreamWriter)
        {
            List<Cliente> listaClientes = new List<Cliente>(); // Crea una lista para almacenar los clientes conectados

            listaClientes = accesoDatosClientes.ConsultarClientes(); // Llama al método ObtenerClientesConectados para obtener la lista de clientes conectados

            serverStreamWriter.WriteLine(JsonConvert.SerializeObject(listaClientes)); // Envía la lista de clientes conectados al cliente que lo solicitó
            serverStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente al cliente
        } // Fin del método ObtenerClientesConectados

        private void ConsultarPedidos(ref StreamWriter serverStreamWriter)
        {
            List<Pedido> listaPedidos = new List<Pedido>(); // Crea una lista para almacenar los pedidos

            listaPedidos = accesoDatosPedido.ConsultarPedidos(); // Llama al método ConsultarPedidos para obtener la lista de pedidos

            serverStreamWriter.WriteLine(JsonConvert.SerializeObject(listaPedidos)); // Envía la lista de pedidos al cliente que lo solicitó
            serverStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente al cliente
        } // Fin del método ConsultarPedidos

        private void ConsultarPedidosPorCliente(string idCliente, ref StreamWriter serverStreamWriter)
        {
            int id = Convert.ToInt32(idCliente);

            List<Pedido> listaPedidos = new List<Pedido>();                        
            listaPedidos = accesoDatosPedido.ConsultarPedidosPorCliente(id);

            serverStreamWriter.WriteLine(JsonConvert.SerializeObject(listaPedidos));
            serverStreamWriter.Flush();
        }
        
        private void RealizarPedidoPorCliente(DetallePedido detalle, ref StreamWriter serverStreamWriter)
        {
            try
            {
                bool pedidoExitoso = accesoDatosDetalle.GuardarDetallePedidoPorCliente(detalle); // Usa el método que implementamos

                if (pedidoExitoso)
                {
                    serverStreamWriter.WriteLine(JsonConvert.SerializeObject("Pedido realizado correctamente."));
                }
                else
                {
                    serverStreamWriter.WriteLine(JsonConvert.SerializeObject("No se pudo realizar el pedido."));
                }
            }
            catch (Exception ex)
            {
                serverStreamWriter.WriteLine(JsonConvert.SerializeObject("Error al realizar el pedido: " + ex.Message));
            }

            serverStreamWriter.Flush(); // Asegura que el mensaje se envíe
        }

        
        private void ConsultarArticulos(ref StreamWriter serverStreamWriter)
        {
            List<Articulo> listaArticulos = new List<Articulo>(); // Crea una lista para almacenar los artículos
            listaArticulos = accesoDatosArticulo.ConsultarArticulos(); // Llama al método ConsultarArticulos para obtener la lista de artículos
            serverStreamWriter.WriteLine(JsonConvert.SerializeObject(listaArticulos)); // Envía la lista de artículos al cliente que lo solicitó
            serverStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente al cliente
        } // Fin del método ConsultarArticulos
             

        // Método para guardar un detalle de pedido y enviar un mensaje de éxito o error al cliente que lo solicitó
        private void GuardarDetallePedido(DetallePedido pPedido, ref StreamWriter serverStreamWriter)
        {
            bool detalleGuardado = accesoDatosDetalle.GuardarDetallePedido(pPedido); // Llama al método GuardarDetallePedido para guardar el detalle del pedido
            if (detalleGuardado) // Si el detalle fue guardado correctamente
            {
                serverStreamWriter.WriteLine(JsonConvert.SerializeObject("Detalle de pedido guardado correctamente.")); // Envía un mensaje de éxito al cliente
            }
            else // Si ocurrió un error al guardar el detalle del pedido
            {
                serverStreamWriter.WriteLine(JsonConvert.SerializeObject("Error al guardar el detalle del pedido.")); // Envía un mensaje de error al cliente
            }
            serverStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente al cliente
        } // Fin del método GuardarDetallePedido     
                
        #endregion //Fin de los metodos
       
        #region Eventos servidor
        //Evento que se ejecuta al hacer clic en el botón "Iniciar Servidor"
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IPAddress local = IPAddress.Parse("127.0.0.1"); // Establece la dirección IP local para el servidor
            tcpListener = new TcpListener(local, 30000); // Crea un TcpListener en el puerto 5000
            servidorIniciado = true; // Marca que el servidor ha sido iniciado

            subprocesoEscuchaClientes = new Thread(new ThreadStart(EscucharClientes)); // Crea un nuevo subproceso para escuchar clientes
            subprocesoEscuchaClientes.Start(); // Inicia el subproceso para escuchar clientes
            subprocesoEscuchaClientes.IsBackground = true; // Establece el subproceso como de fondo para que se cierre al cerrar la aplicación
            lblEstado.Text = "Escuchando clientes ... en (127.0.0.1, 30000)"; // Actualiza el label de estado del servidor
            lblEstado.ForeColor = Color.Green; // Cambia el color del texto del label de estado del servidor a verde
            btnIniciar.Enabled = false; // Deshabilita el botón de iniciar servidor para evitar múltiples clics
            btnDetener.Enabled = true; // Deshabilita el botón de detener servidor al iniciar el servidor

            txtBitacora.Text = "Servidor iniciado correctamente.\r\n"; // Limpia el TextBox de bitácora y muestra un mensaje de inicio exitoso
            txtBitacora.AppendText(Environment.NewLine); // Añade un salto de línea al final del texto
        }// Fin del evento btnIniciar_Click

        private void btnDetener_Click(object sender, EventArgs e)
        {
            servidorIniciado = false; // Marca que el servidor ha sido detenido
            tcpListener.Stop(); // Detiene el TcpListener para que no acepte más conexiones

            lblEstado.ForeColor = Color.Red; // Cambia el color del texto del label de estado del servidor a rojo
            lblEstado.Text = "Sin iniciar"; // Actualiza el label de estado del servidor
            btnIniciar.Enabled = true; // Habilita el botón de iniciar servidor para permitir reiniciar el servidor
            btnDetener.Enabled = false; // Deshabilita el botón de detener servidor ya que el servidor ha sido detenido
        }// Fin del evento btnDetener_Click
        #endregion // Fin de los eventos

        #region Evento de los botones del administrador
        // Evento que se ejecuta al hacer clic en el botón "Agregar Repartidor"
        private void buttonAddRepartidor_Click(object sender, EventArgs e)
        {
            frmAgregarRepartidor frmAgregarRepartidor = new frmAgregarRepartidor();
            frmAgregarRepartidor.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Consultar Repartidor"
        private void buttonConsultarRepartidor_Click(object sender, EventArgs e)
        {
            frmConsultaRepartidor frmConsultaRepartidor = new frmConsultaRepartidor();
            frmConsultaRepartidor.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Agregar Cliente"
        private void buttonAgregarCliente_Click(object sender, EventArgs e)
        {
            frmAgregarCliente frmAgregarCliente = new frmAgregarCliente();
            frmAgregarCliente.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Consultar Cliente"
        private void buttonConsultarCliente_Click(object sender, EventArgs e)
        {
            frmConsultaCliente frmConsultaCliente = new frmConsultaCliente();
            frmConsultaCliente.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Agregar Tipo Artículo"
        private void buttonAgregarTipoArticulo_Click(object sender, EventArgs e)
        {
            frmAgregarTipoArticulo frmAgregarTipoArticulo = new frmAgregarTipoArticulo();
            frmAgregarTipoArticulo.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Consultar Tipo Artículo"
        private void buttonConsultarTipoArticulo_Click(object sender, EventArgs e)
        {
            frmConsultarTipoArticulo frmConsultarTipoArticulo = new frmConsultarTipoArticulo();
            frmConsultarTipoArticulo.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Agregar Artículo"
        private void buttonAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo frmAgregarArticulo = new frmAgregarArticulo();
            frmAgregarArticulo.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Consultar Artículo"
        private void buttonConsultaArticulo_Click(object sender, EventArgs e)
        {
            frmConsultaArticulo frmConsultaArticulo = new frmConsultaArticulo();
            frmConsultaArticulo.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Agregar Pedido"
        private void buttonAgregarPedidos_Click(object sender, EventArgs e)
        {
            frmAgregarPedido frmAgregarPedido = new frmAgregarPedido();
            frmAgregarPedido.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Consultar Pedidos"
        private void buttonConsultaPedidos_Click(object sender, EventArgs e)
        {
            frmConsultarPedido frmConsultarPedido = new frmConsultarPedido();
            frmConsultarPedido.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Consultar Detalle Pedido"
        private void button1_Click(object sender, EventArgs e)
        {
            frmConsultarDetallePedido frmConsultarDetallePedido = new frmConsultarDetallePedido();
            frmConsultarDetallePedido.ShowDialog();
        }
        // Evento que se ejecuta al hacer clic en el botón "Agregar Detalle Pedido"
        private void buttonAgregarDetallePedido_Click(object sender, EventArgs e)
        {
            frmAgregarDetallePedido frmAgregarDetallePedido = new frmAgregarDetallePedido();
            frmAgregarDetallePedido.ShowDialog();
        }
        #endregion


    }// Fin de la clase frmPrincipal
}
 // Fin de eventos