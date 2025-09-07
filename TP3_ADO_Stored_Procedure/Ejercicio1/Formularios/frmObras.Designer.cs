namespace Ejercicio1.Formularios
{
    partial class frmObras
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
            btnSalir = new Button();
            btnModificar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            grillaObras = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaObras).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(620, 257);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(204, 257);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(112, 257);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(21, 257);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // grillaObras
            // 
            grillaObras.AllowUserToAddRows = false;
            grillaObras.AllowUserToDeleteRows = false;
            grillaObras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaObras.Location = new Point(21, 27);
            grillaObras.Name = "grillaObras";
            grillaObras.ReadOnly = true;
            grillaObras.Size = new Size(674, 224);
            grillaObras.TabIndex = 5;
            // 
            // frmObras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 294);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaObras);
            Name = "frmObras";
            Text = "frmObras";
            Load += frmObras_Load;
            ((System.ComponentModel.ISupportInitialize)grillaObras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private DataGridView grillaObras;
    }
}