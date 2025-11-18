namespace CapaDePresentacion
{
    partial class frmAgregarPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAgregar = new Button();
            buttonCerrar = new Button();
            labelFechaPedido = new Label();
            labelCliente = new Label();
            labelRepartidor = new Label();
            labelTitulo = new Label();
            dtpFechaPedido = new DateTimePicker();
            cboCliente = new ComboBox();
            cboRepartidor = new ComboBox();
            labelDireccion = new Label();
            txtDireccion = new TextBox();
            SuspendLayout();
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(206, 280);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 0;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(300, 280);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 1;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelFechaPedido
            // 
            labelFechaPedido.AutoSize = true;
            labelFechaPedido.Location = new Point(40, 109);
            labelFechaPedido.Name = "labelFechaPedido";
            labelFechaPedido.Size = new Size(78, 15);
            labelFechaPedido.TabIndex = 3;
            labelFechaPedido.Text = "Fecha pedido";
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(40, 146);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(44, 15);
            labelCliente.TabIndex = 4;
            labelCliente.Text = "Cliente";
            // 
            // labelRepartidor
            // 
            labelRepartidor.AutoSize = true;
            labelRepartidor.Location = new Point(40, 185);
            labelRepartidor.Name = "labelRepartidor";
            labelRepartidor.Size = new Size(62, 15);
            labelRepartidor.TabIndex = 5;
            labelRepartidor.Text = "Repartidor";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(113, 9);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(205, 32);
            labelTitulo.TabIndex = 10;
            labelTitulo.Text = "Agregar pedidos";
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(150, 101);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(225, 23);
            dtpFechaPedido.TabIndex = 12;
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(150, 138);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(225, 23);
            cboCliente.TabIndex = 13;
            // 
            // cboRepartidor
            // 
            cboRepartidor.FormattingEnabled = true;
            cboRepartidor.Location = new Point(150, 177);
            cboRepartidor.Name = "cboRepartidor";
            cboRepartidor.Size = new Size(225, 23);
            cboRepartidor.TabIndex = 14;
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Location = new Point(40, 226);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(57, 15);
            labelDireccion.TabIndex = 15;
            labelDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(150, 218);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(225, 23);
            txtDireccion.TabIndex = 16;
            // 
            // frmAgregarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 325);
            Controls.Add(txtDireccion);
            Controls.Add(labelDireccion);
            Controls.Add(cboRepartidor);
            Controls.Add(cboCliente);
            Controls.Add(dtpFechaPedido);
            Controls.Add(labelTitulo);
            Controls.Add(labelRepartidor);
            Controls.Add(labelCliente);
            Controls.Add(labelFechaPedido);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonAgregar);
            Name = "frmAgregarPedido";
            Text = "Agregar Pedido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAgregar;
        private Button buttonCerrar;
        private Label labelFechaPedido;
        private Label labelCliente;
        private Label labelRepartidor;
        private Label labelTitulo;
        private DateTimePicker dtpFechaPedido;
        private ComboBox cboCliente;
        private ComboBox cboRepartidor;
        private Label labelDireccion;
        private TextBox txtDireccion;
    }
}