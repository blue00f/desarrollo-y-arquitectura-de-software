namespace Ejercicio1
{
    partial class frmProvincia
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
            btnDesconectar = new Button();
            btnConectar = new Button();
            btnModificar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            label1 = new Label();
            grillaProvincias = new DataGridView();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaProvincias).BeginInit();
            SuspendLayout();
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(18, 166);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(92, 33);
            btnDesconectar.TabIndex = 13;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(18, 123);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(92, 33);
            btnConectar.TabIndex = 12;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(318, 301);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(228, 301);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 10;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(136, 301);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(136, 41);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 8;
            label1.Text = "Provincias";
            // 
            // grillaProvincias
            // 
            grillaProvincias.AllowUserToAddRows = false;
            grillaProvincias.AllowUserToDeleteRows = false;
            grillaProvincias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaProvincias.Location = new Point(136, 69);
            grillaProvincias.Name = "grillaProvincias";
            grillaProvincias.ReadOnly = true;
            grillaProvincias.Size = new Size(464, 226);
            grillaProvincias.TabIndex = 7;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(18, 205);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(92, 33);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmProvincia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 368);
            Controls.Add(btnSalir);
            Controls.Add(btnDesconectar);
            Controls.Add(btnConectar);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(grillaProvincias);
            Name = "frmProvincia";
            Text = "Formulario de provincias";
            Load += frmProvincia_Load;
            ((System.ComponentModel.ISupportInitialize)grillaProvincias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDesconectar;
        private Button btnConectar;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private Label label1;
        private DataGridView grillaProvincias;
        private Button btnSalir;
    }
}