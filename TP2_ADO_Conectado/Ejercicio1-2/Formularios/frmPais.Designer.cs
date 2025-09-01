namespace Ejercicio1
{
    partial class frmPais
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
            grillaPaises = new DataGridView();
            label1 = new Label();
            btnAgregar = new Button();
            btnBorrar = new Button();
            btnModificar = new Button();
            btnConectar = new Button();
            btnDesconectar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaPaises).BeginInit();
            SuspendLayout();
            // 
            // grillaPaises
            // 
            grillaPaises.AllowUserToAddRows = false;
            grillaPaises.AllowUserToDeleteRows = false;
            grillaPaises.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPaises.Location = new Point(144, 63);
            grillaPaises.Name = "grillaPaises";
            grillaPaises.ReadOnly = true;
            grillaPaises.Size = new Size(464, 226);
            grillaPaises.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(144, 35);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "Países";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(144, 295);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(236, 295);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 3;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(326, 295);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(26, 117);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(92, 33);
            btnConectar.TabIndex = 5;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(26, 160);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(92, 33);
            btnDesconectar.TabIndex = 6;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(26, 199);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(92, 33);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmPais
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
            Controls.Add(grillaPaises);
            Name = "frmPais";
            Text = "Formulario de paises";
            Load += frmPais_Load;
            ((System.ComponentModel.ISupportInitialize)grillaPaises).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaPaises;
        private Label label1;
        private Button btnAgregar;
        private Button btnBorrar;
        private Button btnModificar;
        private Button btnConectar;
        private Button btnDesconectar;
        private Button btnSalir;
    }
}