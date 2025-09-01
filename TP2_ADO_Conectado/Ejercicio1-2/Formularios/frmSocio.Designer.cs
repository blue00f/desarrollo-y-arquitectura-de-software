namespace Ejercicio1
{
    partial class frmSocio
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
            grillaSocios = new DataGridView();
            grillaPaises = new DataGridView();
            grillaProvincias = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaSocios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaPaises).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaProvincias).BeginInit();
            SuspendLayout();
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(15, 264);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(92, 33);
            btnDesconectar.TabIndex = 13;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(15, 221);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(92, 33);
            btnConectar.TabIndex = 12;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(315, 399);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(225, 399);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 10;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(133, 399);
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
            label1.Location = new Point(133, 139);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 8;
            label1.Text = "Socio";
            // 
            // grillaSocios
            // 
            grillaSocios.AllowUserToAddRows = false;
            grillaSocios.AllowUserToDeleteRows = false;
            grillaSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaSocios.Location = new Point(133, 167);
            grillaSocios.Name = "grillaSocios";
            grillaSocios.ReadOnly = true;
            grillaSocios.Size = new Size(616, 226);
            grillaSocios.TabIndex = 7;
            // 
            // grillaPaises
            // 
            grillaPaises.AllowUserToAddRows = false;
            grillaPaises.AllowUserToDeleteRows = false;
            grillaPaises.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPaises.Location = new Point(782, 45);
            grillaPaises.Name = "grillaPaises";
            grillaPaises.ReadOnly = true;
            grillaPaises.Size = new Size(333, 226);
            grillaPaises.TabIndex = 14;
            // 
            // grillaProvincias
            // 
            grillaProvincias.AllowUserToAddRows = false;
            grillaProvincias.AllowUserToDeleteRows = false;
            grillaProvincias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaProvincias.Location = new Point(782, 317);
            grillaProvincias.Name = "grillaProvincias";
            grillaProvincias.ReadOnly = true;
            grillaProvincias.Size = new Size(333, 226);
            grillaProvincias.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(782, 17);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 16;
            label2.Text = "Países";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(782, 289);
            label3.Name = "label3";
            label3.Size = new Size(103, 25);
            label3.TabIndex = 17;
            label3.Text = "Provincias";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(15, 303);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(92, 33);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmSocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 577);
            Controls.Add(btnSalir);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(grillaProvincias);
            Controls.Add(grillaPaises);
            Controls.Add(btnDesconectar);
            Controls.Add(btnConectar);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(grillaSocios);
            Name = "frmSocio";
            Text = "Formulario de socios";
            Load += frmSocio_Load;
            ((System.ComponentModel.ISupportInitialize)grillaSocios).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaPaises).EndInit();
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
        private DataGridView grillaSocios;
        private DataGridView grillaPaises;
        private DataGridView grillaProvincias;
        private Label label2;
        private Label label3;
        private Button btnSalir;
    }
}