namespace CapaDePresentacion
{
    partial class frmAgregarDetallePedido
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
            label1 = new Label();
            cboNumeroPedido = new ComboBox();
            label2 = new Label();
            cboArticulo = new ComboBox();
            label3 = new Label();
            txtCantidad = new TextBox();
            buttonAgregar = new Button();
            buttonCerrar = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 65);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Numero pedido";
            // 
            // cboNumeroPedido
            // 
            cboNumeroPedido.FormattingEnabled = true;
            cboNumeroPedido.Location = new Point(153, 62);
            cboNumeroPedido.Name = "cboNumeroPedido";
            cboNumeroPedido.Size = new Size(121, 23);
            cboNumeroPedido.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 114);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 2;
            label2.Text = "Articulo";
            // 
            // cboArticulo
            // 
            cboArticulo.FormattingEnabled = true;
            cboArticulo.Location = new Point(153, 111);
            cboArticulo.Name = "cboArticulo";
            cboArticulo.Size = new Size(121, 23);
            cboArticulo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 157);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(156, 154);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(118, 23);
            txtCantidad.TabIndex = 5;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(98, 217);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 6;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(199, 217);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 7;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(36, 18);
            label4.Name = "label4";
            label4.Size = new Size(218, 25);
            label4.TabIndex = 8;
            label4.Text = "Agregar Detalle Pedido";
            // 
            // frmAgregarDetallePedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 252);
            Controls.Add(label4);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonAgregar);
            Controls.Add(txtCantidad);
            Controls.Add(label3);
            Controls.Add(cboArticulo);
            Controls.Add(label2);
            Controls.Add(cboNumeroPedido);
            Controls.Add(label1);
            Name = "frmAgregarDetallePedido";
            Text = "Agregar Detalle Pedido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboNumeroPedido;
        private Label label2;
        private ComboBox cboArticulo;
        private Label label3;
        private TextBox txtCantidad;
        private Button buttonAgregar;
        private Button buttonCerrar;
        private Label label4;
    }
}