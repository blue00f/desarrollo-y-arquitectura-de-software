namespace Ejercicio1
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
            grillaAlumnos = new DataGridView();
            grillaMateriasCursando = new DataGridView();
            grillaMateriasAprobadas = new DataGridView();
            grillaMateriasPendientes = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtPromedioAplazo = new TextBox();
            txtPromedioSinAplazo = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnGuardarEnXml = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaAlumnos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaMateriasCursando).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaMateriasAprobadas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaMateriasPendientes).BeginInit();
            SuspendLayout();
            // 
            // grillaAlumnos
            // 
            grillaAlumnos.AllowUserToAddRows = false;
            grillaAlumnos.AllowUserToDeleteRows = false;
            grillaAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAlumnos.Location = new Point(12, 48);
            grillaAlumnos.Name = "grillaAlumnos";
            grillaAlumnos.ReadOnly = true;
            grillaAlumnos.Size = new Size(438, 150);
            grillaAlumnos.TabIndex = 0;
            grillaAlumnos.RowEnter += grillaAlumnos_RowEnter;
            // 
            // grillaMateriasCursando
            // 
            grillaMateriasCursando.AllowUserToAddRows = false;
            grillaMateriasCursando.AllowUserToDeleteRows = false;
            grillaMateriasCursando.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaMateriasCursando.Location = new Point(12, 242);
            grillaMateriasCursando.Name = "grillaMateriasCursando";
            grillaMateriasCursando.ReadOnly = true;
            grillaMateriasCursando.Size = new Size(438, 150);
            grillaMateriasCursando.TabIndex = 1;
            // 
            // grillaMateriasAprobadas
            // 
            grillaMateriasAprobadas.AllowUserToAddRows = false;
            grillaMateriasAprobadas.AllowUserToDeleteRows = false;
            grillaMateriasAprobadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaMateriasAprobadas.Location = new Point(481, 48);
            grillaMateriasAprobadas.Name = "grillaMateriasAprobadas";
            grillaMateriasAprobadas.ReadOnly = true;
            grillaMateriasAprobadas.Size = new Size(438, 150);
            grillaMateriasAprobadas.TabIndex = 2;
            // 
            // grillaMateriasPendientes
            // 
            grillaMateriasPendientes.AllowUserToAddRows = false;
            grillaMateriasPendientes.AllowUserToDeleteRows = false;
            grillaMateriasPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaMateriasPendientes.Location = new Point(481, 242);
            grillaMateriasPendientes.Name = "grillaMateriasPendientes";
            grillaMateriasPendientes.ReadOnly = true;
            grillaMateriasPendientes.Size = new Size(438, 150);
            grillaMateriasPendientes.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 4;
            label1.Text = "Alumnos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 214);
            label2.Name = "label2";
            label2.Size = new Size(255, 25);
            label2.TabIndex = 5;
            label2.Text = "Materias que está cursando";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(481, 20);
            label3.Name = "label3";
            label3.Size = new Size(187, 25);
            label3.TabIndex = 6;
            label3.Text = "Materias aprobadas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(481, 214);
            label4.Name = "label4";
            label4.Size = new Size(191, 25);
            label4.TabIndex = 7;
            label4.Text = "Materias pendientes";
            // 
            // txtPromedioAplazo
            // 
            txtPromedioAplazo.Location = new Point(131, 423);
            txtPromedioAplazo.Name = "txtPromedioAplazo";
            txtPromedioAplazo.ReadOnly = true;
            txtPromedioAplazo.Size = new Size(136, 23);
            txtPromedioAplazo.TabIndex = 8;
            // 
            // txtPromedioSinAplazo
            // 
            txtPromedioSinAplazo.Location = new Point(130, 454);
            txtPromedioSinAplazo.Name = "txtPromedioSinAplazo";
            txtPromedioSinAplazo.ReadOnly = true;
            txtPromedioSinAplazo.Size = new Size(136, 23);
            txtPromedioSinAplazo.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 426);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 10;
            label5.Text = "Promedio general";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 457);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 11;
            label6.Text = "Promedio sin aplazo";
            // 
            // btnGuardarEnXml
            // 
            btnGuardarEnXml.Location = new Point(793, 426);
            btnGuardarEnXml.Name = "btnGuardarEnXml";
            btnGuardarEnXml.Size = new Size(126, 23);
            btnGuardarEnXml.TabIndex = 12;
            btnGuardarEnXml.Text = "Guardar en XML";
            btnGuardarEnXml.UseVisualStyleBackColor = true;
            btnGuardarEnXml.Click += btnGuardarEnXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 501);
            Controls.Add(btnGuardarEnXml);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtPromedioSinAplazo);
            Controls.Add(txtPromedioAplazo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(grillaMateriasPendientes);
            Controls.Add(grillaMateriasAprobadas);
            Controls.Add(grillaMateriasCursando);
            Controls.Add(grillaAlumnos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaAlumnos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaMateriasCursando).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaMateriasAprobadas).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaMateriasPendientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaAlumnos;
        private DataGridView grillaMateriasCursando;
        private DataGridView grillaMateriasAprobadas;
        private DataGridView grillaMateriasPendientes;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPromedioAplazo;
        private TextBox txtPromedioSinAplazo;
        private Label label5;
        private Label label6;
        private Button btnGuardarEnXml;
    }
}
