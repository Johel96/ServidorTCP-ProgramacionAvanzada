using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;
using Entidades.Client;
using Newtonsoft.Json;
using ProyectoCliente;


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

namespace InterfazGrafica
{
    public class PuertoTCP
    {
        //Atributos estáticos para la conexión TCP
        private static IPAddress ipServidor;// Dirección IP del servidor
        private static TcpClient cliente;// Cliente TCP para la conexión
        private static IPEndPoint serverEndPoint;// Punto final del servidor
        private static StreamWriter clienteStreamWriter;// Escritor para enviar datos al servidor
        private static StreamReader clienteStreamReader;// Lector para recibir datos del servidor
        public static Cliente clienteActual { get; set; } // Propiedad para almacenar el cliente actual

 
        #region Metodos 
        /// <summary>
        /// Conecta al cliente tcp al servidor especificado por la dirección IP y el puerto.
        /// </summary> 
        /// <param name="pIdentificadorCliente">U=Identificador del cliente</param>
        /// <returns>True si la conexión se establece correctamente, false en caso contrario.</returns>        
        public static bool Conectar(string pIdentificadorCliente)
        {
            try
            {
                // Establece la dirección IP del servidor y el puerto
                ipServidor = IPAddress.Parse("127.0.0.1"); // Cambia a la IP del servidor real
                cliente = new TcpClient();// Crea una nueva instancia de TcpClient
                serverEndPoint = new IPEndPoint(ipServidor, 30000); // Cambia el puerto si es necesario
                cliente.Connect(serverEndPoint); // Conecta al servidor
                MessageSocket<string> mensajeConectar = new MessageSocket<string> { Metodo = "Conectar", Entidad = pIdentificadorCliente };

                clienteStreamReader = new StreamReader(cliente.GetStream()); // Inicializa el lector de flujo
                clienteStreamWriter = new StreamWriter(cliente.GetStream()); // Inicializa el escritor de flujo
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeConectar)); // Envía el mensaje de conexión al servidor
                clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente
            }
            catch (SocketException)
            {
                return false; // Retorna false si ocurre un error de conexión
            }
            return true;
        }//Fin del método Conectar


        public static List<Cliente> ConsultarCliente(string pCliente) // Envía una solicitud al servidor para obtener la lista de clientes
        {
            List<Cliente> listaClientes = new List<Cliente>(); // Inicializa una lista de clientes
            MessageSocket<string> mensajeObtenerClientes = new MessageSocket<string> { Metodo = "ConsultarCliente", Entidad = pCliente };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerClientes)); // Envía el mensaje al servidor
            clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente

            var mensaje = clienteStreamReader.ReadLine(); // Lee la línea de respuesta del servidor

            try
            {
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(mensaje); // Deserializa la respuesta en una lista de clientes
                if (listaClientes == null || listaClientes.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deserializar la lista de clientes:\n" + ex.Message, "Error");
            }

            return listaClientes; // Retorna la lista de clientes obtenida del servidor
        }//Fin del método ObtenerClientes

        // Envía una solicitud al servidor para obtener los pedidos del cliente
        public static List<Pedido> ConsultarPedido(string pPedido)
        {
            List<Pedido> listaPedidos = new List<Pedido>(); // Inicializa una lista de pedidos
            MessageSocket<string> mensajeObtenerPedidos = new MessageSocket<string> { Metodo = "ConsultarPedido", Entidad = pPedido };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerPedidos)); // Envía el mensaje al servidor
            clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente

            var mensaje = clienteStreamReader.ReadLine(); // Lee la línea de respuesta del servidor
            listaPedidos = JsonConvert.DeserializeObject<List<Pedido>>(mensaje); // Deserializa la respuesta en una lista de pedidos

            return listaPedidos; // Retorna la lista de pedidos obtenida del servidor

        }//Fin del método ObtenerPedidos

        public static void Desconectar(string pIdentificadorCliente)
        {
            MessageSocket<string> mensajeDesconectar = new MessageSocket<string> { Metodo = "Desconectar", Entidad = pIdentificadorCliente };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeDesconectar)); // Envía el mensaje de desconexión al servidor
            clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente
            cliente.Close(); // Cierra la conexión del cliente
        }//Fin del método Desconectar

        public static List<Pedido> ConsultarPedidoPorCliente(string pIdentificadorCliente)
        {
            List<Pedido> listaPedidos = new List<Pedido>(); // Inicializa una lista de pedidos
            var mensaje = new MessageSocket<string>
            {
                Metodo = "ConsultarPedidoPorCliente",
                Entidad = pIdentificadorCliente // Establece el identificador del cliente para la consulta
            };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensaje)); // Envía el mensaje al servidor
            clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente

            var respuesta = clienteStreamReader.ReadLine(); // Lee la línea de respuesta del servidor
            listaPedidos = JsonConvert.DeserializeObject<List<Pedido>>(respuesta); // Deserializa la respuesta en una lista de pedidos

            return listaPedidos; // Retorna la lista de pedidos obtenida del servidor
        }//Fin del método ConsultarPedidoPorCliente
       
        //Metodo para obtener la lista de artículos del servidor
        public static List<Articulo> ConsultarArticulo(string pArticulo)// Envía una solicitud al servidor para obtener la lista de artículos
        {
            List<Articulo> listaArticulos = new List<Articulo>(); // Inicializa una lista de artículos
            MessageSocket<string> mensajeObtenerArticulos = new MessageSocket<string> { Metodo = "ConsultarArticulo", Entidad = pArticulo };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerArticulos)); // Envía el mensaje al servidor
            clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente            

            var mensaje = clienteStreamReader.ReadLine(); // Lee la línea de respuesta del servidor
            listaArticulos = JsonConvert.DeserializeObject<List<Articulo>>(mensaje); // Deserializa la respuesta en una lista de artículos

            return listaArticulos; // Retorna la lista de artículos obtenida del servidor
        }//Fin del método ObtenerArticulos


        // Envía una solicitud al servidor para agregar un nuevo pedido
        public static bool AgregarDetallePedido(DetallePedido pDetallePedido)
        {
            try
            {
                MessageSocket<DetallePedido> mensajeObtenerDetallesPedido = new MessageSocket<DetallePedido> { Metodo = "AgregarDetallePedido", Entidad = pDetallePedido };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerDetallesPedido)); // Envía el mensaje al servidor
                clienteStreamWriter.Flush(); // Asegura que los datos se envíen inmediatamente
                return true; // Retorna true si la solicitud se envió correctamente
            }
            catch (Exception)
            {
                throw; // Lanza una excepción si ocurre un error al enviar el mensaje
            }//Fin del método ObtenerDetallesPedido
        } //Fin del método AgregarDetallePedido    

        #endregion


    }

}
