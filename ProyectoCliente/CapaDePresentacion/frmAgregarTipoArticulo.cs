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
    public partial class frmAgregarTipoArticulo : Form
    {
        #region constructor
        public frmAgregarTipoArticulo()
        {
            InitializeComponent();
        }
        #endregion

        #region eventos
        //evento que se ejecuta al hacer click en el boton agregar
        private void buttonAgregar_Click(object sender, EventArgs e)
        {           
            try
            {
                string valida = ValidarDatos(); // llama al metodo de validacion de datos
                if (string.IsNullOrEmpty(valida)) // verifica si la validacion no retorna un mensaje de error
                {
                    TipoArticulo tipoArticulo = new TipoArticulo(); // crea un objeto de tipo TipoArticulo
                    tipoArticulo.Id = int.Parse(textBoxID.Text); // convierte el texto del textbox a un entero
                    tipoArticulo.Nombre = textBoxNombre.Text; // asigna el nombre del tipo de articulo
                    tipoArticulo.Descripcion = textBoxDescripcion.Text; // asigna la descripcion del tipo de articulo                    
                    TipoArticuloLN tipoArticuloLN = new TipoArticuloLN(); // crea un objeto de la clase TipoArticuloLN para acceder a la logica de negocio

                    bool ingresoCorrecto = tipoArticuloLN.GuardarTipoArticulo(tipoArticulo); // llama al metodo GuardarTipoArticulo de la logica de negocio para guardar el tipo de articulo
                    
                    if (ingresoCorrecto) // verifica si el tipo de articulo se guardo correctamente
                    {
                        MessageBox.Show("Ha ingresado de manera correcta");
                        LimpiarCampos(); // llama al metodo para limpiar los campos del formulario
                    }
                }
                else
                {
                    MessageBox.Show(valida); // muestra el mensaje de error si la validacion falla
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("El ID del articulo debe ser numerico "); // captura y muestra errores de formato, como cuando el ID no es un número entero
            }
            catch (OverflowException)
            {
                MessageBox.Show("El ID del articulo es demasiado grande. Por favor, ingrese un número válido."); // captura y muestra errores de desbordamiento, como cuando el número es demasiado grande para un entero
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("El ID del articulo no puede ser negativo o cero."); // captura y muestra errores de índice fuera de rango, como cuando el ID es negativo o cero
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contacte al administrador" + ex.Message); // captura y muestra cualquier error que ocurra durante el proceso
            }
        }// fin buttonAgregar_Click
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();// Cierra el formulario actual
        }// fin buttonCerrar_Click
        #endregion

        #region metodos
        private string ValidarDatos()// metodo que valida los datos ingresados en los textbox
        {
            // metodo que valida los datos ingresados en los textbox
            if (string.IsNullOrEmpty(textBoxID.Text))
            {
                textBoxID.Focus(); // Enfoca el textbox ID si está vacío
                return "El campo ID es obligatorio.";
            }
            else if (!int.TryParse(textBoxID.Text, out _))
            {
                textBoxID.Focus(); // Enfoca el textbox ID si no es un número válido
                return "El campo ID debe ser un número entero.";
            }
            else if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                textBoxNombre.Focus(); // Enfoca el textbox Nombre si está vacío
                return "El campo Nombre es obligatorio.";
            }
            else if (string.IsNullOrEmpty(textBoxDescripcion.Text))
            {
                textBoxDescripcion.Focus(); // Enfoca el textbox Descripción si está vacío
                return "El campo Descripción es obligatorio.";
            }
           
            return string.Empty; // Si no hay errores, retorna una cadena vacía
        } // fin ValidarDatos

        // metodo que limpia los campos del formulario
        private void LimpiarCampos() 
        {
            textBoxID.Clear(); // Limpia el campo ID
            textBoxNombre.Clear(); // Limpia el campo Nombre
            textBoxDescripcion.Clear(); // Limpia el campo Descripción
            textBoxID.Focus(); // Enfoca el campo ID para facilitar la entrada de datos
        } // fin LimpiarCampos
        #endregion
    }// fin frmAgregarTipoArticulo
}
