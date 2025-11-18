namespace InterfazGrafica
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
            cboNumeroPedido = new ComboBox();
            cboArticulos = new ComboBox();
            dateTimePickerFechaPedido = new DateTimePicker();
            label1 = new Label();
            lblNombre = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCantidad = new TextBox();
            dgvStockArticulo = new DataGridView();
            btnAgregar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStockArticulo).BeginInit();
            SuspendLayout();
            // 
            // cboNumeroPedido
            // 
            cboNumeroPedido.FormattingEnabled = true;
            cboNumeroPedido.Location = new Point(109, 58);
            cboNumeroPedido.Name = "cboNumeroPedido";
            cboNumeroPedido.Size = new Size(200, 23);
            cboNumeroPedido.TabIndex = 0;
            // 
            // cboArticulos
            // 
            cboArticulos.FormattingEnabled = true;
            cboArticulos.Location = new Point(109, 94);
            cboArticulos.Name = "cboArticulos";
            cboArticulos.Size = new Size(200, 23);
            cboArticulos.TabIndex = 1;
            // 
            // dateTimePickerFechaPedido
            // 
            dateTimePickerFechaPedido.Location = new Point(109, 131);
            dateTimePickerFechaPedido.Name = "dateTimePickerFechaPedido";
            dateTimePickerFechaPedido.Size = new Size(200, 23);
            dateTimePickerFechaPedido.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 3;
            label1.Text = "Numero pedido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 102);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 5;
            label3.Text = "Articulo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 139);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 6;
            label4.Text = "Fecha pedido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 178);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 7;
            label5.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(109, 170);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(200, 23);
            txtCantidad.TabIndex = 8;
            // 
            // dgvStockArticulo
            // 
            dgvStockArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockArticulo.Location = new Point(26, 219);
            dgvStockArticulo.Name = "dgvStockArticulo";
            dgvStockArticulo.Size = new Size(558, 219);
            dgvStockArticulo.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(409, 170);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(509, 169);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmAgregarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 465);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvStockArticulo);
            Controls.Add(txtCantidad);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblNombre);
            Controls.Add(label1);
            Controls.Add(dateTimePickerFechaPedido);
            Controls.Add(cboArticulos);
            Controls.Add(cboNumeroPedido);
            Name = "frmAgregarPedido";
            Text = "Agregar Pedido";
            ((System.ComponentModel.ISupportInitialize)dgvStockArticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboNumeroPedido;
        private ComboBox cboArticulos;
        private DateTimePicker dateTimePickerFechaPedido;
        private Label label1;
        private Label lblNombre;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCantidad;
        private DataGridView dgvStockArticulo;
        private Button btnAgregar;
        private Button btnCerrar;
    }
}