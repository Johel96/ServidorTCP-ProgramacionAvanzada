using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

namespace InterfazGrafica
{
    public partial class frmConsultarPedido : Form
    {
        public frmConsultarPedido()
        {
            InitializeComponent();
            this.Load += frmConsultarPedido_Load;

        }

        private void frmConsultarPedido_Load(object sender, EventArgs e)
        {
            if (PuertoTCP.clienteActual == null)
            {
                MessageBox.Show("Error");
                this.Close();
                return;
            }
            //Mostrar nombre del cliente en un label
            lblNombre.Text = $"Pedidos de: {PuertoTCP.clienteActual.Nombre} {PuertoTCP.clienteActual.PrimerApellido} {PuertoTCP.clienteActual.SegundoApellido}";

            //llama al metodo de carga usando la identificacion del usuario
            CargarPedidos(PuertoTCP.clienteActual.Identificacion.ToString());


        }

        private void CargarPedidos(string Identificacion)
        {
            try
            {
                var pedidos = PuertoTCP.ConsultarPedidoPorCliente(Identificacion);
                ConfigurardgvConsulta();
                dgvConsulta.DataSource = pedidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar pedidos");
            }
        }

        private void ConfigurardgvConsulta()
        {
            try
            {

                dgvConsulta.DataSource = null; // Limpia el DataGridView antes de cargar los datos
                dgvConsulta.Rows.Clear(); // Limpia las filas del DataGridView
                dgvConsulta.Columns.Clear(); // Limpia las columnas del DataGridView
                dgvConsulta.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                //Columna ID
                dgvConsulta.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NumeroPedido", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Número de Pedido", // Título de la columna
                    Name = "NumeroPedido", // Nombre interno de la columna
                    Width = 100, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                //Columna Fecha de Pedido
                dgvConsulta.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaPedido", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Fecha de Pedido", // Título de la columna
                    Name = "FechaPedido", // Nombre interno de la columna
                    Width = 150, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                //Columna Cliente
                dgvConsulta.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreCliente", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Cliente", // Título de la columna
                    Name = "Cliente", // Nombre interno de la columna
                    Width = 200, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                //Columna Repartidor
                dgvConsulta.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreRepartidor", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Repartidor", // Título de la columna
                    Name = "Repartidor", // Nombre interno de la columna
                    Width = 200, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });
                //Columna Dirección
                dgvConsulta.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Direccion", // Nombre de la propiedad del objeto Pedido que se mostrará en esta columna
                    HeaderText = "Dirección", // Título de la columna
                    Name = "Direccion", // Nombre interno de la columna
                    Width = 250, // Ancho de la columna
                    ReadOnly = true // Hace que la columna sea de solo lectura
                });

                dgvConsulta.ReadOnly = true; // Hace que el DataGridView sea de solo lectura
                dgvConsulta.AllowUserToAddRows = false; // Desactiva la opción de agregar filas por el usuario
                dgvConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar filas completas
                dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el espacio disponible
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

