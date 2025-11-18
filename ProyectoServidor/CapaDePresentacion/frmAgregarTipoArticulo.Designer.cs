namespace CapaDePresentacion
{
    partial class frmAgregarTipoArticulo
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
            labelID = new Label();
            labelNombre = new Label();
            labelDescripcion = new Label();
            textBoxID = new TextBox();
            textBoxNombre = new TextBox();
            textBoxDescripcion = new TextBox();
            buttonAgregar = new Button();
            buttonCerrar = new Button();
            labelAddTipoArticulo = new Label();
            SuspendLayout();
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(33, 58);
            labelID.Name = "labelID";
            labelID.Size = new Size(18, 15);
            labelID.TabIndex = 0;
            labelID.Text = "ID";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(33, 100);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre";
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(33, 146);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 2;
            labelDescripcion.Text = "Descripcion";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(140, 58);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(155, 23);
            textBoxID.TabIndex = 3;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(140, 100);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(155, 23);
            textBoxNombre.TabIndex = 4;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(140, 138);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(155, 23);
            textBoxDescripcion.TabIndex = 5;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(113, 213);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 6;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(220, 213);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 7;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelAddTipoArticulo
            // 
            labelAddTipoArticulo.AutoSize = true;
            labelAddTipoArticulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAddTipoArticulo.Location = new Point(33, 9);
            labelAddTipoArticulo.Name = "labelAddTipoArticulo";
            labelAddTipoArticulo.Size = new Size(234, 25);
            labelAddTipoArticulo.TabIndex = 8;
            labelAddTipoArticulo.Text = "Agregar Tipo de Articulo";
            // 
            // frmAgregarTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 268);
            Controls.Add(labelAddTipoArticulo);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonAgregar);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxID);
            Controls.Add(labelDescripcion);
            Controls.Add(labelNombre);
            Controls.Add(labelID);
            Name = "frmAgregarTipoArticulo";
            Text = "Agregar Tipo de Articulo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelID;
        private Label labelNombre;
        private Label labelDescripcion;
        private TextBox textBoxID;
        private TextBox textBoxNombre;
        private TextBox textBoxDescripcion;
        private Button buttonAgregar;
        private Button buttonCerrar;
        private Label labelAddTipoArticulo;
    }
}