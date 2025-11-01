namespace Reportes1
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
            chartAlumnosAgrupados = new Syncfusion.Windows.Forms.Chart.ChartControl();
            chartAlumnos = new Syncfusion.Windows.Forms.Chart.ChartControl();
            btnExportarPdfGraphics = new Button();
            btnExportarPdfGrid = new Button();
            SuspendLayout();
            // 
            // chartAlumnosAgrupados
            // 
            chartAlumnosAgrupados.ChartArea.CursorLocation = new Point(0, 0);
            chartAlumnosAgrupados.ChartArea.CursorReDraw = false;
            // 
            // 
            // 
            chartAlumnosAgrupados.Legend.Location = new Point(291, 31);
            chartAlumnosAgrupados.Location = new Point(388, -1);
            chartAlumnosAgrupados.Name = "chartAlumnosAgrupados";
            chartAlumnosAgrupados.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartAlumnosAgrupados.PrimaryXAxis.Margin = true;
            chartAlumnosAgrupados.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartAlumnosAgrupados.PrimaryYAxis.Margin = true;
            chartAlumnosAgrupados.Size = new Size(400, 450);
            chartAlumnosAgrupados.TabIndex = 0;
            // 
            // 
            // 
            chartAlumnosAgrupados.Title.Name = "Default";
            chartAlumnosAgrupados.Titles.Add(chartAlumnos.Title);
            // 
            // chartAlumnos
            // 
            chartAlumnos.ChartArea.CursorLocation = new Point(0, 0);
            chartAlumnos.ChartArea.CursorReDraw = false;
            // 
            // 
            // 
            chartAlumnos.Legend.Location = new Point(256, 31);
            chartAlumnos.Location = new Point(12, -1);
            chartAlumnos.Name = "chartAlumnos";
            chartAlumnos.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartAlumnos.PrimaryXAxis.Margin = true;
            chartAlumnos.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartAlumnos.PrimaryYAxis.Margin = true;
            chartAlumnos.Size = new Size(365, 450);
            chartAlumnos.TabIndex = 2;
            // 
            // 
            // 
            chartAlumnos.Title.Name = "Default";
            // 
            // btnExportarPdfGraphics
            // 
            btnExportarPdfGraphics.Location = new Point(12, 461);
            btnExportarPdfGraphics.Name = "btnExportarPdfGraphics";
            btnExportarPdfGraphics.Size = new Size(171, 40);
            btnExportarPdfGraphics.TabIndex = 1;
            btnExportarPdfGraphics.Text = "Exportar reporte a PDF usando PdfGraphics";
            btnExportarPdfGraphics.UseVisualStyleBackColor = true;
            btnExportarPdfGraphics.Click += btnExportarPdfGraphics_Click;
            // 
            // btnExportarPdfGrid
            // 
            btnExportarPdfGrid.Location = new Point(206, 461);
            btnExportarPdfGrid.Name = "btnExportarPdfGrid";
            btnExportarPdfGrid.Size = new Size(171, 40);
            btnExportarPdfGrid.TabIndex = 3;
            btnExportarPdfGrid.Text = "Exportar reporte a PDF usando PdfGrid";
            btnExportarPdfGrid.UseVisualStyleBackColor = true;
            btnExportarPdfGrid.Click += btnExportarPdfGrid_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 513);
            Controls.Add(btnExportarPdfGrid);
            Controls.Add(chartAlumnos);
            Controls.Add(btnExportarPdfGraphics);
            Controls.Add(chartAlumnosAgrupados);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Chart.ChartControl chartAlumnosAgrupados;
        private Button btnExportarPdfGraphics;
        private Syncfusion.Windows.Forms.Chart.ChartControl chartAlumnos;
        private Button btnExportarPdfGrid;
    }
}
