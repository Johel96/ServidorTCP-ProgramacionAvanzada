namespace CapaDePresentacion
{
    partial class frmAgregarCliente
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
            labelIdentificacion = new Label();
            labelNombre = new Label();
            labelPrimerApellido = new Label();
            labelSegundoApellido = new Label();
            labelFechaNacimiento = new Label();
            labelEstado = new Label();
            textBoxID = new TextBox();
            textBoxNombre = new TextBox();
            textBoxPrimerApellido = new TextBox();
            textBoxSegundoApellido = new TextBox();
            dateTimePickerFechaNacimiento = new DateTimePicker();
            cboEstado = new ComboBox();
            buttonAgregar = new Button();
            buttonCerrar = new Button();
            labelAgregarCliente = new Label();
            SuspendLayout();
            // 
            // labelIdentificacion
            // 
            labelIdentificacion.AutoSize = true;
            labelIdentificacion.Location = new Point(53, 76);
            labelIdentificacion.Name = "labelIdentificacion";
            labelIdentificacion.Size = new Size(79, 15);
            labelIdentificacion.TabIndex = 0;
            labelIdentificacion.Text = "Identificacion";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(53, 120);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre";
            // 
            // labelPrimerApellido
            // 
            labelPrimerApellido.AutoSize = true;
            labelPrimerApellido.Location = new Point(53, 170);
            labelPrimerApellido.Name = "labelPrimerApellido";
            labelPrimerApellido.Size = new Size(89, 15);
            labelPrimerApellido.TabIndex = 2;
            labelPrimerApellido.Text = "Primer Apellido";
            // 
            // labelSegundoApellido
            // 
            labelSegundoApellido.AutoSize = true;
            labelSegundoApellido.Location = new Point(53, 216);
            labelSegundoApellido.Name = "labelSegundoApellido";
            labelSegundoApellido.Size = new Size(101, 15);
            labelSegundoApellido.TabIndex = 3;
            labelSegundoApellido.Text = "Segundo Apellido";
            // 
            // labelFechaNacimiento
            // 
            labelFechaNacimiento.AutoSize = true;
            labelFechaNacimiento.Location = new Point(53, 264);
            labelFechaNacimiento.Name = "labelFechaNacimiento";
            labelFechaNacimiento.Size = new Size(117, 15);
            labelFechaNacimiento.TabIndex = 4;
            labelFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(53, 312);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(96, 15);
            labelEstado.TabIndex = 5;
            labelEstado.Text = "Estado de cliente";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(182, 68);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(200, 23);
            textBoxID.TabIndex = 6;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(182, 112);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(200, 23);
            textBoxNombre.TabIndex = 7;
            // 
            // textBoxPrimerApellido
            // 
            textBoxPrimerApellido.Location = new Point(182, 162);
            textBoxPrimerApellido.Name = "textBoxPrimerApellido";
            textBoxPrimerApellido.Size = new Size(200, 23);
            textBoxPrimerApellido.TabIndex = 8;
            // 
            // textBoxSegundoApellido
            // 
            textBoxSegundoApellido.Location = new Point(182, 208);
            textBoxSegundoApellido.Name = "textBoxSegundoApellido";
            textBoxSegundoApellido.Size = new Size(200, 23);
            textBoxSegundoApellido.TabIndex = 9;
            // 
            // dateTimePickerFechaNacimiento
            // 
            dateTimePickerFechaNacimiento.Location = new Point(182, 258);
            dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            dateTimePickerFechaNacimiento.Size = new Size(200, 23);
            dateTimePickerFechaNacimiento.TabIndex = 10;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Si", "No" });
            cboEstado.Location = new Point(182, 304);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(200, 23);
            cboEstado.TabIndex = 11;
            cboEstado.SelectedIndexChanged += cboEstado_SelectedIndexChanged;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(208, 385);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 12;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(307, 385);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 13;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // labelAgregarCliente
            // 
            labelAgregarCliente.AutoSize = true;
            labelAgregarCliente.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAgregarCliente.Location = new Point(118, 9);
            labelAgregarCliente.Name = "labelAgregarCliente";
            labelAgregarCliente.Size = new Size(151, 25);
            labelAgregarCliente.TabIndex = 14;
            labelAgregarCliente.Text = "Agregar Cliente";
            // 
            // frmAgregarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 450);
            Controls.Add(labelAgregarCliente);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonAgregar);
            Controls.Add(cboEstado);
            Controls.Add(dateTimePickerFechaNacimiento);
            Controls.Add(textBoxSegundoApellido);
            Controls.Add(textBoxPrimerApellido);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxID);
            Controls.Add(labelEstado);
            Controls.Add(labelFechaNacimiento);
            Controls.Add(labelSegundoApellido);
            Controls.Add(labelPrimerApellido);
            Controls.Add(labelNombre);
            Controls.Add(labelIdentificacion);
            Name = "frmAgregarCliente";
            Text = "Agregar Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIdentificacion;
        private Label labelNombre;
        private Label labelPrimerApellido;
        private Label labelSegundoApellido;
        private Label labelFechaNacimiento;
        private Label labelEstado;
        private TextBox textBoxID;
        private TextBox textBoxNombre;
        private TextBox textBoxPrimerApellido;
        private TextBox textBoxSegundoApellido;
        private DateTimePicker dateTimePickerFechaNacimiento;
        private ComboBox cboEstado;
        private Button buttonAgregar;
        private Button buttonCerrar;
        private Label labelAgregarCliente;
    }
}