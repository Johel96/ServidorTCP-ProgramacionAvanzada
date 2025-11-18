using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
    public partial class frmAgregarArticulo : Form
    {
        #region Constructor
        public frmAgregarArticulo()
        {
            InitializeComponent();
            this.Load += frmAgregarArticulo_Load; // Asocia el evento Load del formulario al método frmAgregarArticulo_Load
        }
        #endregion

        #region eventos
        // Evento que se ejecuta al hacer clic en el botón "Agregar"
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string valida = ValidarDatos(); // Llama al método de validación de datos

                if (string.IsNullOrEmpty(valida)) // Verifica si la validación no retorna un mensaje de error
                {

                    TipoArticulo tipoSeleccionado = (TipoArticulo)cboTipoArticulo.SelectedItem;// Obtiene el tipo de artículo seleccionado del ComboBox                    
                    Articulo articulo = new Articulo(); // Crea un objeto de tipo Articulo
                    articulo.ID = int.Parse(textBoxID.Text); // Convierte el texto del textbox a un entero
                    articulo.tipoArticulo = tipoSeleccionado; // Asigna el tipo de artículo basado en la selección del ComboBox                    
                    articulo.Nombre = textBoxNombre.Text; // Asigna el nombre del artículo
                    articulo.Precio = double.Parse(textBoxPrecio.Text); // Convierte el texto del textbox a un decimal
                    articulo.Stock = int.Parse(textBoxInventario.Text); // Convierte el texto del textbox a un entero
                    articulo.Activo = cboEstado.SelectedItem.ToString() == "Si"; // Asigna el estado activo del artículo basado en el CheckBox

                    //articulo.Estado = comboBoxEstado.SelectedItem.ToString() == "Activo"; // Asigna el estado del artículo basado en la selección del ComboBox
                    ArticuloLN articuloLN = new ArticuloLN(); // Crea un objeto de la clase ArticuloLN para acceder a la lógica de negocio
                    bool ingresoCorrecto = articuloLN.GuardarArticulo(articulo); // Llama al método GuardarArticulo de la lógica de negocio para guardar el artículo
                    if (ingresoCorrecto) // Verifica si el artículo se guardó correctamente
                    {
                        MessageBox.Show("Artículo agregado correctamente");
                        LimpiarCampos(); // Llama al método para limpiar los campos del formulario
                    }
                }
                else
                {
                    MessageBox.Show(valida); // Muestra el mensaje de error de validación
                }
            }            
            catch (FormatException)// Captura excepciones de formato al convertir los datos            
            {
                MessageBox.Show("Error en el formato de los datos ingresados. Por favor, verifique e intente nuevamente.");
            }
           catch(OverflowException) // Captura excepciones de desbordamiento al convertir los datos
            {
                MessageBox.Show("El número ingresado es demasiado grande. Por favor, ingrese un número válido.");
            }
            catch (IndexOutOfRangeException) // Captura excepciones de índice fuera de rango
            {
                MessageBox.Show("Error al acceder a los datos. Por favor, intente nuevamente.");
            }
            catch (Exception ex) // Captura cualquier otra excepción
            {
                MessageBox.Show($"Ocurrió un error inesperado. Contacte al administrador: {ex.Message}");
            }
        }
        // Evento que se ejecuta al hacer clic en el botón "Cerrar"
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Metodos
        private string ValidarDatos() // Método para validar los datos ingresados
        {
            string valida = string.Empty; // Inicializa una cadena vacía para almacenar mensajes de validación
            if (string.IsNullOrWhiteSpace(textBoxID.Text)) // Verifica si el ID está vacío
            {
                return "El ID del artículo es obligatorio.";
            }
            else if (!int.TryParse(textBoxID.Text, out _)) // Verifica si el ID es un número entero válido
            {
                return "El ID del artículo debe ser un número entero válido.";
            }            
            else if (string.IsNullOrWhiteSpace(textBoxNombre.Text)) // Verifica si el nombre está vacío
            {
                return "El nombre del artículo es obligatorio.";
            }
            else if (cboTipoArticulo.SelectedItem == null) // Verifica si no se ha seleccionado un tipo de artículo
            {
                return "Debe seleccionar un tipo de artículo.";
            }
            else if (string.IsNullOrWhiteSpace(textBoxPrecio.Text)) // Verifica si el precio está vacío
            {
                return "El precio del artículo es obligatorio.";
            }
            else if (!double.TryParse(textBoxPrecio.Text, out _)) // Verifica si el precio es un número decimal válido
            {
                return "El precio del artículo debe ser un número decimal válido.";
            }
            else if (string.IsNullOrWhiteSpace(textBoxInventario.Text)) // Verifica si el inventario está vacío
            {
                return "El inventario del artículo es obligatorio.";
            }
            else if (!int.TryParse(textBoxInventario.Text, out _)) // Verifica si el inventario es un número entero válido
            {
                return "El inventario del artículo debe ser un número entero válido.";
            }
            else if (cboEstado.SelectedItem == null) // Verifica si no se ha seleccionado un estado
            {
                return "Debe seleccionar el estado del artículo.";
            }
            return valida; // Retorna una cadena vacía si no hay errores de validación
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            textBoxID.Clear(); // Limpia el campo de ID
            textBoxNombre.Clear(); // Limpia el campo de nombre
            cboTipoArticulo.SelectedIndex = -1; // Desmarca la selección del ComboBox de tipo de artículo
            textBoxPrecio.Clear(); // Limpia el campo de precio
            textBoxInventario.Clear(); // Limpia el campo de inventario
            cboEstado.SelectedIndex = 0; // Desmarca la selección del ComboBox de estado
        }

        #endregion

        #region Eventos
        // Evento que se ejecuta al cargar el formulario
        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            var tipoALN = new TipoArticuloLN(); // Crea un objeto de la clase TipoArticuloLN para acceder a la lógica de negocio           
            List<TipoArticulo> tipoArticulos = tipoALN.ConsultarTiposArticulo(); // Llama al método ConsultarTiposArticulo para obtener los tipos de artículos
                       
            cboTipoArticulo.Items.Clear(); // Limpia los elementos del ComboBox
            cboTipoArticulo.DataSource = tipoArticulos; // Asigna la lista de tipos de artículos como fuente de datos del ComboBox
            cboTipoArticulo.DisplayMember = "Nombre"; // Establece el nombre de la propiedad que se mostrará en el ComboBox
            cboTipoArticulo.ValueMember = "Id"; // Establece el nombre de la propiedad que se usará como valor del ComboBox

        }
        
        #endregion
    }//fin de la clase frmAgregarArticulo
}
