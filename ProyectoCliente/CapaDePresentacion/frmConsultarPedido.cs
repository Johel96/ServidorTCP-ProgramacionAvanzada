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
    public partial class frmConsultarPedido : Form
    {
        public frmConsultarPedido()
        {
            InitializeComponent();
            CargarPedidos(); // Llama al método para cargar los pedidos al iniciar el formulario
            dgvConsultaPedido.SelectionChanged += dgvConsultaPedido_SelectionChanged;

        }


        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();// Cierra el formulario actual
        }

        #region Metodos 
        private void CargarPedidos()// Método para cargar los pedidos en el DataGridView
        {
            try
            {               
                PedidoLN pedidoLN = new PedidoLN();
                List<Pedido> listaPedidos = pedidoLN.ConsultarPedidos(); // Llama al método de lógica de negocio para obtener la lista de pedidos

                if (listaPedidos == null || listaPedidos.Count == 0) // Verifica si la lista de pedidos está vacía o es nula
                {
                    MessageBox.Show("No hay pedidos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Si no hay pedidos, muestra un mensaje y sale del método
                }

                dgvConsultaPedido.DataSource = null; // Limpia el DataGridView antes de cargar los datos
                dgvConsultaPedido.Rows.Clear(); // Limpia las filas del DataGridView
                dgvConsultaPedido.Columns.Clear(); // Limpia las columnas del DataGridView
                dgvConsultaPedido.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                //Columna ID
                dgvConsultaPedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NumeroPedido", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Número de Pedido", // Título de la columna
                    Name = "NumeroPedido", // Nombre interno de la columna
                    Width = 100, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                //Columna Fecha de Pedido
                dgvConsultaPedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaPedido", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Fecha de Pedido", // Título de la columna
                    Name = "FechaPedido", // Nombre interno de la columna
                    Width = 150, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                //Columna Cliente
                dgvConsultaPedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreCliente", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Cliente", // Título de la columna
                    Name = "Cliente", // Nombre interno de la columna
                    Width = 200, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                //Columna Repartidor
                dgvConsultaPedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreRepartidor", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Repartidor", // Título de la columna
                    Name = "Repartidor", // Nombre interno de la columna
                    Width = 200, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });
                //Columna Dirección
                dgvConsultaPedido.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Direccion", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Dirección", // Título de la columna
                    Name = "Direccion", // Nombre interno de la columna
                    Width = 250, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                dgvConsultaPedido.DataSource = listaPedidos; // Asigna la lista de pedidos como fuente de datos del DataGridView

                dgvConsultaPedido.ReadOnly = true; // Hace que el DataGridView sea de solo lectura
                dgvConsultaPedido.AllowUserToAddRows = false; // Desactiva la opción de agregar filas por el usuario
                dgvConsultaPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar filas completas
                dgvConsultaPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el espacio disponible
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }// fin CargarPedidos

        private void dgvConsultaPedido_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConsultaPedido.SelectedRows.Count == 0)
                return;

            int numeroPedido = Convert.ToInt32(dgvConsultaPedido.SelectedRows[0].Cells["NumeroPedido"].Value);

            try
            {
                DetallePedidoLN detalleLN = new DetallePedidoLN();
                List<DetallePedido> detalles = detalleLN.ConsultarDetallesPedidos()
                    .Where(d => d.NumeroPedido == numeroPedido).ToList();

                CargarDetalleGrid(detalles);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles del pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDetalleGrid(List<DetallePedido> detalles)
        {
            dgvDetallePedido.DataSource = null;
            dgvDetallePedido.Rows.Clear();
            dgvDetallePedido.Columns.Clear();
            dgvDetallePedido.AutoGenerateColumns = false;

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ArticuloID",
                HeaderText = "ID Artículo",
                Name = "IDArticulo",
                Width = 100,
                ReadOnly = true
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreArticulo",
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 150,
                ReadOnly = true
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TipoArticulo",
                HeaderText = "Tipo Artículo",
                Name = "TipoArticulo",
                Width = 150,
                ReadOnly = true
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "Cantidad",
                Width = 80,
                ReadOnly = true
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Monto",
                HeaderText = "Monto",
                Name = "Monto",
                Width = 100,
                ReadOnly = true
            });

            // Convertir lista con propiedades esperadas
            var detallesFormateados = detalles.Select(d => new
            {
                ArticuloID = d.Articulo.ID,
                NombreArticulo = d.Articulo.Nombre,
                TipoArticulo = d.Articulo.tipoArticulo.Nombre,
                d.Cantidad,
                d.Monto
            }).ToList();

            dgvDetallePedido.DataSource = detallesFormateados;

            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        #endregion
    }
}
