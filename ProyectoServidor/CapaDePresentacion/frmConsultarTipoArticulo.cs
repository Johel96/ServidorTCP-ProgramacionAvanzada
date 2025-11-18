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
using LogicaNegocio; // Importa la lógica de negocio para acceder a los tipos de artículos

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
    public partial class frmConsultarTipoArticulo : Form
    {
        public frmConsultarTipoArticulo()
        {
            InitializeComponent();
            CargarTiposArticulo(); // Llama al método para cargar los tipos de artículo al iniciar el formulario
        }

        private void CargarTiposArticulo()
        {
            try
            {
                TipoArticuloLN tipoArticuloLN = new TipoArticuloLN();
                List<TipoArticulo> listaTipoArticulo = tipoArticuloLN.ConsultarTiposArticulo();

                if (listaTipoArticulo == null || listaTipoArticulo.Count == 0)
                {
                    MessageBox.Show("No hay tipos de artículos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Configura el DataGridView
                dgvConsultaTipoArticulo.DataSource = null;
                dgvConsultaTipoArticulo.Rows.Clear();
                dgvConsultaTipoArticulo.Columns.Clear();
                dgvConsultaTipoArticulo.AutoGenerateColumns = false;

                // Columna Id
                dgvConsultaTipoArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id",
                    HeaderText = "Id",
                    Name = "Id",
                    
                });

                // Columna Nombre
                dgvConsultaTipoArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre",
                    HeaderText = "Nombre",
                    Name = "Nombre",
                    
                });

                // Columna Descripción
                dgvConsultaTipoArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText = "Descripción",
                    Name = "Descripcion",
                    
                });

                // Asigna los datos al DataGridView
                dgvConsultaTipoArticulo.DataSource = listaTipoArticulo;

                // Configuración visual
                dgvConsultaTipoArticulo.ReadOnly = true;
                dgvConsultaTipoArticulo.AllowUserToAddRows = false;
                dgvConsultaTipoArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvConsultaTipoArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de artículo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
    }
}
