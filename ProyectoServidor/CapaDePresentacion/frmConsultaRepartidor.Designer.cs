namespace CapaDePresentacion
{
    partial class frmConsultaRepartidor
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
            dgvConsultaRepartidor = new DataGridView();
            buttonRegresar = new Button();
            labelConsultaRepartidores = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaRepartidor).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaRepartidor
            // 
            dgvConsultaRepartidor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaRepartidor.Location = new Point(12, 42);
            dgvConsultaRepartidor.Name = "dgvConsultaRepartidor";
            dgvConsultaRepartidor.Size = new Size(652, 408);
            dgvConsultaRepartidor.TabIndex = 0;
            dgvConsultaRepartidor.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonRegresar
            // 
            buttonRegresar.Location = new Point(589, 456);
            buttonRegresar.Name = "buttonRegresar";
            buttonRegresar.Size = new Size(75, 35);
            buttonRegresar.TabIndex = 1;
            buttonRegresar.Text = "Regresar";
            buttonRegresar.UseVisualStyleBackColor = true;
            buttonRegresar.Click += buttonRegresar_Click;
            // 
            // labelConsultaRepartidores
            // 
            labelConsultaRepartidores.AutoSize = true;
            labelConsultaRepartidores.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConsultaRepartidores.Location = new Point(191, 9);
            labelConsultaRepartidores.Name = "labelConsultaRepartidores";
            labelConsultaRepartidores.Size = new Size(260, 30);
            labelConsultaRepartidores.TabIndex = 3;
            labelConsultaRepartidores.Text = "Consulta de Repartidores";
            // 
            // frmConsultaRepartidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 503);
            Controls.Add(labelConsultaRepartidores);
            Controls.Add(buttonRegresar);
            Controls.Add(dgvConsultaRepartidor);
            Name = "frmConsultaRepartidor";
            Text = "Consulta Repartidor";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaRepartidor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConsultaRepartidor;
        private Button buttonRegresar;
        private Label labelConsultaRepartidores;
    }
}