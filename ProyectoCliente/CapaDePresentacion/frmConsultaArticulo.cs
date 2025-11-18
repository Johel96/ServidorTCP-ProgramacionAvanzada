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
    public partial class frmConsultaArticulo : Form
    {
        #region Constructor
        public frmConsultaArticulo()
        {
            InitializeComponent();
            CargarArticulos(); // Llama al método para cargar los artículos al iniciar el formulario
        }
        #endregion

        #region Metodos
        private void CargarArticulos()
        {
            try
            {
                ArticuloLN articuloLN = new ArticuloLN();
                List<Articulo> listaArticulos = articuloLN.ConsultarArticulos(); // Llama al método de lógica de negocio para obtener la lista de artículos

                if (listaArticulos == null || listaArticulos.Count == 0)
                {
                    MessageBox.Show("No hay artículos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Si no hay artículos, muestra un mensaje y sale del método
                }

                // Configura el DataGridView para mostrar los artículos
                dgvConsultaArticulo.DataSource = null; // Limpia el DataGridView antes de cargar nuevos datos
                dgvConsultaArticulo.Rows.Clear(); // Limpia las filas del DataGridView
                dgvConsultaArticulo.Columns.Clear(); // Limpia las columnas del DataGridView
                dgvConsultaArticulo.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Columna ID
                dgvConsultaArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ID",
                    HeaderText = "Id",
                    Name = "Id"
                });
                // Columna Nombre
                dgvConsultaArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre",
                    HeaderText = "Nombre",
                    Name = "Nombre"
                });
                // Columna Tipo de Artículo
                dgvConsultaArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreTipoArticulo",
                    HeaderText = "Tipo de Artículo",
                    Name = "TipoArticulo"
                });
                // Columna Precio
                dgvConsultaArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Precio",
                    HeaderText = "Valor",
                    Name = "Valor"
                });
                // Columna Stock
                dgvConsultaArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Stock",
                    HeaderText = "Inventario",
                    Name = "Inventario"
                });
                // Columna Activo
                dgvConsultaArticulo.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Activo",
                    HeaderText = "Activo",
                    Name = "Activo"
                });

                dgvConsultaArticulo.DataSource = listaArticulos; // Asigna la lista de artículos al DataGridView

                
                //configuracion visual del DataGridView
                dgvConsultaArticulo.ReadOnly = true; // Hace que el DataGridView sea de solo lectura
                dgvConsultaArticulo.AllowUserToAddRows = false; // Desactiva la opción de agregar filas por el usuario
                dgvConsultaArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar filas completas
                dgvConsultaArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el espacio disponible

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artículos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //fin metodo CargarArticulos 
        #endregion

        #region eventos
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
        #endregion
    }//fin clase frmConsultaArticulo
}
