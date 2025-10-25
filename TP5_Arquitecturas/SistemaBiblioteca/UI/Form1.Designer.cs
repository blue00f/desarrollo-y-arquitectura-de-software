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
            grillaSocios = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            grillaLibros = new DataGridView();
            label3 = new Label();
            grillaPrestamos = new DataGridView();
            btnAgregarSocio = new Button();
            btnBorrarSocio = new Button();
            btnModificarSocio = new Button();
            btnModificarLibro = new Button();
            btnBorrarLibro = new Button();
            btnAgregarLibro = new Button();
            btnCrearPrestamo = new Button();
            btnModificarPrestamo = new Button();
            btnBorrar = new Button();
            btnExportarPdfGraphics = new Button();
            btnExportarPdfGrid = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaSocios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaLibros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaPrestamos).BeginInit();
            SuspendLayout();
            // 
            // grillaSocios
            // 
            grillaSocios.AllowUserToAddRows = false;
            grillaSocios.AllowUserToDeleteRows = false;
            grillaSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaSocios.Location = new Point(12, 49);
            grillaSocios.Name = "grillaSocios";
            grillaSocios.ReadOnly = true;
            grillaSocios.Size = new Size(533, 150);
            grillaSocios.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 1;
            label1.Text = "Socios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(681, 21);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 3;
            label2.Text = "Libros";
            // 
            // grillaLibros
            // 
            grillaLibros.AllowUserToAddRows = false;
            grillaLibros.AllowUserToDeleteRows = false;
            grillaLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaLibros.Location = new Point(681, 49);
            grillaLibros.Name = "grillaLibros";
            grillaLibros.ReadOnly = true;
            grillaLibros.Size = new Size(495, 150);
            grillaLibros.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 239);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 5;
            label3.Text = "Préstamos";
            // 
            // grillaPrestamos
            // 
            grillaPrestamos.AllowUserToAddRows = false;
            grillaPrestamos.AllowUserToDeleteRows = false;
            grillaPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPrestamos.Location = new Point(12, 267);
            grillaPrestamos.Name = "grillaPrestamos";
            grillaPrestamos.ReadOnly = true;
            grillaPrestamos.Size = new Size(744, 150);
            grillaPrestamos.TabIndex = 4;
            // 
            // btnAgregarSocio
            // 
            btnAgregarSocio.Location = new Point(12, 205);
            btnAgregarSocio.Name = "btnAgregarSocio";
            btnAgregarSocio.Size = new Size(75, 23);
            btnAgregarSocio.TabIndex = 6;
            btnAgregarSocio.Text = "Agregar";
            btnAgregarSocio.UseVisualStyleBackColor = true;
            btnAgregarSocio.Click += btnAgregarSocio_Click;
            // 
            // btnBorrarSocio
            // 
            btnBorrarSocio.Location = new Point(93, 205);
            btnBorrarSocio.Name = "btnBorrarSocio";
            btnBorrarSocio.Size = new Size(75, 23);
            btnBorrarSocio.TabIndex = 7;
            btnBorrarSocio.Text = "Borrar";
            btnBorrarSocio.UseVisualStyleBackColor = true;
            btnBorrarSocio.Click += btnBorrarSocio_Click;
            // 
            // btnModificarSocio
            // 
            btnModificarSocio.Location = new Point(174, 205);
            btnModificarSocio.Name = "btnModificarSocio";
            btnModificarSocio.Size = new Size(75, 23);
            btnModificarSocio.TabIndex = 8;
            btnModificarSocio.Text = "Modificar";
            btnModificarSocio.UseVisualStyleBackColor = true;
            btnModificarSocio.Click += btnModificarSocio_Click;
            // 
            // btnModificarLibro
            // 
            btnModificarLibro.Location = new Point(843, 205);
            btnModificarLibro.Name = "btnModificarLibro";
            btnModificarLibro.Size = new Size(75, 23);
            btnModificarLibro.TabIndex = 11;
            btnModificarLibro.Text = "Modificar";
            btnModificarLibro.UseVisualStyleBackColor = true;
            btnModificarLibro.Click += btnModificarLibro_Click;
            // 
            // btnBorrarLibro
            // 
            btnBorrarLibro.Location = new Point(762, 205);
            btnBorrarLibro.Name = "btnBorrarLibro";
            btnBorrarLibro.Size = new Size(75, 23);
            btnBorrarLibro.TabIndex = 10;
            btnBorrarLibro.Text = "Borrar";
            btnBorrarLibro.UseVisualStyleBackColor = true;
            btnBorrarLibro.Click += btnBorrarLibro_Click;
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Location = new Point(681, 205);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(75, 23);
            btnAgregarLibro.TabIndex = 9;
            btnAgregarLibro.Text = "Agregar";
            btnAgregarLibro.UseVisualStyleBackColor = true;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // btnCrearPrestamo
            // 
            btnCrearPrestamo.Location = new Point(564, 103);
            btnCrearPrestamo.Name = "btnCrearPrestamo";
            btnCrearPrestamo.Size = new Size(99, 33);
            btnCrearPrestamo.TabIndex = 12;
            btnCrearPrestamo.Text = "Crear préstamo";
            btnCrearPrestamo.UseVisualStyleBackColor = true;
            btnCrearPrestamo.Click += btnCrearPrestamo_Click;
            // 
            // btnModificarPrestamo
            // 
            btnModificarPrestamo.Location = new Point(12, 423);
            btnModificarPrestamo.Name = "btnModificarPrestamo";
            btnModificarPrestamo.Size = new Size(75, 23);
            btnModificarPrestamo.TabIndex = 13;
            btnModificarPrestamo.Text = "Modificar";
            btnModificarPrestamo.UseVisualStyleBackColor = true;
            btnModificarPrestamo.Click += btnModificarPrestamo_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(93, 423);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 14;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnExportarPdfGraphics
            // 
            btnExportarPdfGraphics.Location = new Point(776, 315);
            btnExportarPdfGraphics.Name = "btnExportarPdfGraphics";
            btnExportarPdfGraphics.Size = new Size(142, 48);
            btnExportarPdfGraphics.TabIndex = 15;
            btnExportarPdfGraphics.Text = "Exportar reporte a PDF con PdfGraphics";
            btnExportarPdfGraphics.UseVisualStyleBackColor = true;
            btnExportarPdfGraphics.Click += btnExportarPdfGraphics_Click;
            // 
            // btnExportarPdfGrid
            // 
            btnExportarPdfGrid.Location = new Point(776, 369);
            btnExportarPdfGrid.Name = "btnExportarPdfGrid";
            btnExportarPdfGrid.Size = new Size(142, 48);
            btnExportarPdfGrid.TabIndex = 16;
            btnExportarPdfGrid.Text = "Exportar reporte a PDF con PdfGrid";
            btnExportarPdfGrid.UseVisualStyleBackColor = true;
            btnExportarPdfGrid.Click += btnExportarPdfGrid_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 450);
            Controls.Add(btnExportarPdfGrid);
            Controls.Add(btnExportarPdfGraphics);
            Controls.Add(btnBorrar);
            Controls.Add(btnModificarPrestamo);
            Controls.Add(btnCrearPrestamo);
            Controls.Add(btnModificarLibro);
            Controls.Add(btnBorrarLibro);
            Controls.Add(btnAgregarLibro);
            Controls.Add(btnModificarSocio);
            Controls.Add(btnBorrarSocio);
            Controls.Add(btnAgregarSocio);
            Controls.Add(label3);
            Controls.Add(grillaPrestamos);
            Controls.Add(label2);
            Controls.Add(grillaLibros);
            Controls.Add(label1);
            Controls.Add(grillaSocios);
            Name = "Form1";
            Text = "Biblioteca";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaSocios).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaLibros).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaPrestamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaSocios;
        private Label label1;
        private Label label2;
        private DataGridView grillaLibros;
        private Label label3;
        private DataGridView grillaPrestamos;
        private Button btnAgregarSocio;
        private Button btnBorrarSocio;
        private Button btnModificarSocio;
        private Button btnModificarLibro;
        private Button btnBorrarLibro;
        private Button btnAgregarLibro;
        private Button btnCrearPrestamo;
        private Button btnModificarPrestamo;
        private Button btnBorrar;
        private Button btnExportarPdfGraphics;
        private Button btnExportarPdfGrid;
    }
}
