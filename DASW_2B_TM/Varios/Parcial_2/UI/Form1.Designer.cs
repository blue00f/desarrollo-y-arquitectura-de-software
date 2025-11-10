namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grillaEmpleados = new DataGridView();
            btnAgregar = new Button();
            btnBorrar = new Button();
            btnModificar = new Button();
            label1 = new Label();
            ucLegajo1 = new ControlesPersonalizados.ucLegajo();
            label2 = new Label();
            txtApellidoBusquedaIncremental = new TextBox();
            btnVerTodos = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaEmpleados).BeginInit();
            SuspendLayout();
            // 
            // grillaEmpleados
            // 
            grillaEmpleados.AllowUserToAddRows = false;
            grillaEmpleados.AllowUserToDeleteRows = false;
            grillaEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEmpleados.Location = new Point(26, 49);
            grillaEmpleados.Name = "grillaEmpleados";
            grillaEmpleados.ReadOnly = true;
            grillaEmpleados.Size = new Size(582, 150);
            grillaEmpleados.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(26, 205);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(107, 205);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(188, 205);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 21);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 4;
            label1.Text = "Empleados";
            // 
            // ucLegajo1
            // 
            ucLegajo1.Location = new Point(26, 256);
            ucLegajo1.Name = "ucLegajo1";
            ucLegajo1.Size = new Size(177, 51);
            ucLegajo1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(367, 208);
            label2.Name = "label2";
            label2.Size = new Size(241, 20);
            label2.TabIndex = 7;
            label2.Text = "Consulta incremental del apellido";
            // 
            // txtApellidoBusquedaIncremental
            // 
            txtApellidoBusquedaIncremental.Location = new Point(367, 231);
            txtApellidoBusquedaIncremental.Name = "txtApellidoBusquedaIncremental";
            txtApellidoBusquedaIncremental.Size = new Size(164, 23);
            txtApellidoBusquedaIncremental.TabIndex = 8;
            txtApellidoBusquedaIncremental.TextChanged += txtApellidoBusquedaIncremental_TextChanged;
            // 
            // btnVerTodos
            // 
            btnVerTodos.Location = new Point(367, 259);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(75, 23);
            btnVerTodos.TabIndex = 9;
            btnVerTodos.Text = "Ver todos";
            btnVerTodos.UseVisualStyleBackColor = true;
            btnVerTodos.Click += btnVerTodos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 338);
            Controls.Add(btnVerTodos);
            Controls.Add(txtApellidoBusquedaIncremental);
            Controls.Add(label2);
            Controls.Add(ucLegajo1);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaEmpleados);
            Name = "Form1";
            Text = "Sistema de gestión de empleados";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaEmpleados;
        private Button btnAgregar;
        private Button btnBorrar;
        private Button btnModificar;
        private Label label1;
        private ControlesPersonalizados.ucLegajo ucLegajo1;
        private Label label2;
        private TextBox txtApellidoBusquedaIncremental;
        private Button btnVerTodos;
    }
}
