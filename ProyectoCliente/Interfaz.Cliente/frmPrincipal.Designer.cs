
namespace InterfazGrafica
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Grupo1 = new GroupBox();
            lblNombre = new Label();
            label2 = new Label();
            txtIdentificacion = new TextBox();
            btnDesconectar = new Button();
            btnConectar = new Button();
            label3 = new Label();
            lblEstado = new Label();
            label1 = new Label();
            label4 = new Label();
            btnConsultarPedido = new Button();
            btnAgregar = new Button();
            Grupo1.SuspendLayout();
            SuspendLayout();
            // 
            // Grupo1
            // 
            Grupo1.Controls.Add(lblNombre);
            Grupo1.Controls.Add(label2);
            Grupo1.Controls.Add(txtIdentificacion);
            Grupo1.Controls.Add(btnDesconectar);
            Grupo1.Controls.Add(btnConectar);
            Grupo1.Controls.Add(label3);
            Grupo1.Controls.Add(lblEstado);
            Grupo1.Controls.Add(label1);
            Grupo1.Location = new Point(12, 53);
            Grupo1.Name = "Grupo1";
            Grupo1.Size = new Size(430, 210);
            Grupo1.TabIndex = 0;
            Grupo1.TabStop = false;
            Grupo1.Text = "Conectar con el servidor";
            Grupo1.Enter += groupBox1_Enter;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(96, 116);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(89, 15);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 116);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre:";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(96, 71);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(146, 23);
            txtIdentificacion.TabIndex = 5;
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(315, 172);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(100, 23);
            btnDesconectar.TabIndex = 4;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(315, 143);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(100, 23);
            btnConectar.TabIndex = 3;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 79);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 2;
            label3.Text = "Identificacion:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(96, 33);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(82, 15);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Desconectado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(48, 9);
            label4.Name = "label4";
            label4.Size = new Size(312, 32);
            label4.TabIndex = 3;
            label4.Text = "Bienvenido a Entregas S.A";
            // 
            // btnConsultarPedido
            // 
            btnConsultarPedido.Location = new Point(168, 277);
            btnConsultarPedido.Name = "btnConsultarPedido";
            btnConsultarPedido.Size = new Size(133, 43);
            btnConsultarPedido.TabIndex = 4;
            btnConsultarPedido.Text = "Consultar Pedidos";
            btnConsultarPedido.UseVisualStyleBackColor = true;
            btnConsultarPedido.Click += btnConsultarPedido_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(18, 277);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(133, 43);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar pedidos";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 450);
            Controls.Add(btnAgregar);
            Controls.Add(btnConsultarPedido);
            Controls.Add(label4);
            Controls.Add(Grupo1);
            Name = "frmPrincipal";
            Text = "Entregas S.A";
            Grupo1.ResumeLayout(false);
            Grupo1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        #endregion

        private GroupBox Grupo1;
        private TextBox txtIdentificacion;
        private Button btnDesconectar;
        private Button btnConectar;
        private Label label3;
        private Label lblEstado;
        private Label label1;
        private Label label4;
        private Button btnConsultarPedido;
        private Button btnAgregar;
        private Label lblNombre;
        private Label label2;
    }
}
