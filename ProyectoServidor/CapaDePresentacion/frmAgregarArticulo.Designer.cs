namespace CapaDePresentacion
{
    partial class frmAgregarArticulo
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
            labelTipo = new Label();
            labelPrecio = new Label();
            labelInventario = new Label();
            labelEstado = new Label();
            textBoxID = new TextBox();
            textBoxNombre = new TextBox();
            textBoxPrecio = new TextBox();
            textBoxInventario = new TextBox();
            cboEstado = new ComboBox();
            buttonAgregar = new Button();
            buttonCerrar = new Button();
            labelAgregarArticulo = new Label();
            cboTipoArticulo = new ComboBox();
            SuspendLayout();
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(31, 58);
            labelID.Name = "labelID";
            labelID.Size = new Size(63, 15);
            labelID.TabIndex = 0;
            labelID.Text = "ID Articulo";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(31, 96);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre";
            // 
            // labelTipo
            // 
            labelTipo.AutoSize = true;
            labelTipo.Location = new Point(31, 138);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(31, 15);
            labelTipo.TabIndex = 2;
            labelTipo.Text = "Tipo";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Location = new Point(31, 173);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(36, 15);
            labelPrecio.TabIndex = 3;
            labelPrecio.Text = "Valor ";
            // 
            // labelInventario
            // 
            labelInventario.AutoSize = true;
            labelInventario.Location = new Point(31, 217);
            labelInventario.Name = "labelInventario";
            labelInventario.Size = new Size(60, 15);
            labelInventario.TabIndex = 4;
            labelInventario.Text = "Inventario";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(31, 254);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(42, 15);
            labelEstado.TabIndex = 5;
            labelEstado.Text = "Estado";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(145, 50);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(205, 23);
            textBoxID.TabIndex = 6;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(145, 88);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(205, 23);
            textBoxNombre.TabIndex = 7;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(145, 165);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(205, 23);
            textBoxPrecio.TabIndex = 8;
            // 
            // textBoxInventario
            // 
            textBoxInventario.Location = new Point(145, 209);
            textBoxInventario.Name = "textBoxInventario";
            textBoxInventario.Size = new Size(205, 23);
            textBoxInventario.TabIndex = 9;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Si", "No" });
            cboEstado.Location = new Point(145, 246);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(205, 23);
            cboEstado.TabIndex = 11;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(182, 294);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 12;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(275, 294);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 13;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelAgregarArticulo
            // 
            labelAgregarArticulo.AutoSize = true;
            labelAgregarArticulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAgregarArticulo.Location = new Point(41, 9);
            labelAgregarArticulo.Name = "labelAgregarArticulo";
            labelAgregarArticulo.Size = new Size(203, 32);
            labelAgregarArticulo.TabIndex = 14;
            labelAgregarArticulo.Text = "Agregar articulo";
            // 
            // cboTipoArticulo
            // 
            cboTipoArticulo.FormattingEnabled = true;
            cboTipoArticulo.Location = new Point(145, 130);
            cboTipoArticulo.Name = "cboTipoArticulo";
            cboTipoArticulo.Size = new Size(205, 23);
            cboTipoArticulo.TabIndex = 16;
            // 
            // frmAgregarArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 349);
            Controls.Add(cboTipoArticulo);
            Controls.Add(labelAgregarArticulo);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonAgregar);
            Controls.Add(cboEstado);
            Controls.Add(textBoxInventario);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxID);
            Controls.Add(labelEstado);
            Controls.Add(labelInventario);
            Controls.Add(labelPrecio);
            Controls.Add(labelTipo);
            Controls.Add(labelNombre);
            Controls.Add(labelID);
            Name = "frmAgregarArticulo";
            Text = "Agregar Articulo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelID;
        private Label labelNombre;
        private Label labelTipo;
        private Label labelPrecio;
        private Label labelInventario;
        private Label labelEstado;
        private TextBox textBoxID;
        private TextBox textBoxNombre;
        private TextBox textBoxPrecio;
        private TextBox textBoxInventario;
        private ComboBox cboEstado;
        private Button buttonAgregar;
        private Button buttonCerrar;
        private Label labelAgregarArticulo;
        private ComboBox cboTipoArticulo;
    }
}