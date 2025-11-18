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
    public partial class frmAgregarCliente : Form
    {
        #region Contructor
        public frmAgregarCliente()
        {
            InitializeComponent();
        }
        #endregion

        #region eventos
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            //evento que se ejecuta al hacer click en el boton agregar
            try
            {
                string valida = ValidarDatos(); // llama al metodo de validacion de datos
                if (string.IsNullOrEmpty(valida)) // verifica si la validacion no retorna un mensaje de error
                {
                    Cliente cliente = new Cliente(); // crea un objeto de tipo cliente
                    cliente.Identificacion = int.Parse(textBoxID.Text); // convierte el texto del textbox a un entero
                    cliente.Nombre = textBoxNombre.Text; // asigna el nombre del cliente
                    cliente.PrimerApellido = textBoxPrimerApellido.Text; // asigna el primer apellido del cliente
                    cliente.SegundoApellido = textBoxSegundoApellido.Text; // asigna el segundo apellido del cliente
                    cliente.FechaNacimiento = dateTimePickerFechaNacimiento.Value; // asigna la fecha de nacimiento del cliente
                    cliente.Estado = cboEstado.SelectedItem.ToString() == "Si"; // asigna el estado del cliente basado en la selección del ComboBox
                    //revisar el estado antes de entregar el proyecto
                                        
                    ClienteLN clienteLN = new ClienteLN(); // crea un objeto de la clase ClienteLN para acceder a la logica de negocio
                    bool ingresoCorrecto = clienteLN.GuardarCliente(cliente); // llama al metodo GuardarCliente de la logica de negocio para guardar el cliente

                    if (ingresoCorrecto) // verifica si el cliente se guardo correctamente
                    {
                        MessageBox.Show("Ha ingresado de manera correcta");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("El cliente ya existe."); // muestra un mensaje si el cliente ya existe
                    }
                }
                else
                {
                    MessageBox.Show(valida); // muestra el mensaje de error si la validacion falla
                }
            }// fin try
            catch (FormatException)// captura el error a ver si los datos ingresados no son del tipo correcto
            {
                MessageBox.Show("La identificacion debe ser numerica. Por favor, verifique e intente nuevamente.");
            }
            catch (OverflowException)// captura el error si el numero ingresado es muy grande
            {
                MessageBox.Show("El número ingresado es demasiado grande. Por favor, ingrese un número válido.");
            }
            catch (IndexOutOfRangeException)// captura el error si se intenta acceder a un índice fuera del rango del arreglo
            {
                MessageBox.Show("Error al acceder a los datos. Por favor, intente nuevamente.");
            }
            catch (Exception ex) // captura cualquier otro error que pueda ocurrir
            {
                MessageBox.Show($"Ocurrio un error inesperado. Contacte al administrador: {ex.Message}");
            }
        }// fin buttonAgregar_Click
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la ventana actual
        }// fin buttonCerrar_Click
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //se agrego por error, no se usa en el proyecto
        }// fin cboEstado_SelectedIndexChanged
        #endregion

        #region Metodos
        private string ValidarDatos()
        {
            string valida = string.Empty;

            //Metodo que valida los datos ingresados por el usuario
            if (string.IsNullOrEmpty(textBoxID.Text))
            {
                textBoxID.Focus(); // Enfoca el campo ID si está vacío
                return "El campo ID es obligatorio.";
            }
            else if (!int.TryParse(textBoxID.Text, out _)) // Verifica si el ID es un número entero válido
            {
                textBoxID.Focus(); // Enfoca el campo ID si no es un número válido
                return "El campo ID debe ser un número entero.";
            }
            else if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                textBoxNombre.Focus(); // Enfoca el campo Nombre si está vacío
                return "El campo Nombre es obligatorio.";
            }
            else if (string.IsNullOrEmpty(textBoxPrimerApellido.Text))
            {
                textBoxPrimerApellido.Focus(); // Enfoca el campo Primer Apellido si está vacío
                return "El campo Primer Apellido es obligatorio.";
            }
            else if (string.IsNullOrEmpty(textBoxSegundoApellido.Text))
            {
                textBoxSegundoApellido.Focus();// Enfoca el campo Segundo Apellido si está vacío
                return "El campo Segundo Apellido es obligatorio.";
            }
            else if (dateTimePickerFechaNacimiento.Value >= DateTime.Now)
            {
                dateTimePickerFechaNacimiento.Focus(); // Enfoca el campo Fecha de Nacimiento si es inválido
                return "La fecha de nacimiento debe ser anterior a la fecha actual.";
            }
            else if (cboEstado.SelectedItem == null)
            {
                cboEstado.Focus(); // Enfoca el campo Estado si no se ha seleccionado un valor
                return "Debe poner el estado del cliente.";
            }
            return valida; // Si no hay errores, retorna una cadena vacía
        }
        //Metodo que limpia los campos del formulario
        private void LimpiarCampos()
        {
            //Limpia todos los campos
            textBoxID.Clear();
            textBoxNombre.Clear();
            textBoxPrimerApellido.Clear();
            textBoxSegundoApellido.Clear();
            dateTimePickerFechaNacimiento.Value = DateTime.Now; // Resetea la fecha de nacimiento al valor actual
            cboEstado.SelectedIndex = -1; // Resetea el ComboBox de estado a ningún valor seleccionado
        }
        #endregion
    }// fin frmAgregarCliente
}
