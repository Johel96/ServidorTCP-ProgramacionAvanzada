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
using Entidades.Client;
using Newtonsoft.Json;
using ProyectoCliente;

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

namespace InterfazGrafica
{
    public partial class frmAgregarPedido : Form    {
        
        private List<DetallePedido> detallesAgregados = new List<DetallePedido>();

        public frmAgregarPedido()
        {
            InitializeComponent();
            this.Load += frmAgregarPedido_Load;
        }

        #region Metodos
        
        private void frmAgregarPedido_Load(object sender, EventArgs e)
        {
            try
            {
                int idCliente = PuertoTCP.clienteActual.Identificacion;

                // Consultar solo los pedidos del cliente actual
                List<Pedido> pedidos = PuertoTCP.ConsultarPedidoPorCliente(idCliente.ToString());

                cboNumeroPedido.DataSource = pedidos;
                cboNumeroPedido.DisplayMember = "NumeroPedido"; // Lo que se ve
                cboNumeroPedido.ValueMember = "NumeroPedido";   // Valor interno
                cboNumeroPedido.SelectedIndex = -1; // Ningún pedido seleccionado por defecto

                // Mostrar nombre del cliente en el label
                lblNombre.Text = $"{PuertoTCP.clienteActual.Nombre} {PuertoTCP.clienteActual.PrimerApellido} {PuertoTCP.clienteActual.SegundoApellido}";
                
                // Cargar artículos activos
                List<Articulo> articulos = PuertoTCP.ConsultarArticulo(""); // Se trae del servidor
                List<Articulo> articulosActivos = articulos.Where(a => a.Activo).ToList(); // Solo activos

                cboArticulos.DataSource = articulosActivos;
                cboArticulos.DisplayMember = "Nombre";
                cboArticulos.ValueMember = "ID";
                cboArticulos.SelectedIndex = -1;

                //Configuracion dgvStock                             
                dgvStockArticulo.Columns.Add("Nombre", "Nombre Artículo");
                dgvStockArticulo.Columns.Add("Tipo", "Tipo Artículo");
                dgvStockArticulo.Columns.Add("Precio", "Precio");
                dgvStockArticulo.Columns.Add("Stock", "Inventario");



                cboArticulos.SelectedIndexChanged += cboArticulos_SelectedIndexChanged;


            }
            catch (Exception ex) {
                MessageBox.Show("Error al cargar pedidos del cliente: " + ex.Message);
            }
        }

        private void cboArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArticulos.SelectedItem is Articulo articuloSeleccionado)
            {
                dgvStockArticulo.Rows.Clear(); // Limpia antes de agregar nuevo

                dgvStockArticulo.Rows.Add(
                    articuloSeleccionado.Nombre,
                    articuloSeleccionado.tipoArticulo.Nombre,
                    articuloSeleccionado.Precio.ToString("C"),
                    articuloSeleccionado.Stock
                );
            }
        }


        #endregion


        #region Eventos        
        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            if (cboNumeroPedido.SelectedItem == null || cboArticulos.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe seleccionar un pedido, un artículo y digitar la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Articulo articuloSeleccionado = (Articulo)cboArticulos.SelectedItem;

            if (cantidad > articuloSeleccionado.Stock)
            {
                MessageBox.Show("No hay suficiente inventario disponible para este artículo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idArticuloSeleccionado = ((Articulo)cboArticulos.SelectedItem).ID;
            int numeroPedidoSeleccionado = (int)cboNumeroPedido.SelectedValue;

            // Verifica si ya se agregó ese artículo a ese pedido
            bool articuloYaAgregado = detallesAgregados.Any(d =>
                d.NumeroPedido == numeroPedidoSeleccionado &&
                d.Articulo.ID == idArticuloSeleccionado);

            if (articuloYaAgregado)
            {
                MessageBox.Show("Este artículo ya fue agregado a este pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numeroPedido = ((Pedido)cboNumeroPedido.SelectedItem).NumeroPedido;
            double montoConImpuesto = (cantidad * articuloSeleccionado.Precio)*1.13;

            // Crear el detalle de pedido
            DetallePedido detalle = new DetallePedido
            {
                NumeroPedido = numeroPedido,
                Articulo = articuloSeleccionado,
                Cantidad = cantidad,
                Monto = montoConImpuesto
            };

            // Enviar al servidor
            bool exito = PuertoTCP.AgregarDetallePedido(detalle);


            if (exito)
            {
                MessageBox.Show("Detalle del pedido agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Restar la cantidad del stock visual
                articuloSeleccionado.Stock -= cantidad;

                //

                // Refrescar el DataGridView con nuevo stock
                dgvStockArticulo.Rows.Clear();
                dgvStockArticulo.Rows.Add(
                    articuloSeleccionado.Nombre,
                    articuloSeleccionado.tipoArticulo.Nombre,
                    articuloSeleccionado.Precio.ToString("C"),
                    articuloSeleccionado.Stock
                );

                // Guardar detalle en la lista local
                detallesAgregados.Add(detalle);
                txtCantidad.Clear();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al agregar el detalle del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
