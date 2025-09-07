namespace Ejercicio3.Formularios
{
    partial class frmOpciones
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
            cbxPreguntas = new ComboBox();
            btnSalir = new Button();
            btnModificar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            grillaOpciones = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaOpciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 289);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 32;
            label1.Text = "Seleccionar pregunta";
            // 
            // cbxPreguntas
            // 
            cbxPreguntas.FormattingEnabled = true;
            cbxPreguntas.Location = new Point(12, 307);
            cbxPreguntas.Name = "cbxPreguntas";
            cbxPreguntas.Size = new Size(295, 23);
            cbxPreguntas.TabIndex = 31;
            cbxPreguntas.SelectedIndexChanged += cbxPreguntas_SelectedIndexChanged;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(611, 242);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 30;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(195, 242);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 29;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(103, 242);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 28;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 242);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 27;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // grillaOpciones
            // 
            grillaOpciones.AllowUserToAddRows = false;
            grillaOpciones.AllowUserToDeleteRows = false;
            grillaOpciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaOpciones.Location = new Point(12, 12);
            grillaOpciones.Name = "grillaOpciones";
            grillaOpciones.ReadOnly = true;
            grillaOpciones.Size = new Size(674, 224);
            grillaOpciones.TabIndex = 26;
            // 
            // frmOpciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 362);
            Controls.Add(label1);
            Controls.Add(cbxPreguntas);
            Controls.Add(btnSalir);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaOpciones);
            Name = "frmOpciones";
            Text = "frmOpciones";
            Load += frmOpciones_Load;
            ((System.ComponentModel.ISupportInitialize)grillaOpciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbxPreguntas;
        private Button btnSalir;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
        private DataGridView grillaOpciones;
    }
}