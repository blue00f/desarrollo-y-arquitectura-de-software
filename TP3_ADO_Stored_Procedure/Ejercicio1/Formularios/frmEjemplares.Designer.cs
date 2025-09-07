namespace Ejercicio1.Formularios
{
    partial class frmEjemplares
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
            grillaEjemplares = new DataGridView();
            cbxObras = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grillaEjemplares).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(622, 252);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(206, 252);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(114, 252);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 12;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 252);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // grillaEjemplares
            // 
            grillaEjemplares.AllowUserToAddRows = false;
            grillaEjemplares.AllowUserToDeleteRows = false;
            grillaEjemplares.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEjemplares.Location = new Point(23, 22);
            grillaEjemplares.Name = "grillaEjemplares";
            grillaEjemplares.ReadOnly = true;
            grillaEjemplares.Size = new Size(674, 224);
            grillaEjemplares.TabIndex = 10;
            // 
            // cbxObras
            // 
            cbxObras.FormattingEnabled = true;
            cbxObras.Location = new Point(327, 252);
            cbxObras.Name = "cbxObras";
            cbxObras.Size = new Size(269, 23);
            cbxObras.TabIndex = 15;
            // 
            // frmEjemplares
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 292);
            Controls.Add(cbxObras);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaEjemplares);
            Name = "frmEjemplares";
            Text = "frmEjemplares";
            Load += frmEjemplares_Load;
            ((System.ComponentModel.ISupportInitialize)grillaEjemplares).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private DataGridView grillaEjemplares;
        private ComboBox cbxObras;
    }
}