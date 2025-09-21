namespace HospitalDemo
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtFechaNacimiento = new TextBox();
            label4 = new Label();
            btnSalir = new Button();
            label5 = new Label();
            lstHospitales = new ListBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 35);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 0;
            label1.Text = "DATOS PACIENTE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 134);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 176);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha de nacimiento";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.Location = new Point(167, 89);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            txtNombre.Text = "Homero";
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.Location = new Point(167, 131);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 4;
            txtApellido.Text = "Simpsons";
            // 
            // txtFechaNacimiento
            // 
            txtFechaNacimiento.BackColor = Color.White;
            txtFechaNacimiento.Location = new Point(167, 173);
            txtFechaNacimiento.Name = "txtFechaNacimiento";
            txtFechaNacimiento.ReadOnly = true;
            txtFechaNacimiento.Size = new Size(100, 23);
            txtFechaNacimiento.TabIndex = 5;
            txtFechaNacimiento.Text = "1956-05-12";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 92);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Nombre";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.PaleTurquoise;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(93, 239);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(117, 35);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(320, 35);
            label5.Name = "label5";
            label5.Size = new Size(124, 25);
            label5.TabIndex = 8;
            label5.Text = "HOSPITALES";
            // 
            // lstHospitales
            // 
            lstHospitales.FormattingEnabled = true;
            lstHospitales.ItemHeight = 15;
            lstHospitales.Location = new Point(320, 92);
            lstHospitales.Name = "lstHospitales";
            lstHospitales.Size = new Size(306, 169);
            lstHospitales.TabIndex = 9;
            lstHospitales.DoubleClick += lstHospitales_DoubleClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(320, 264);
            label6.Name = "label6";
            label6.Size = new Size(226, 15);
            label6.TabIndex = 10;
            label6.Text = "Haga doble click para ver las indicaciones";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(668, 319);
            Controls.Add(label6);
            Controls.Add(lstHospitales);
            Controls.Add(label5);
            Controls.Add(btnSalir);
            Controls.Add(label4);
            Controls.Add(txtFechaNacimiento);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Menu";
            Text = "InfoSalud";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtFechaNacimiento;
        private Label label4;
        private Button btnSalir;
        private Label label5;
        private ListBox lstHospitales;
        private Label label6;
    }
}
