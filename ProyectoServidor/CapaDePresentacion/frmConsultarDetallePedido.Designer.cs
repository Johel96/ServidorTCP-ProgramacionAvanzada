namespace CapaDePresentacion
{
    partial class frmConsultarDetallePedido
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
            dgvDetallePedido = new DataGridView();
            buttonCerrar = new Button();
            labelDetallepedidos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            SuspendLayout();
            // 
            // dgvDetallePedido
            // 
            dgvDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallePedido.Location = new Point(12, 57);
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.Size = new Size(648, 372);
            dgvDetallePedido.TabIndex = 2;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(595, 435);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 3;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelDetallepedidos
            // 
            labelDetallepedidos.AutoSize = true;
            labelDetallepedidos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDetallepedidos.Location = new Point(234, 9);
            labelDetallepedidos.Name = "labelDetallepedidos";
            labelDetallepedidos.Size = new Size(165, 30);
            labelDetallepedidos.TabIndex = 1;
            labelDetallepedidos.Text = "Detalle pedidos";
            // 
            // frmConsultarDetallePedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 470);
            Controls.Add(buttonCerrar);
            Controls.Add(dgvDetallePedido);
            Controls.Add(labelDetallepedidos);
            Name = "frmConsultarDetallePedido";
            Text = "Consultar Detalle Pedido";
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvDetallePedido;
        private Button buttonCerrar;
        private Label labelDetallepedidos;
    }
}