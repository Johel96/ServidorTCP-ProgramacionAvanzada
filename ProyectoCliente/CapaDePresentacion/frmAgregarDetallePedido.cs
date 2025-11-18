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
    public partial class frmAgregarDetallePedido : Form
    {
        public frmAgregarDetallePedido()
        {
            #region Constructor
            InitializeComponent();
            CargarPedidos(); // Llama al método para cargar los pedidos en el ComboBox
            CargarArticulos(); // Llama al método para cargar los artículos en el ComboBox
            #endregion
        }

        #region Eventos
        //Evento que se ejecuta al dar click en el botón Agregar
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string valida = ValidarDatos();// Llama al método de validación de datos

                if (string.IsNullOrEmpty(valida))
                {
                    Pedido pedidoSeleccionado = (Pedido)cboNumeroPedido.SelectedItem; // Obtiene el pedido seleccionado del ComboBox
                    Articulo articuloSeleccionado = (Articulo)cboArticulo.SelectedItem; // Obtiene el artículo seleccionado del ComboBox
                    DetallePedido detallePedido = new DetallePedido(); // Crea un objeto de tipo DetallePedido
                    detallePedido.NumeroPedido = pedidoSeleccionado.NumeroPedido; // Asigna el número de pedido basado en la selección del ComboBox
                    detallePedido.Articulo = articuloSeleccionado; // Asigna el artículo basado en la selección del ComboBox
                    detallePedido.Cantidad = int.Parse(txtCantidad.Text); // Convierte el texto del textbox a un entero para la cantidad

                    if (detallePedido.Cantidad > articuloSeleccionado.Stock) // Verifica si la cantidad es mayor que el stock del artículo seleccionado
                    {
                        MessageBox.Show("La cantidad excede en lo solicitado."); // Muestra un mensaje de error si la cantidad es inválida
                        return; // Sale del método si la cantidad es inválida
                    }

                    // Calcula el monto del detalle del pedido multiplicando el precio del artículo por la cantidad y agregando el valor del envio
                    detallePedido.Monto = (articuloSeleccionado.Precio * detallePedido.Cantidad) * 1.12;

                    // Reduce el stock del artículo seleccionado por la cantidad del detalle del pedido
                    articuloSeleccionado.Stock -= detallePedido.Cantidad;

                    // Si el stock llega a cero, marca el artículo como no disponible
                    if (articuloSeleccionado.Stock == 0)
                    {
                        articuloSeleccionado.Activo = false;
                    }

                    DetallePedidoLN detallePedidoLN = new DetallePedidoLN(); // Crea un objeto de la clase DetallePedidoLN para acceder a la lógica de negocio
                    bool ingresoCorrecto = detallePedidoLN.GuardarDetallePedido(detallePedido); // Llama al método GuardarDetallePedido de la lógica de negocio para guardar el detalle del pedido

                    if (ingresoCorrecto) // Verifica si el detalle del pedido se guardó correctamente
                    {                      

                        MessageBox.Show("Detalle de pedido agregado correctamente"); // Muestra un mensaje de éxito
                        LimpiarCampos(); // Llama al método para limpiar los campos del formulario
                    }
                    else
                    {
                        MessageBox.Show("El detalle del pedido ya existe."); // Muestra un mensaje si el detalle del pedido ya existe
                    }
                }
                else
                {
                    MessageBox.Show(valida); // Muestra el mensaje de error de validación
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: La cantidad debe ser un número entero válido."); // Muestra un mensaje de error si el formato de la cantidad es incorrecto
            }
            catch (OverflowException)
            {
                MessageBox.Show("Error: La cantidad es demasiado grande."); // Muestra un mensaje de error si la cantidad es demasiado grande
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Error: No se pudo acceder a los datos. Por favor, intente nuevamente."); // Muestra un mensaje de error si hay un problema al acceder a los datos
            }
            catch (Exception ex) // Captura cualquier otro error que pueda ocurrir
            {
                MessageBox.Show($"Ocurrió un error inesperado. Contacte al administrador: {ex.Message}"); // Muestra un mensaje de error genérico
            }

        }// fin buttonAgregar_Click

        // Evento que se ejecuta al dar click en el botón Cerrar
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
        #endregion

        #region Metodos
        // Método para validar los datos ingresados en el formulario
        private string ValidarDatos()
        {
            string valida = string.Empty; // Inicializa la variable de validación
            if(cboNumeroPedido.SelectedItem == null) // Verifica si no se ha seleccionado un pedido
            {
                valida += "Debe seleccionar un número de pedido.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            if(cboArticulo.SelectedItem == null) // Verifica si no se ha seleccionado un artículo
            {
                valida += "Debe seleccionar un artículo.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            if(string.IsNullOrWhiteSpace(txtCantidad.Text)) // Verifica si el campo de cantidad está vacío o contiene solo espacios en blanco
            {
                valida += "La cantidad es obligatoria.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            else if(!int.TryParse(txtCantidad.Text, out _)) // Verifica si la cantidad es un número entero válido
            {
                valida += "La cantidad debe ser un número entero válido.\n"; // Agrega un mensaje de error a la cadena de validación
            }
            else if (int.Parse(txtCantidad.Text) <= 0) // Verifica si la cantidad es menor o igual a cero
            {
                valida += "La cantidad debe ser mayor que cero.\n"; // Agrega un mensaje de error a la cadena de validación
            }

            return string.Empty; // Si todas las validaciones son correctas, retorna una cadena vacía
        }// fin ValidarDatos

        //Metodo para cargar los pedidos en el ComboBox
        private void CargarPedidos()
        {
            PedidoLN numeroPedido = new PedidoLN(); // Llama al método de lógica de negocio para obtener los pedidos
            List<Pedido> pedidos = numeroPedido.ConsultarPedidos(); // Obtiene el arreglo de pedidos

            cboNumeroPedido.Items.Clear(); // Limpia los elementos del ComboBox
            cboNumeroPedido.DataSource = null; // Limpia la fuente de datos del ComboBox
            cboNumeroPedido.DisplayMember = "NumeroPedido"; // Establece el número de pedido como el texto a mostrar en el ComboBox
            cboNumeroPedido.ValueMember = "NumeroPedido"; // Establece el número de pedido como el valor del ComboBox
            cboNumeroPedido.DataSource = pedidos; // Asigna el arreglo de pedidos como la fuente de datos del ComboBox

        }// fin CargarPedidos

        //Metodo para cargar los artículos en el ComboBox
        private void CargarArticulos()
        {
            ArticuloLN articuloLN = new ArticuloLN(); // Crea un objeto de la clase ArticuloLN para acceder a la lógica de negocio
            List <Articulo> articulos = articuloLN.ConsultarArticulos(); // Llama al método para obtener el arreglo de artículos

            cboArticulo.Items.Clear(); // Limpia los elementos del ComboBox de artículos
            cboArticulo.DataSource = null; // Limpia la fuente de datos del ComboBox
            cboArticulo.DisplayMember = "Nombre"; // Establece el nombre del artículo como el texto a mostrar en el ComboBox
            cboArticulo.ValueMember = "Id"; // Establece el código del artículo como el valor del ComboBox
            cboArticulo.DataSource = articulos; // Asigna el arreglo de artículos como la fuente de datos del ComboBox

        }// fin CargarArticulos

        //Metodo para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            cboNumeroPedido.SelectedIndex = -1; // Limpia la selección del ComboBox de pedidos
            cboArticulo.SelectedIndex = -1; // Limpia la selección del ComboBox de artículos
            txtCantidad.Clear(); // Limpia el campo de cantidad
        }// fin LimpiarCampos      
        #endregion

    }// fin frmAgregarDetallePedido
}
