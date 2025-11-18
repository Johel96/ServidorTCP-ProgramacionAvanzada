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
    public partial class frmConsultaCliente : Form
    {
        #region Constructor
        public frmConsultaCliente()
        {
            InitializeComponent();
            CargarClientes(); // Llama al método para cargar los clientes al iniciar el formulario
        }
        #endregion
        #region metodos
        private void CargarClientes()
        {
            try
            {
                ClienteLN clienteLN = new ClienteLN(); // Crea una instancia de la clase ClienteLN para acceder a los métodos de lógica de negocio
                List<Cliente> listaClientes = clienteLN.ConsultarClientes(); // Llama al método ConsultarClientes para obtener la lista de clientes

                if (listaClientes == null || listaClientes.Count == 0) // Verifica si la lista de clientes está vacía o es nula
                {
                    MessageBox.Show("No hay clientes registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje informativo si no hay clientes
                }
                                
                // Configura el DataGridView
                dgvConsultaCliente.DataSource = null; // Limpia la fuente de datos del DataGridView
                dgvConsultaCliente.Rows.Clear(); // Limpia las filas del DataGridView
                dgvConsultaCliente.Columns.Clear(); // Limpia las columnas del DataGridView
                dgvConsultaCliente.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Configuración de la identificación
                dgvConsultaCliente.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Identificacion", // Vincula la columna al campo Identificacion de la entidad Cliente
                    HeaderText = "Identificación", // Título de la columna
                    Name = "Identificacion" // Nombre de la columna
                });

                // Configuración del nombre
                dgvConsultaCliente.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre", // Vincula la columna al campo Nombre de la entidad Cliente
                    HeaderText = "Nombre", // Título de la columna
                    Name = "Nombre" // Nombre de la columna
                });

                // Configuración del primer apellido
                dgvConsultaCliente.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "PrimerApellido", // Vincula la columna al campo PrimerApellido de la entidad Cliente
                    HeaderText = "Primer Apellido", // Título de la columna
                    Name = "PrimerApellido" // Nombre de la columna
                });

                // Configuración del segundo apellido
                dgvConsultaCliente.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SegundoApellido", // Vincula la columna al campo SegundoApellido de la entidad Cliente
                    HeaderText = "Segundo Apellido", // Título de la columna
                    Name = "SegundoApellido" // Nombre de la columna
                });

                // Configuración de la fecha de nacimiento
                dgvConsultaCliente.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaNacimiento", // Vincula la columna al campo FechaNacimiento de la entidad Cliente
                    HeaderText = "Fecha de Nacimiento", // Título de la columna
                    Name = "FechaNacimiento" // Nombre de la columna
                });

                // Configuración del estado
                dgvConsultaCliente.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Estado", // Vincula la columna al campo Estado de la entidad Cliente
                    HeaderText = "Estado", // Título de la columna
                    Name = "Estado" // Nombre de la columna
                });

                
                //asigna los datos al DataGridView
                dgvConsultaCliente.DataSource = listaClientes; // Asigna la lista de clientes como fuente de datos del DataGridView
                
                // Formatea la columna Estado para mostrar "Sí" o "No" en lugar de true/false
                dgvConsultaCliente.CellFormatting += (s, e) =>
                {
                    /// Verifica si la columna es "Estado" y el valor es un booleano
                    /// Si es así, formatea el valor para mostrar "Sí" o "No"
                    /// e.Value es el valor de la celda actual
                    /// b.Value es el valor booleano de la celda
                    /// e.FormattingApplied indica que el formato ya ha sido aplicado
                    if (dgvConsultaCliente.Columns[e.ColumnIndex].Name == "Estado"
                        && e.Value is bool b)
                    {
                        e.Value = b ? "Sí" : "No";
                        e.FormattingApplied = true;
                    }
                };


                //Configuracion visual del DataGridView
                dgvConsultaCliente.ReadOnly = true; // Establece el DataGridView como de solo lectura
                dgvConsultaCliente.AllowUserToAddRows = false; // Desactiva la opción de agregar filas por el usuario
                dgvConsultaCliente.AllowUserToDeleteRows = false; // Desactiva la opción de eliminar filas por el usuario
                dgvConsultaCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el espacio disponible
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error si ocurre una excepción

            }

                
            }// fin CargarClientes
        #endregion

        #region Eventos
        private void dgvConsultaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual y regresa al formulario anterior
        }
        #endregion
    }
}
