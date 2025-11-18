#region Descripción
/**
 * UNED 2do Cuatrimestre 2025
 * Proyecto 1: Programa de Entregas
 * Estudiante: Johel Smaiker Granados Elizondo
 * Fecha: 15/06/2025
 * Referencias:
 * 00830 I Sesión Virtual Programación Avanzada- II Cuatrimestre 2025- Tutor Johan Acosta I https://www.youtube.com/watch?v=2IWiBqwDgKM&t=5835s
 * (Deitel, 2007) Deitel, H. M.  (2007). Cómo programar en C#,  2nd Edition. [[VitalSource Bookshelf version]].  Retrieved from vbk://9789702610564
 */
#endregion
namespace CapaDePresentacion
{
    partial class frmAgregarRepartidor
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
            dateTimePickerFechaNacimiento = new DateTimePicker();
            dateTimePickerFechaContratacion = new DateTimePicker();
            labelFechaNacimiento = new Label();
            label5 = new Label();
            textBoxNombre = new TextBox();
            textBoxPrimerApellido = new TextBox();
            textBoxSegundoApellido = new TextBox();
            buttonAgregar = new Button();
            buttonCerrar = new Button();
            textBoxID = new TextBox();
            label1 = new Label();
            labelActivo = new Label();
            checkBoxActivo = new CheckBox();
            SuspendLayout();
            // 
            // labelIdentificacion
            // 
            labelIdentificacion.AutoSize = true;
            labelIdentificacion.Location = new Point(30, 62);
            labelIdentificacion.Name = "labelIdentificacion";
            labelIdentificacion.Size = new Size(79, 15);
            labelIdentificacion.TabIndex = 0;
            labelIdentificacion.Text = "Identificacion";
            labelIdentificacion.Click += label1_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(30, 99);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 2;
            labelNombre.Text = "Nombre";
            // 
            // labelPrimerApellido
            // 
            labelPrimerApellido.AutoSize = true;
            labelPrimerApellido.Location = new Point(30, 136);
            labelPrimerApellido.Name = "labelPrimerApellido";
            labelPrimerApellido.Size = new Size(89, 15);
            labelPrimerApellido.TabIndex = 3;
            labelPrimerApellido.Text = "Primer Apellido";
            // 
            // labelSegundoApellido
            // 
            labelSegundoApellido.AutoSize = true;
            labelSegundoApellido.Location = new Point(30, 177);
            labelSegundoApellido.Name = "labelSegundoApellido";
            labelSegundoApellido.Size = new Size(101, 15);
            labelSegundoApellido.TabIndex = 4;
            labelSegundoApellido.Text = "Segundo Apellido";
            // 
            // dateTimePickerFechaNacimiento
            // 
            dateTimePickerFechaNacimiento.Location = new Point(155, 219);
            dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            dateTimePickerFechaNacimiento.Size = new Size(200, 23);
            dateTimePickerFechaNacimiento.TabIndex = 5;
            // 
            // dateTimePickerFechaContratacion
            // 
            dateTimePickerFechaContratacion.Location = new Point(155, 265);
            dateTimePickerFechaContratacion.Name = "dateTimePickerFechaContratacion";
            dateTimePickerFechaContratacion.Size = new Size(200, 23);
            dateTimePickerFechaContratacion.TabIndex = 6;
            // 
            // labelFechaNacimiento
            // 
            labelFechaNacimiento.AutoSize = true;
            labelFechaNacimiento.Location = new Point(30, 225);
            labelFechaNacimiento.Name = "labelFechaNacimiento";
            labelFechaNacimiento.Size = new Size(119, 15);
            labelFechaNacimiento.TabIndex = 7;
            labelFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 271);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 8;
            label5.Text = "Fecha de contratacion";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(155, 91);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(200, 23);
            textBoxNombre.TabIndex = 9;
            // 
            // textBoxPrimerApellido
            // 
            textBoxPrimerApellido.Location = new Point(155, 128);
            textBoxPrimerApellido.Name = "textBoxPrimerApellido";
            textBoxPrimerApellido.Size = new Size(200, 23);
            textBoxPrimerApellido.TabIndex = 10;
            // 
            // textBoxSegundoApellido
            // 
            textBoxSegundoApellido.Location = new Point(155, 169);
            textBoxSegundoApellido.Name = "textBoxSegundoApellido";
            textBoxSegundoApellido.Size = new Size(200, 23);
            textBoxSegundoApellido.TabIndex = 11;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(200, 394);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 12;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(281, 394);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 13;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(155, 57);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(200, 23);
            textBoxID.TabIndex = 14;
            textBoxID.TextChanged += textBoxID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(105, 9);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 15;
            label1.Text = "Agregar Repartidor";
            // 
            // labelActivo
            // 
            labelActivo.AutoSize = true;
            labelActivo.Location = new Point(30, 314);
            labelActivo.Name = "labelActivo";
            labelActivo.Size = new Size(41, 15);
            labelActivo.TabIndex = 16;
            labelActivo.Text = "Activo";
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.AutoSize = true;
            checkBoxActivo.Location = new Point(155, 310);
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.Size = new Size(56, 19);
            checkBoxActivo.TabIndex = 17;
            checkBoxActivo.Text = "Si/No";
            checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // frmAgregarRepartidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 429);
            Controls.Add(checkBoxActivo);
            Controls.Add(labelActivo);
            Controls.Add(label1);
            Controls.Add(textBoxID);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonAgregar);
            Controls.Add(textBoxSegundoApellido);
            Controls.Add(textBoxPrimerApellido);
            Controls.Add(textBoxNombre);
            Controls.Add(label5);
            Controls.Add(labelFechaNacimiento);
            Controls.Add(dateTimePickerFechaContratacion);
            Controls.Add(dateTimePickerFechaNacimiento);
            Controls.Add(labelSegundoApellido);
            Controls.Add(labelPrimerApellido);
            Controls.Add(labelNombre);
            Controls.Add(labelIdentificacion);
            Name = "frmAgregarRepartidor";
            Text = "Agregar Repartidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIdentificacion;        
        private Label labelNombre;
        private Label labelPrimerApellido;
        private Label labelSegundoApellido;
        private DateTimePicker dateTimePickerFechaNacimiento;
        private DateTimePicker dateTimePickerFechaContratacion;
        private Label labelFechaNacimiento;
        private Label label5;
        private TextBox textBoxNombre;
        private TextBox textBoxPrimerApellido;
        private TextBox textBoxSegundoApellido;
        private Button buttonAgregar;
        private Button buttonCerrar;
        private TextBox textBoxID;
        private Label label1;
        private Label labelActivo;
        private CheckBox checkBoxActivo;
    }
}