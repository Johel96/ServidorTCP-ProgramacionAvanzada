using System;
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
    public partial class frmConsultarDetallePedido : Form
    {
        public frmConsultarDetallePedido()
        {
            InitializeComponent();
            CargarDetallePedido();    // Carga todos los detalles de pedidos al iniciar el formulario
        }

        #region Eventos 
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Métodos

        // Configura el DataGridView para mostrar todos los detalles de pedidos


        // Carga todos los detalles de pedidos en el DataGridView
        private void CargarDetallePedido()
        {
            try
            {

                DetallePedidoLN detallePedidoLN = new DetallePedidoLN();
                List<DetallePedido> listaDetalles = detallePedidoLN.ConsultarDetallesPedidos(); // Obtiene la lista de detalles de pedidos

                if (listaDetalles == null || listaDetalles.Count == 0) // Verifica si la lista está vacía o es nula
                {
                    MessageBox.Show("No hay detalles de pedidos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Sale del método si no hay detalles
                }

                dgvDetallePedido.DataSource = null; // Limpia el DataGridView antes de cargar los datos
                dgvDetallePedido.Rows.Clear(); // Limpia las filas del DataGridView
                dgvDetallePedido.Columns.Clear(); // Limpia las columnas del DataGridView
                dgvDetallePedido.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Configura las columnas del DataGridView
                dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NumeroPedido",
                    HeaderText = "Número de Pedido",
                    Name = "NumeroPedido",
                    Width = 120,
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreArticulo", // Muestra el nombre del artículo
                    HeaderText = "Artículo",
                    Name = "Articulo",
                    Width = 200,
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Cantidad",
                    HeaderText = "Cantidad",
                    Name = "Cantidad",
                    Width = 100,
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Monto",
                    HeaderText = "Monto",
                    Name = "Monto",
                    Width = 100,
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                dgvDetallePedido.DataSource = listaDetalles; // Asigna la lista de detalles al DataGridView

                dgvDetallePedido.ReadOnly = true; // Hace que todo el DataGridView sea de solo lectura
                dgvDetallePedido.AllowUserToAddRows = false; // Desactiva la opción de agregar nuevas filas
                dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar filas completas
                dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el espacio disponible

            }
            catch (Exception ex) // Captura cualquier excepción que ocurra durante la carga
            {
                MessageBox.Show($"Ocurrió un error al cargar los detalles de pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}


