namespace Ejercicio3.Formularios
{
    partial class frmPreguntas
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
            label1 = new Label();
            cbxCategorias = new ComboBox();
            btnSalir = new Button();
            btnModificar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            grillaPreguntas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaPreguntas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 289);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 25;
            label1.Text = "Seleccionar categoría";
            // 
            // cbxCategorias
            // 
            cbxCategorias.FormattingEnabled = true;
            cbxCategorias.Location = new Point(12, 307);
            cbxCategorias.Name = "cbxCategorias";
            cbxCategorias.Size = new Size(295, 23);
            cbxCategorias.TabIndex = 24;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(611, 242);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 23;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(195, 242);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 22;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(103, 242);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 21;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 242);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // grillaPreguntas
            // 
            grillaPreguntas.AllowUserToAddRows = false;
            grillaPreguntas.AllowUserToDeleteRows = false;
            grillaPreguntas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPreguntas.Location = new Point(12, 12);
            grillaPreguntas.Name = "grillaPreguntas";
            grillaPreguntas.ReadOnly = true;
            grillaPreguntas.Size = new Size(674, 224);
            grillaPreguntas.TabIndex = 19;
            // 
            // frmPreguntas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 341);
            Controls.Add(label1);
            Controls.Add(cbxCategorias);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaPreguntas);
            Name = "frmPreguntas";
            Text = "frmPreguntas";
            Load += frmPreguntas_Load;
            ((System.ComponentModel.ISupportInitialize)grillaPreguntas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbxCategorias;
        private Button btnSalir;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private DataGridView grillaPreguntas;
    }
}