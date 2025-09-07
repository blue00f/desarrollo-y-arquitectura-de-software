namespace Ejercicio1.Formularios
{
    partial class frmAlumnos
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
            grillaAlumnos = new DataGridView();
            btnAgregar = new Button();
            btnBorrar = new Button();
            btnModificar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaAlumnos).BeginInit();
            SuspendLayout();
            // 
            // grillaAlumnos
            // 
            grillaAlumnos.AllowUserToAddRows = false;
            grillaAlumnos.AllowUserToDeleteRows = false;
            grillaAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAlumnos.Location = new Point(12, 33);
            grillaAlumnos.Name = "grillaAlumnos";
            grillaAlumnos.ReadOnly = true;
            grillaAlumnos.Size = new Size(674, 224);
            grillaAlumnos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 263);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(103, 263);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(195, 263);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(611, 263);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmAlumnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 310);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaAlumnos);
            Name = "frmAlumnos";
            Text = "frmAlumnos";
            Load += frmAlumnos_Load;
            ((System.ComponentModel.ISupportInitialize)grillaAlumnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grillaAlumnos;
        private Button btnAgregar;
        private Button btnBorrar;
        private Button btnModificar;
        private Button btnSalir;
    }
}