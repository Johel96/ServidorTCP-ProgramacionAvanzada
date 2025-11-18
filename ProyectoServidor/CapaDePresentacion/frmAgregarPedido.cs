using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

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
    public partial class frmAgregarPedido : Form
    {
        #region Constructor
        public frmAgregarPedido()
        {
            InitializeComponent();
            CargarClientes(); // Llama al método para cargar los clientes en el ComboBox
            CargarRepartidores(); // Llama al método para cargar los repartidores en el ComboBox            
        }
        #endregion

        #region eventos
        // Evento que se ejecuta al hacer click en el botón "Agregar"
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string valida = ValidarDatos(); // Llama al método de validación de datos

                if (string.IsNullOrEmpty(valida))
                {
                    Repartidor repartidorSeleccionado = (Repartidor)cboRepartidor.SelectedItem; // Obtiene el repartidor seleccionado del ComboBox
                    Cliente clienteSeleccionado = (Cliente)cboCliente.SelectedItem; // Obtiene el cliente seleccionado del ComboBox                    
                    Pedido pedido = new Pedido(); // Crea un objeto de tipo Pedido                   
                    pedido.FechaPedido = dtpFechaPedido.Value; // Asigna la fecha actual al pedido
                    pedido.Cliente = clienteSeleccionado; // Asigna el cliente basado en la selección del ComboBox
                    pedido.Repartidor = repartidorSeleccionado; // Asigna el repartidor basado en la selección del ComboBox
                    pedido.Direccion = txtDireccion.Text; // Asigna la dirección del pedido desde el textbox

                    PedidoLN pedidoLN = new PedidoLN(); // Crea un objeto de la clase PedidoLN para acceder a la lógica de negocio
                    bool ingresoCorrecto = pedidoLN.GuardarPedido(pedido); // Llama al método GuardarPedido de la lógica de negocio para guardar el pedido
                    if (ingresoCorrecto) // Verifica si el pedido se guardó correctamente
                    {
                        MessageBox.Show($"Pedido agregado correctamentecon número: {pedido.NumeroPedido}"); // Muestra un mensaje de éxito
                        LimpiarCampos(); // Llama al método para limpiar los campos del formulario                                               
                    }
                    else
                    {
                        MessageBox.Show("El pedido ya existe."); // Muestra un mensaje si el pedido ya existe
                    }
                }
                else
                {
                    MessageBox.Show(valida); // Muestra el mensaje de error de validación
                }
            }// fin try
            catch(FormatException)
                {
                    MessageBox.Show("Error: El número de pedido debe ser un número entero válido."); // Muestra un mensaje de error si el formato del número de pedido es incorrecto
                }
            catch (OverflowException)
                {
                    MessageBox.Show("Error: El número de pedido es demasiado grande."); // Muestra un mensaje de error si el número de pedido es demasiado grande
                }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Error: Debe seleccionar un repartidor y un cliente."); // Muestra un mensaje de error si no se selecciona un repartidor o cliente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error inesperado. Contacte al administrador: {ex.Message}"); // Muestra cualquier otra excepción que ocurra
            }
        }// fin buttonAgregar_Click

        // Evento que se ejecuta al hacer click en el botón "Cerrar"
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }        
        #endregion

        #region Validación de Datos
        private string ValidarDatos()
        {
            string valida = string.Empty; // Inicializa la variable de validación

            if (dtpFechaPedido.Value > DateTime.Now) // Verifica si la fecha del pedido es mayor a la fecha actual
            {
                valida += "La fecha del pedido no puede ser futura.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            else if (cboRepartidor.SelectedItem == null) // Verifica si no se ha seleccionado un repartidor
            {
                valida += "Debe seleccionar un repartidor.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            else if (cboCliente.SelectedItem == null) // Verifica si no se ha seleccionado un cliente
            {
                valida += "Debe seleccionar un cliente.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            else if (string.IsNullOrWhiteSpace(txtDireccion.Text)) // Verifica si el campo de dirección está vacío o contiene solo espacios en blanco
            {
                valida += "La dirección es obligatoria.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            return valida; // Retorna la cadena de validación, que en este caso está vacía
        } // fin ValidarDatos
        #endregion

        #region metodos
        //Metodo para cargar los repartidores
        private void CargarRepartidores()
        {
            RepartidorLN repartidorLN = new RepartidorLN(); // Crea un objeto de la clase RepartidorLN para acceder a la lógica de negocio            
            List<Repartidor> listaRepartidores = repartidorLN.ConsultarRepartidores(); // Llama al método para obtener la lista de repartidores
            
            cboRepartidor.Items.Clear(); // Limpia los elementos del ComboBox de repartidores
            cboRepartidor.DataSource = null; // Limpia la fuente de datos del ComboBox
            cboRepartidor.DisplayMember = "Nombre"; // Establece el nombre del repartidor como el texto a mostrar en el ComboBox
            cboRepartidor.ValueMember = "Identificacion"; // Establece el ID del repartidor como el valor asociado al ComboBox
            cboRepartidor.DataSource = listaRepartidores; // Asigna la lista de repartidores como fuente de datos del ComboBox

        } // fin CargarRepartidores       

        //Metodo para cargar los clientes
        private void CargarClientes()
        {
            ClienteLN clienteLN = new ClienteLN(); // Crea un objeto de la clase ClienteLN para acceder a la lógica de negocio
           List<Cliente> listaClientes = clienteLN.ConsultarClientes(); // Llama al método para obtener la lista de clientes

            cboCliente.Items.Clear(); // Limpia los elementos del ComboBox de clientes
            cboCliente.DataSource = null; // Limpia la fuente de datos del ComboBox
            cboCliente.DisplayMember = "Nombre"; // Establece el nombre del cliente como el texto a mostrar en el ComboBox
            cboCliente.ValueMember = "Identificacion"; // Establece el ID del cliente como el valor asociado al ComboBox
            cboCliente.DataSource = listaClientes; // Asigna la lista de clientes como fuente de datos del ComboBox
        } // fin CargarClientes

        //Metodo para limpiar los campos del formulario
        private void LimpiarCampos()
        {            
            dtpFechaPedido.Value = DateTime.Now; // Establece la fecha del pedido a la fecha actual
            cboRepartidor.SelectedIndex = -1; // Desmarca cualquier repartidor seleccionado en el ComboBox
            cboCliente.SelectedIndex = -1; // Desmarca cualquier cliente seleccionado en el ComboBox
            txtDireccion.Clear(); // Limpia el campo de dirección
        } // fin LimpiarCampos
        #endregion
    }
}
