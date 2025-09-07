namespace Ejercicio2.Formularios
{
    partial class frmVehiculos
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
            grillaVehiculos = new DataGridView();
            cbxPropietarios = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaVehiculos).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(611, 242);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(195, 242);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(103, 242);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 12;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 242);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // grillaVehiculos
            // 
            grillaVehiculos.AllowUserToAddRows = false;
            grillaVehiculos.AllowUserToDeleteRows = false;
            grillaVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaVehiculos.Location = new Point(12, 12);
            grillaVehiculos.Name = "grillaVehiculos";
            grillaVehiculos.ReadOnly = true;
            grillaVehiculos.Size = new Size(674, 224);
            grillaVehiculos.TabIndex = 10;
            // 
            // cbxPropietarios
            // 
            cbxPropietarios.FormattingEnabled = true;
            cbxPropietarios.Location = new Point(12, 307);
            cbxPropietarios.Name = "cbxPropietarios";
            cbxPropietarios.Size = new Size(295, 23);
            cbxPropietarios.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 289);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 16;
            label1.Text = "Seleccionar propietario";
            // 
            // frmVehiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 342);
            Controls.Add(label1);
            Controls.Add(cbxPropietarios);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaVehiculos);
            Name = "frmVehiculos";
            Text = "frmVehiculos";
            Load += frmVehiculos_Load;
            ((System.ComponentModel.ISupportInitialize)grillaVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private DataGridView grillaVehiculos;
        private ComboBox cbxPropietarios;
        private Label label1;
    }
}