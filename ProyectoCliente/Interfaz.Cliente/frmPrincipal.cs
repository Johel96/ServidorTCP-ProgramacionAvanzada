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

    public partial class frmPrincipal : Form
    {
        bool clienteConectado = false; // Indica si el cliente está conectado al servidor
        public frmPrincipal()
        {
            InitializeComponent();
            lblEstado.ForeColor = Color.Red; // Establece el color del texto de estado a rojo
            btnDesconectar.Enabled = false; // Deshabilita el botón de desconexión al inicio
            btnConectar.Enabled = true; // Habilita el botón de conexión al inicio            
        }// Fin del constructor Principal       


        #region botones de conexión y desconexión
        // Conecta al cliente al servidor y busca el cliente en la base de datos
        private void btnConectar_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text.Trim();

            if (!string.IsNullOrEmpty(identificacion))
            {
                if (PuertoTCP.Conectar(identificacion))
                {
                    // Buscar cliente en la base
                    var clientes = PuertoTCP.ConsultarCliente(identificacion);
                    var clienteEncontrado = clientes.FirstOrDefault(c => c.Identificacion.ToString() == identificacion);

                    if (clienteEncontrado != null)
                    {
                        // Guardar el cliente actual
                        PuertoTCP.clienteActual = clienteEncontrado;

                        // Mostrar nombre completo
                        lblNombre.Text = $"{clienteEncontrado.Nombre} {clienteEncontrado.PrimerApellido} {clienteEncontrado.SegundoApellido}";
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    lblEstado.Text = "Conectado al servidor... en (127.0.0.1, 30000)";
                    lblEstado.ForeColor = Color.Green;
                    clienteConectado = true;
                    btnConectar.Enabled = false;
                    btnDesconectar.Enabled = true;
                    txtIdentificacion.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se pudo conectar al servidor. Verifique que esté ejecutándose.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar una identificación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }// Fin del método btnConectar_Click

        // Solicita al servidor que cierre la conexión del cliente
        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            PuertoTCP.Desconectar(txtIdentificacion.Text); 

            lblEstado.Text = "Desconectado del servidor."; 
            lblEstado.ForeColor = Color.Red; 
            btnDesconectar.Enabled = false;
            btnConectar.Enabled = true; 
            clienteConectado = false;
            txtIdentificacion.ReadOnly = false; 
        }// Fin del método btnDesconectar_Click
        #endregion

        #region eventos de botones de consulta y agregar pedidos
        //evento que maneja el clic del botón para consultar pedidos si el cliente está conectado
        private void btnConsultarPedido_Click(object sender, EventArgs e)
        {
            if (clienteConectado)
            {
                frmConsultarPedido frmConsultarPedido = new frmConsultarPedido(); 
                frmConsultarPedido.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Debe conectarse al servidor antes de consultar pedidos.", "Conexión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }// Fin del método btnConsultarPedido_Click

        //evento que maneja el clic del botón para agregar un pedido si el cliente está conectado
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (clienteConectado)
            {
                frmAgregarPedido frmAgregarPedido = new frmAgregarPedido(); 
                frmAgregarPedido.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Debe conectarse al servidor antes de agregar pedidos.", "Conexión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }// Fin del método btnAgregar_Click
        #endregion
    }// Fin de la clase Principal
}
