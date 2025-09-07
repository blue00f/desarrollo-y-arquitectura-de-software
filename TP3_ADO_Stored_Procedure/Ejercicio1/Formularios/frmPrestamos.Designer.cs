namespace Ejercicio1.Formularios
{
    partial class frmPrestamos
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
            cbxAlumnos = new ComboBox();
            btnSalir = new Button();
            btnModificar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            grillaPrestamos = new DataGridView();
            cbxEjemplares = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaPrestamos).BeginInit();
            SuspendLayout();
            // 
            // cbxAlumnos
            // 
            cbxAlumnos.FormattingEnabled = true;
            cbxAlumnos.Location = new Point(12, 313);
            cbxAlumnos.Name = "cbxAlumnos";
            cbxAlumnos.Size = new Size(269, 23);
            cbxAlumnos.TabIndex = 21;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(636, 253);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 20;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(195, 253);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 19;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(103, 253);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 18;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 253);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 17;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // grillaPrestamos
            // 
            grillaPrestamos.AllowUserToAddRows = false;
            grillaPrestamos.AllowUserToDeleteRows = false;
            grillaPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPrestamos.Location = new Point(12, 23);
            grillaPrestamos.Name = "grillaPrestamos";
            grillaPrestamos.ReadOnly = true;
            grillaPrestamos.Size = new Size(699, 224);
            grillaPrestamos.TabIndex = 16;
            // 
            // cbxEjemplares
            // 
            cbxEjemplares.FormattingEnabled = true;
            cbxEjemplares.Location = new Point(313, 313);
            cbxEjemplares.Name = "cbxEjemplares";
            cbxEjemplares.Size = new Size(398, 23);
            cbxEjemplares.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 295);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 23;
            label1.Text = "Alumno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 295);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 24;
            label2.Text = "Ejemplares";
            // 
            // frmPrestamos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 348);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbxEjemplares);
            Controls.Add(cbxAlumnos);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaPrestamos);
            Name = "frmPrestamos";
            Text = "frmPrestamos";
            Load += frmPrestamos_Load;
            ((System.ComponentModel.ISupportInitialize)grillaPrestamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxAlumnos;
        private Button btnSalir;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private DataGridView grillaPrestamos;
        private ComboBox cbxEjemplares;
        private Label label1;
        private Label label2;
    }
}