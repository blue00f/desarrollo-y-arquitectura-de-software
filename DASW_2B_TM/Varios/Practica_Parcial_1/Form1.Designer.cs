namespace Practica_Parcial_1
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
            grillaAutos = new DataGridView();
            btnAgregar = new Button();
            btnBorrar = new Button();
            btnModificar = new Button();
            label1 = new Label();
            grillaAutosDadosDeBaja = new DataGridView();
            grillaAutosIncremental = new DataGridView();
            txtConsultaIncrementalPatente = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnGuardarEnXml = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaAutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaAutosDadosDeBaja).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaAutosIncremental).BeginInit();
            SuspendLayout();
            // 
            // grillaAutos
            // 
            grillaAutos.AllowUserToAddRows = false;
            grillaAutos.AllowUserToDeleteRows = false;
            grillaAutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAutos.Location = new Point(28, 54);
            grillaAutos.Name = "grillaAutos";
            grillaAutos.ReadOnly = true;
            grillaAutos.Size = new Size(657, 150);
            grillaAutos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(28, 210);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(109, 210);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(190, 210);
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
            label1.Location = new Point(28, 26);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 4;
            label1.Text = "Autos";
            // 
            // grillaAutosDadosDeBaja
            // 
            grillaAutosDadosDeBaja.AllowUserToAddRows = false;
            grillaAutosDadosDeBaja.AllowUserToDeleteRows = false;
            grillaAutosDadosDeBaja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAutosDadosDeBaja.Location = new Point(28, 303);
            grillaAutosDadosDeBaja.Name = "grillaAutosDadosDeBaja";
            grillaAutosDadosDeBaja.ReadOnly = true;
            grillaAutosDadosDeBaja.Size = new Size(657, 150);
            grillaAutosDadosDeBaja.TabIndex = 5;
            // 
            // grillaAutosIncremental
            // 
            grillaAutosIncremental.AllowUserToAddRows = false;
            grillaAutosIncremental.AllowUserToDeleteRows = false;
            grillaAutosIncremental.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAutosIncremental.Location = new Point(712, 54);
            grillaAutosIncremental.Name = "grillaAutosIncremental";
            grillaAutosIncremental.ReadOnly = true;
            grillaAutosIncremental.Size = new Size(657, 150);
            grillaAutosIncremental.TabIndex = 6;
            // 
            // txtConsultaIncrementalPatente
            // 
            txtConsultaIncrementalPatente.Location = new Point(712, 211);
            txtConsultaIncrementalPatente.Name = "txtConsultaIncrementalPatente";
            txtConsultaIncrementalPatente.Size = new Size(264, 23);
            txtConsultaIncrementalPatente.TabIndex = 7;
            txtConsultaIncrementalPatente.TextChanged += txtConsultaIncrementalPatente_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(712, 26);
            label2.Name = "label2";
            label2.Size = new Size(310, 25);
            label2.TabIndex = 8;
            label2.Text = "Consulta incremental por patente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 275);
            label3.Name = "label3";
            label3.Size = new Size(750, 25);
            label3.TabIndex = 9;
            label3.Text = "Cantidad de días que estuvo el auto en la organización ordenado ascendentemente";
            // 
            // btnGuardarEnXml
            // 
            btnGuardarEnXml.Location = new Point(712, 430);
            btnGuardarEnXml.Name = "btnGuardarEnXml";
            btnGuardarEnXml.Size = new Size(116, 23);
            btnGuardarEnXml.TabIndex = 10;
            btnGuardarEnXml.Text = "Guardar en XML";
            btnGuardarEnXml.UseVisualStyleBackColor = true;
            btnGuardarEnXml.Click += btnGuardarEnXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1389, 479);
            Controls.Add(btnGuardarEnXml);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtConsultaIncrementalPatente);
            Controls.Add(grillaAutosIncremental);
            Controls.Add(grillaAutosDadosDeBaja);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaAutos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaAutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaAutosDadosDeBaja).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaAutosIncremental).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaAutos;
        private Button btnAgregar;
        private Button btnBorrar;
        private Button btnModificar;
        private Label label1;
        private DataGridView grillaAutosDadosDeBaja;
        private DataGridView grillaAutosIncremental;
        private TextBox txtConsultaIncrementalPatente;
        private Label label2;
        private Label label3;
        private Button btnGuardarEnXml;
    }
}
