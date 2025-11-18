using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using Entidades;
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
    public partial class frmConsultaRepartidor : Form
    {
        #region constructor
        public frmConsultaRepartidor()
        {
            InitializeComponent();
            CargarRepartidores(); // Llama al método para cargar los repartidores al iniciar el formulario
        }// fin constructor
        #endregion

        #region Metodos
        private void CargarRepartidores()// Método para cargar los repartidores en el DataGridView
        {
            try
            {
                RepartidorLN repartidorLN = new RepartidorLN(); // Crea una instancia de la clase RepartidorLN para acceder a los métodos de lógica de negocio
                List<Repartidor> listaRepartidores = repartidorLN.ConsultarRepartidores(); // Llama al método ConsultarRepartidores para obtener la lista de repartidores

                if (listaRepartidores == null || listaRepartidores.Count == 0) // Verifica si la lista de repartidores está vacía o es nula
                {
                    MessageBox.Show("No hay repartidores registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje informativo si no hay repartidores
                }
                // Configura el DataGridView
                dgvConsultaRepartidor.DataSource = null; // Limpia la fuente de datos del DataGridView
                dgvConsultaRepartidor.Rows.Clear(); // Limpia las filas del DataGridView
                dgvConsultaRepartidor.Columns.Clear(); // Limpia las columnas del DataGridView
                dgvConsultaRepartidor.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Columna Id
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Identificacion", // Vincula la columna al campo Id de la entidad Repartidor
                    HeaderText = "Id", // Título de la columna
                    Name = "Id" // Nombre de la columna
                });

                // Columna Nombre
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre", // Vincula la columna al campo Nombre de la entidad Repartidor
                    HeaderText = "Nombre", // Título de la columna
                    Name = "Nombre" // Nombre de la columna
                });
                // Columna Primer Apellido
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "PrimerApellido", // Vincula la columna al campo PrimerApellido de la entidad Repartidor
                    HeaderText = "Primer Apellido", // Título de la columna
                    Name = "PrimerApellido" // Nombre de la columna
                });
                // Columna Segundo Apellido
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SegundoApellido", // Vincula la columna al campo SegundoApellido de la entidad Repartidor
                    HeaderText = "Segundo Apellido", // Título de la columna
                    Name = "SegundoApellido" // Nombre de la columna
                });
                // Columna FechaNacimiento
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaNacimiento", // Vincula la columna al campo FechaNacimiento de la entidad Repartidor
                    HeaderText = "Fecha Nacimiento", // Título de la columna
                    Name = "FechaNacimiento" // Nombre de la columna
                });
                //Columna FechaIngreso
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaContratacion", // Vincula la columna al campo FechaIngreso de la entidad Repartidor
                    HeaderText = "Fecha Contratacion", // Título de la columna
                    Name = "Fecha Contratacion" // Nombre de la columna
                });
                //Columna Activo
                dgvConsultaRepartidor.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Activo",
                    HeaderText = "Activo",
                    Name = "Activo"
                });

                dgvConsultaRepartidor.DataSource = listaRepartidores; // Asigna la lista de repartidores como fuente de datos del DataGridView

                //Formatea la columna activo para mostrar "Sí" o "No"
                /// Añade un evento CellFormatting para formatear la columna Activo
                /// Se utiliza para mostrar "Sí" o "No" en lugar de true/false
                /// e.ColumnIndex verifica si la columna es la de Activo
                /// .index verifica si el valor de la celda es nulo antes de formatear
                /// e.Value verifica si el valor de la celda es verdadero o falso
                /// e.formattingApplied indica que se ha aplicado el formato
                dgvConsultaRepartidor.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == dgvConsultaRepartidor.Columns["Activo"].Index && e.Value != null)
                    {
                        e.Value = (bool)e.Value ? "Sí" : "No"; // Convierte el valor booleano a "Sí" o "No"
                        e.FormattingApplied = true; // Indica que se ha aplicado el formato
                    }
                };

                
                //Configuracion visual del DataGridView
                dgvConsultaRepartidor.ReadOnly = true; // Establece el DataGridView como de solo lectura
                dgvConsultaRepartidor.AllowUserToAddRows = false; // Desactiva la opción de agregar filas por el usuario
                dgvConsultaRepartidor.AllowUserToDeleteRows = false; // Desactiva la opción de eliminar filas por el usuario
                dgvConsultaRepartidor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el espacio disponible

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los repartidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error si ocurre una excepción
            }
        }// fin CargarRepartidores
        #endregion

        #region Eventos
        private void frmConsultaRepartidor_Load(object sender, EventArgs e)
        {
            //error al cargar el formulario, no se usa en este formulario
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //error al hacer click en la celda del DataGridView, no se usa en este formulario
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la ventana actual y regresa a la ventana anterior
        }
        #endregion
    }// fin frmConsultaRepartidor
}
