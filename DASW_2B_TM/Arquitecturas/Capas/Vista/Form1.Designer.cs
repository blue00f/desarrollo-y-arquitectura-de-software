namespace Vista
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
            grillaPrestamos = new DataGridView();
            btnAltaPrestamo = new Button();
            txtInfoPersona = new TextBox();
            btnBajaPrestamo = new Button();
            btnModificarPrestamo = new Button();
            grillaConsultas = new DataGridView();
            btnConsultarCodigo = new Button();
            label1 = new Label();
            radIncremental = new RadioButton();
            radDesdeHasta = new RadioButton();
            radBusquedaNormal = new RadioButton();
            txtConsultaPorCodigo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaPrestamos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaConsultas).BeginInit();
            SuspendLayout();
            // 
            // grillaPrestamos
            // 
            grillaPrestamos.AllowUserToAddRows = false;
            grillaPrestamos.AllowUserToDeleteRows = false;
            grillaPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPrestamos.Location = new Point(12, 46);
            grillaPrestamos.Name = "grillaPrestamos";
            grillaPrestamos.ReadOnly = true;
            grillaPrestamos.Size = new Size(1442, 150);
            grillaPrestamos.TabIndex = 0;
            grillaPrestamos.RowEnter += grillaPrestamos_RowEnter;
            // 
            // btnAltaPrestamo
            // 
            btnAltaPrestamo.Location = new Point(12, 202);
            btnAltaPrestamo.Name = "btnAltaPrestamo";
            btnAltaPrestamo.Size = new Size(87, 23);
            btnAltaPrestamo.TabIndex = 1;
            btnAltaPrestamo.Text = "Alta";
            btnAltaPrestamo.UseVisualStyleBackColor = true;
            btnAltaPrestamo.Click += btnAltaPrestamo_Click;
            // 
            // txtInfoPersona
            // 
            txtInfoPersona.Location = new Point(1162, 15);
            txtInfoPersona.Name = "txtInfoPersona";
            txtInfoPersona.Size = new Size(292, 23);
            txtInfoPersona.TabIndex = 2;
            // 
            // btnBajaPrestamo
            // 
            btnBajaPrestamo.Location = new Point(105, 202);
            btnBajaPrestamo.Name = "btnBajaPrestamo";
            btnBajaPrestamo.Size = new Size(87, 23);
            btnBajaPrestamo.TabIndex = 3;
            btnBajaPrestamo.Text = "Baja";
            btnBajaPrestamo.UseVisualStyleBackColor = true;
            btnBajaPrestamo.Click += btnBajaPrestamo_Click;
            // 
            // btnModificarPrestamo
            // 
            btnModificarPrestamo.Location = new Point(198, 202);
            btnModificarPrestamo.Name = "btnModificarPrestamo";
            btnModificarPrestamo.Size = new Size(87, 23);
            btnModificarPrestamo.TabIndex = 4;
            btnModificarPrestamo.Text = "Modificacion";
            btnModificarPrestamo.UseVisualStyleBackColor = true;
            btnModificarPrestamo.Click += btnModificarPrestamo_Click;
            // 
            // grillaConsultas
            // 
            grillaConsultas.AllowUserToAddRows = false;
            grillaConsultas.AllowUserToDeleteRows = false;
            grillaConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaConsultas.Location = new Point(12, 316);
            grillaConsultas.Name = "grillaConsultas";
            grillaConsultas.ReadOnly = true;
            grillaConsultas.Size = new Size(1442, 150);
            grillaConsultas.TabIndex = 5;
            // 
            // btnConsultarCodigo
            // 
            btnConsultarCodigo.Location = new Point(651, 202);
            btnConsultarCodigo.Name = "btnConsultarCodigo";
            btnConsultarCodigo.Size = new Size(141, 23);
            btnConsultarCodigo.TabIndex = 6;
            btnConsultarCodigo.Text = "Consultar código";
            btnConsultarCodigo.UseVisualStyleBackColor = true;
            btnConsultarCodigo.Click += btnConsultarCodigo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 288);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 7;
            label1.Text = "Consultas";
            // 
            // radIncremental
            // 
            radIncremental.AutoSize = true;
            radIncremental.Location = new Point(821, 202);
            radIncremental.Name = "radIncremental";
            radIncremental.Size = new Size(143, 19);
            radIncremental.TabIndex = 8;
            radIncremental.Text = "Búsqueda incremental";
            radIncremental.UseVisualStyleBackColor = true;
            radIncremental.CheckedChanged += radIncremental_CheckedChanged;
            // 
            // radDesdeHasta
            // 
            radDesdeHasta.AutoSize = true;
            radDesdeHasta.Location = new Point(821, 227);
            radDesdeHasta.Name = "radDesdeHasta";
            radDesdeHasta.Size = new Size(147, 19);
            radDesdeHasta.TabIndex = 9;
            radDesdeHasta.Text = "Búsqueda Desde/Hasta";
            radDesdeHasta.UseVisualStyleBackColor = true;
            // 
            // radBusquedaNormal
            // 
            radBusquedaNormal.AutoSize = true;
            radBusquedaNormal.Checked = true;
            radBusquedaNormal.Location = new Point(821, 252);
            radBusquedaNormal.Name = "radBusquedaNormal";
            radBusquedaNormal.Size = new Size(65, 19);
            radBusquedaNormal.TabIndex = 10;
            radBusquedaNormal.TabStop = true;
            radBusquedaNormal.Text = "Normal";
            radBusquedaNormal.UseVisualStyleBackColor = true;
            // 
            // txtConsultaPorCodigo
            // 
            txtConsultaPorCodigo.Location = new Point(651, 235);
            txtConsultaPorCodigo.Name = "txtConsultaPorCodigo";
            txtConsultaPorCodigo.Size = new Size(141, 23);
            txtConsultaPorCodigo.TabIndex = 11;
            txtConsultaPorCodigo.TextChanged += txtConsultaPorCodigo_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(582, 238);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 12;
            label2.Text = "Consulta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 13;
            label3.Text = "Préstamos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1008, 18);
            label4.Name = "label4";
            label4.Size = new Size(148, 15);
            label4.TabIndex = 14;
            label4.Text = "Información de la persona:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1466, 478);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtConsultaPorCodigo);
            Controls.Add(radBusquedaNormal);
            Controls.Add(radDesdeHasta);
            Controls.Add(radIncremental);
            Controls.Add(label1);
            Controls.Add(btnConsultarCodigo);
            Controls.Add(grillaConsultas);
            Controls.Add(btnModificarPrestamo);
            Controls.Add(btnBajaPrestamo);
            Controls.Add(txtInfoPersona);
            Controls.Add(btnAltaPrestamo);
            Controls.Add(grillaPrestamos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaPrestamos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaConsultas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaPrestamos;
        private Button btnAltaPrestamo;
        private TextBox txtInfoPersona;
        private Button btnBajaPrestamo;
        private Button btnModificarPrestamo;
        private DataGridView grillaConsultas;
        private Button btnConsultarCodigo;
        private Label label1;
        private RadioButton radIncremental;
        private RadioButton radDesdeHasta;
        private RadioButton radBusquedaNormal;
        private TextBox txtConsultaPorCodigo;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
