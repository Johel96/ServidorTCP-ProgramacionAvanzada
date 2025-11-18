namespace CapaDePresentacion
{
    partial class frmConsultaCliente
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
            dgvConsultaCliente = new DataGridView();
            buttonRegresar = new Button();
            labelConsultaClientes = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaCliente).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaCliente
            // 
            dgvConsultaCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaCliente.Location = new Point(12, 54);
            dgvConsultaCliente.Name = "dgvConsultaCliente";
            dgvConsultaCliente.Size = new Size(647, 376);
            dgvConsultaCliente.TabIndex = 0;
            dgvConsultaCliente.CellContentClick += dgvConsultaCliente_CellContentClick;
            // 
            // buttonRegresar
            // 
            buttonRegresar.Location = new Point(584, 436);
            buttonRegresar.Name = "buttonRegresar";
            buttonRegresar.Size = new Size(75, 23);
            buttonRegresar.TabIndex = 1;
            buttonRegresar.Text = "Regresar";
            buttonRegresar.UseVisualStyleBackColor = true;
            buttonRegresar.Click += buttonRegresar_Click;
            // 
            // labelConsultaClientes
            // 
            labelConsultaClientes.AutoSize = true;
            labelConsultaClientes.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConsultaClientes.Location = new Point(216, 9);
            labelConsultaClientes.Name = "labelConsultaClientes";
            labelConsultaClientes.Size = new Size(212, 30);
            labelConsultaClientes.TabIndex = 3;
            labelConsultaClientes.Text = "Consulta de Clientes";
            // 
            // frmConsultaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 471);
            Controls.Add(labelConsultaClientes);
            Controls.Add(buttonRegresar);
            Controls.Add(dgvConsultaCliente);
            Name = "frmConsultaCliente";
            Text = "Consulta Cliente";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConsultaCliente;
        private Button buttonRegresar;
        private Label labelConsultaClientes;
    }
}