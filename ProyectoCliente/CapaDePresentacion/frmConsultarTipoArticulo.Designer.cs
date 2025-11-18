namespace CapaDePresentacion
{
    partial class frmConsultarTipoArticulo
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
            dgvConsultaTipoArticulo = new DataGridView();
            buttonCerrar = new Button();
            labelConsultaTipoArticulos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaTipoArticulo).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaTipoArticulo
            // 
            dgvConsultaTipoArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaTipoArticulo.Location = new Point(12, 42);
            dgvConsultaTipoArticulo.Name = "dgvConsultaTipoArticulo";
            dgvConsultaTipoArticulo.Size = new Size(375, 297);
            dgvConsultaTipoArticulo.TabIndex = 0;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(312, 345);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 1;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelConsultaTipoArticulos
            // 
            labelConsultaTipoArticulos.AutoSize = true;
            labelConsultaTipoArticulos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConsultaTipoArticulos.Location = new Point(43, 9);
            labelConsultaTipoArticulos.Name = "labelConsultaTipoArticulos";
            labelConsultaTipoArticulos.Size = new Size(289, 30);
            labelConsultaTipoArticulos.TabIndex = 3;
            labelConsultaTipoArticulos.Text = "Consulta Tipos de  Articulos\r\n";
            // 
            // frmConsultarTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 378);
            Controls.Add(labelConsultaTipoArticulos);
            Controls.Add(buttonCerrar);
            Controls.Add(dgvConsultaTipoArticulo);
            Name = "frmConsultarTipoArticulo";
            Text = "Consultar Tipo Articulo";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaTipoArticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConsultaTipoArticulo;
        private Button buttonCerrar;
        private Label labelConsultaTipoArticulos;
    }
}