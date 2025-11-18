namespace CapaDePresentacion
{
    partial class frmConsultaArticulo
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
            dgvConsultaArticulo = new DataGridView();
            buttonCerrar = new Button();
            labelConsultaArticulos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaArticulo).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaArticulo
            // 
            dgvConsultaArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaArticulo.Location = new Point(12, 49);
            dgvConsultaArticulo.Name = "dgvConsultaArticulo";
            dgvConsultaArticulo.Size = new Size(655, 361);
            dgvConsultaArticulo.TabIndex = 0;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(546, 416);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(121, 23);
            buttonCerrar.TabIndex = 1;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelConsultaArticulos
            // 
            labelConsultaArticulos.AutoSize = true;
            labelConsultaArticulos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConsultaArticulos.Location = new Point(212, 9);
            labelConsultaArticulos.Name = "labelConsultaArticulos";
            labelConsultaArticulos.Size = new Size(224, 30);
            labelConsultaArticulos.TabIndex = 2;
            labelConsultaArticulos.Text = "Consulta de Articulos\r\n";
            // 
            // frmConsultaArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 451);
            Controls.Add(labelConsultaArticulos);
            Controls.Add(buttonCerrar);
            Controls.Add(dgvConsultaArticulo);
            Name = "frmConsultaArticulo";
            Text = "Consulta de Articulos";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaArticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConsultaArticulo;
        private Button buttonCerrar;
        private Label labelConsultaArticulos;
    }
}