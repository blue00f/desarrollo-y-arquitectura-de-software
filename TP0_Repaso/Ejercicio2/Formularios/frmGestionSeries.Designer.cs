namespace Ejercicio2.Formularios
{
    partial class frmGestionSeries
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
            btnModificarSerie = new Button();
            btnBorrarSerie = new Button();
            btnAgregarSerie = new Button();
            grillaSeries = new DataGridView();
            label2 = new Label();
            cbxCanales = new ComboBox();
            label3 = new Label();
            cbxGeneros = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grillaSeries).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 33);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 14;
            label1.Text = "Series";
            // 
            // btnModificarSerie
            // 
            btnModificarSerie.Location = new Point(265, 305);
            btnModificarSerie.Name = "btnModificarSerie";
            btnModificarSerie.Size = new Size(75, 23);
            btnModificarSerie.TabIndex = 13;
            btnModificarSerie.Text = "Modificar";
            btnModificarSerie.UseVisualStyleBackColor = true;
            btnModificarSerie.Click += btnModificarSerie_Click;
            // 
            // btnBorrarSerie
            // 
            btnBorrarSerie.Location = new Point(164, 305);
            btnBorrarSerie.Name = "btnBorrarSerie";
            btnBorrarSerie.Size = new Size(75, 23);
            btnBorrarSerie.TabIndex = 12;
            btnBorrarSerie.Text = "Borrar";
            btnBorrarSerie.UseVisualStyleBackColor = true;
            btnBorrarSerie.Click += btnBorrarSerie_Click;
            // 
            // btnAgregarSerie
            // 
            btnAgregarSerie.Location = new Point(55, 305);
            btnAgregarSerie.Name = "btnAgregarSerie";
            btnAgregarSerie.Size = new Size(75, 23);
            btnAgregarSerie.TabIndex = 11;
            btnAgregarSerie.Text = "Agregar";
            btnAgregarSerie.UseVisualStyleBackColor = true;
            btnAgregarSerie.Click += btnAgregarSerie_Click;
            // 
            // grillaSeries
            // 
            grillaSeries.AllowUserToAddRows = false;
            grillaSeries.AllowUserToDeleteRows = false;
            grillaSeries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaSeries.Location = new Point(55, 61);
            grillaSeries.Name = "grillaSeries";
            grillaSeries.ReadOnly = true;
            grillaSeries.Size = new Size(674, 238);
            grillaSeries.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(473, 309);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 16;
            label2.Text = "Canal";
            // 
            // cbxCanales
            // 
            cbxCanales.FormattingEnabled = true;
            cbxCanales.Location = new Point(529, 305);
            cbxCanales.Name = "cbxCanales";
            cbxCanales.Size = new Size(200, 23);
            cbxCanales.TabIndex = 15;
            cbxCanales.SelectedIndexChanged += cbxCanales_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 333);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 18;
            label3.Text = "Genero";
            // 
            // cbxGeneros
            // 
            cbxGeneros.FormattingEnabled = true;
            cbxGeneros.Location = new Point(106, 330);
            cbxGeneros.Name = "cbxGeneros";
            cbxGeneros.Size = new Size(234, 23);
            cbxGeneros.TabIndex = 17;
            // 
            // frmGestionSeries
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(label3);
            Controls.Add(cbxGeneros);
            Controls.Add(label2);
            Controls.Add(cbxCanales);
            Controls.Add(label1);
            Controls.Add(btnModificarSerie);
            Controls.Add(btnBorrarSerie);
            Controls.Add(btnAgregarSerie);
            Controls.Add(grillaSeries);
            Name = "frmGestionSeries";
            Text = "Gestión de series";
            Load += frmGestionSeries_Load;
            ((System.ComponentModel.ISupportInitialize)grillaSeries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnModificarSerie;
        private Button btnBorrarSerie;
        private Button btnAgregarSerie;
        private DataGridView grillaSeries;
        private Label label2;
        private ComboBox cbxCanales;
        private Label label3;
        private ComboBox cbxGeneros;
    }
}