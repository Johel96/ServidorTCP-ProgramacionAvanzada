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
    public partial class frmAgregarRepartidor : Form
    {
        #region Constructor
        public frmAgregarRepartidor()
        {
            InitializeComponent();
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            //error al hacer click en el label1, no se usa en este formulario
        }

        //Evento que se ejecuta al hacer click en el boton agregar
        private void buttonAgregar_Click(object sender, EventArgs e)
        {            
            try
            {
                string valida = ValidarDatos();//llama al metodo de validacion de datos
                if (string.IsNullOrEmpty(valida))//verifica si la validacion no retorna un mensaje de error
                {
                    Repartidor repartidor = new Repartidor();//crea un objeto de tipo repartidor
                    repartidor.Identificacion = int.Parse(textBoxID.Text);//convierte el texto del textbox a un entero
                    repartidor.Nombre = textBoxNombre.Text;//asigna el nombre del repartidor
                    repartidor.PrimerApellido = textBoxPrimerApellido.Text;//asigna el primer apellido del repartidor
                    repartidor.SegundoApellido = textBoxSegundoApellido.Text;//asigna el segundo apellido del repartidor
                    repartidor.FechaNacimiento = dateTimePickerFechaNacimiento.Value;//asigna la fecha de nacimiento del repartidor
                    repartidor.FechaContratacion = dateTimePickerFechaContratacion.Value;//asigna la fecha de contratacion del repartidor
                    repartidor.Activo = checkBoxActivo.Checked;//asigna el estado activo del repartidor como verdadero

                    RepartidorLN repartidorLN = new RepartidorLN();//crea un objeto de la clase RepartidorLN para acceder a la logica de negocio
                    bool ingresoCorrecto = repartidorLN.GuardarRepartidor(repartidor);//llama al metodo GuardarRepartidor de la logica de negocio para guardar el repartidor

                    if (ingresoCorrecto)//verifica si el repartidor se guardo correctamente
                    {
                        MessageBox.Show("Ha ingresado de manera correcta");
                        LimpiarCampos();//llama al metodo para limpiar los campos del formulario
                    }
                    else//si el repartidor no se guardo correctamente
                    {
                        MessageBox.Show("El repartidor ya existe o no se pudo agregar.");
                    }
                }
                else
                {
                    MessageBox.Show(valida);
                }
            }//fin try
            catch (FormatException)//captura el error a ver si los datos ingresados no son del tipo correcto
            {
                MessageBox.Show("Ha ocurrido un error al ingresar los datos. Por favor, verifica que los campos sean correctos.");
            }
            catch (OverflowException)//captura el error si el numero ingresado es muy grande
            {
                MessageBox.Show("El numero ingresado no es valido por ser muy grande");
            }
            catch (IndexOutOfRangeException ex)//captura el error si el arreglo de repartidores esta lleno y no se puede agregar mas
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) // captura cualquier otro error que pueda ocurrir
            {
                MessageBox.Show($"Ocurrio un error inesperado. Contacte al administrador: {ex.Message}");
            }
        }//fin agregar     

        //Evento que se ejecuta al hacer click en el boton cerrar
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Hide(); //cierra la ventana
        }//fin boton cerrar

        #region Metodos
        /// <summary>
        /// Valida los campos del formulario antes de agregar un repartidor.
        ///</summary>
        ///<returns>Retorna empty o un mensaje si no cumple las validaciones.</returns>
        private string ValidarDatos()
        {
            string valida = string.Empty;

            if (string.IsNullOrEmpty(textBoxID.Text))//verifica si el campo de ID esta vacio
            {
                textBoxID.Focus();
                return "Debe agregar un numero de identificacion";
            }
            if (!int.TryParse(textBoxID.Text, out int Identificacion))//verifica si el campo de ID es numerico
            {
                textBoxID.Focus();
                return "La identificacion solo puede ser numerica";
            }
            else if (string.IsNullOrWhiteSpace(textBoxNombre.Text))//verifica si el campo de nombre esta vacio
            {
                textBoxNombre.Focus();
                return "El nombre no puede estar vacio.\n";
            }
            else if (string.IsNullOrWhiteSpace(textBoxPrimerApellido.Text))//verifica si el campo de primer apellido esta vacio
            {
                textBoxPrimerApellido.Focus();
                return "El primer apellido no puede estar vacio.\n";
            }
            else if (string.IsNullOrWhiteSpace(textBoxSegundoApellido.Text))//verifica si el campo de segundo apellido esta vacio
            {
                textBoxSegundoApellido.Focus();
                return "El segundo apellido no puede estar vacio.\n";
            }
            else if (dateTimePickerFechaNacimiento.Value >= DateTime.Now)//verifica si la fecha de nacimiento es mayor o igual a la fecha actual
            {
                dateTimePickerFechaNacimiento.Focus();
                return "La fecha de nacimiento debe ser anterior a la fecha actual.\n";
            }
            else if (!MayorEdad(dateTimePickerFechaNacimiento.Value))//verifica si el repartidor es mayor de edad
            {
                dateTimePickerFechaNacimiento.Focus();
                return "El repartidor debe ser mayor de edad.\n";
            }
            else if (dateTimePickerFechaContratacion.Value >= DateTime.Now)//verifica si la fecha de contratacion es mayor o igual a la fecha actual
            {
                dateTimePickerFechaContratacion.Focus();
                return "La fecha de contratacion debe ser anterior a la fecha actual.\n";
            }
            return valida;
        }//fin metodo validacion

        //Metodo que limpia los campos del formulario
        private void LimpiarCampos()
        {
            textBoxID.Clear(); //limpia el campo de ID
            textBoxNombre.Clear(); //limpia el campo de nombre
            textBoxPrimerApellido.Clear(); //limpia el campo de primer apellido
            textBoxSegundoApellido.Clear(); //limpia el campo de segundo apellido
            dateTimePickerFechaNacimiento.Value = DateTime.Now; //resetea la fecha de nacimiento a la fecha actual
            dateTimePickerFechaContratacion.Value = DateTime.Now; //resetea la fecha de contratacion a la fecha actual
            checkBoxActivo.Checked = false; //limpia el checkbox de activo
        }//fin metodo limpiar campos

        private bool MayorEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year; //calcula la edad

            if (fechaNacimiento > DateTime.Now.AddYears(-edad)) //verifica si la fecha de nacimiento es mayor a la fecha actual menos la edad
            {
                edad--; //si es mayor, resta un año a la edad
            }
            return edad >= 18; //retorna true si la edad es mayor o igual a 18, false si no

        }

        #endregion

        #region errores al hacer click en los controles que no se usan en este formulario
        private void textBoxIdentificacion_TextChanged(object sender, EventArgs e)
        {
            //error al hacer click en el textbox de identificacion, no se usa en este formulario
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //error al hacer click en el numericUpDown, no se usa en este formulario
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            //error al hacer click en el textbox de ID, no se usa en este formulario
        }
        #endregion
    }
}
