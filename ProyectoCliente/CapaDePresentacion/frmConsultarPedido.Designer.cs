namespace CapaDePresentacion
{
    partial class frmConsultarPedido
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
            buttonCerrar = new Button();
            dgvConsultaPedido = new DataGridView();
            labelConsultaPedidos = new Label();
            dgvDetallePedido = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            SuspendLayout();
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(752, 599);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 0;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // dgvConsultaPedido
            // 
            dgvConsultaPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaPedido.Location = new Point(18, 40);
            dgvConsultaPedido.Name = "dgvConsultaPedido";
            dgvConsultaPedido.Size = new Size(809, 285);
            dgvConsultaPedido.TabIndex = 1;
            // 
            // labelConsultaPedidos
            // 
            labelConsultaPedidos.AutoSize = true;
            labelConsultaPedidos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConsultaPedidos.Location = new Point(18, 7);
            labelConsultaPedidos.Name = "labelConsultaPedidos";
            labelConsultaPedidos.Size = new Size(190, 30);
            labelConsultaPedidos.TabIndex = 3;
            labelConsultaPedidos.Text = "Consultar Pedidos\r\n";
            // 
            // dgvDetallePedido
            // 
            dgvDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallePedido.Location = new Point(18, 370);
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.Size = new Size(809, 223);
            dgvDetallePedido.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 337);
            label1.Name = "label1";
            label1.Size = new Size(155, 30);
            label1.TabIndex = 5;
            label1.Text = "Detalle Pedido";
            // 
            // frmConsultarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 634);
            Controls.Add(label1);
            Controls.Add(dgvDetallePedido);
            Controls.Add(labelConsultaPedidos);
            Controls.Add(dgvConsultaPedido);
            Controls.Add(buttonCerrar);
            Name = "frmConsultarPedido";
            Text = "Consultar Pedido";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCerrar;
        private DataGridView dgvConsultaPedido;
        private Label labelConsultaPedidos;
        private DataGridView dgvDetallePedido;
        private Label label1;
    }
}