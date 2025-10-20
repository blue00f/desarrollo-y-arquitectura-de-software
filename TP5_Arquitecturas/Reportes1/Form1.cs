using Reportes1.Entidades;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Windows.Forms.Chart;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Reportes1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Alumno> alumnos;
        private void Form1_Load(object sender, EventArgs e)
        {
            alumnos = new List<Alumno>()
            {
                new Alumno("Mick", "Jagger", new DateTime(1943, 7, 26), "CABA"),
                new Alumno("Keith", "Richards", new DateTime(1943, 12, 18), "Buenos Aires"),
                new Alumno("David", "Bowie", new DateTime(1947, 1, 8), "Córdoba"),
                new Alumno("Freddie", "Mercury", new DateTime(1946, 9, 5), "Mar del Plata"),
                new Alumno("Brian", "May", new DateTime(1947, 7, 19), "CABA"),
                new Alumno("Roger", "Taylor", new DateTime(1949, 7, 26), "Buenos Aires"),
                new Alumno("John", "Lennon", new DateTime(1940, 10, 9), "Córdoba"),
                new Alumno("Paul", "McCartney", new DateTime(1942, 6, 18), "Mar del Plata"),
                new Alumno("George", "Harrison", new DateTime(1943, 2, 25), "CABA"),
                new Alumno("Ringo", "Starr", new DateTime(1940, 7, 7), "Buenos Aires"),
                new Alumno("Jimmy", "Page", new DateTime(1944, 1, 9), "Córdoba"),
                new Alumno("Robert", "Plant", new DateTime(1948, 8, 20), "Mar del Plata"),
                new Alumno("Angus", "Young", new DateTime(1955, 3, 31), "CABA"),
                new Alumno("Malcolm", "Young", new DateTime(1953, 1, 6), "Buenos Aires"),
                new Alumno("Brian", "Johnson", new DateTime(1947, 10, 5), "Córdoba"),
                new Alumno("Bon", "Scott", new DateTime(1946, 7, 9), "Mar del Plata"),
                new Alumno("Steven", "Tyler", new DateTime(1948, 3, 26), "CABA"),
                new Alumno("Joe", "Perry", new DateTime(1950, 9, 10), "Buenos Aires"),
                new Alumno("Axl", "Rose", new DateTime(1962, 2, 6), "Córdoba"),
                new Alumno("Slash", "Hudson", new DateTime(1965, 7, 23), "Mar del Plata"),
                new Alumno("Kurt", "Cobain", new DateTime(1967, 2, 20), "CABA"),
                new Alumno("Dave", "Grohl", new DateTime(1969, 1, 14), "Buenos Aires"),
                new Alumno("Chris", "Cornell", new DateTime(1964, 7, 20), "Córdoba"),
                new Alumno("Eddie", "Vedder", new DateTime(1964, 12, 23), "Mar del Plata"),
                new Alumno("Mick", "Fleetwood", new DateTime(1947, 6, 24), "CABA"),
                new Alumno("John", "McVie", new DateTime(1945, 11, 26), "Buenos Aires"),
                new Alumno("Peter", "Green", new DateTime(1946, 10, 29), "Córdoba"),
                new Alumno("Stevie", "Nicks", new DateTime(1948, 5, 26), "Mar del Plata"),
                new Alumno("Paul", "Rodgers", new DateTime(1949, 12, 17), "CABA"),
                new Alumno("Brian", "Adams", new DateTime(1959, 11, 5), "Buenos Aires")
            };

            var consulta = from a in alumnos
                           group a by a.Localidad into g
                           select new
                           {
                               Localidad = g.Key,
                               Cantidad = g.Count()
                           };

            consulta.ToList<object>();

            ChartSeries series = new ChartSeries("Alumnos por localidad", ChartSeriesType.Pie);
            ChartSeries series2 = new ChartSeries("Alumnos por localidad", ChartSeriesType.Bar);

            foreach (var a in consulta)
            {
                series.Points.Add(a.Localidad, a.Cantidad);
                series2.Points.Add(a.Localidad, a.Cantidad);
            }

            chartAlumnosAgrupados.Series.Clear();
            chartAlumnosAgrupados.Series.Add(series);

            chartAlumnos.Series.Clear();
            chartAlumnos.Series.Add(series2);
        }

        private void btnExportarPdfGraphics_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            PdfPage pagina = pdf.Pages.Add();

            PdfFont fuenteTitulo = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            PdfFont fuenteTexto = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            // -------------------- LISTA DE ALUMNOS --------------------
            float y = 40;
            float altoLinea = 20;
            float margen = 40;

            pagina.Graphics.DrawString("Reporte de Alumnos", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));

            foreach (var a in alumnos)
            {
                if (y + altoLinea > pagina.GetClientSize().Height - margen)
                {
                    pagina = pdf.Pages.Add();
                    y = 40;
                }

                string linea = $"{a.Nombre} {a.Apellido} - {a.FechaNacimiento.ToShortDateString()} - {a.Localidad}";
                pagina.Graphics.DrawString(linea, fuenteTexto, PdfBrushes.Black, new PointF(0, y));
                y += altoLinea;
            }

            // -------------------- GRÁFICO CIRCULAR --------------------
            pagina = pdf.Pages.Add();
            y = 40;
            pagina.Graphics.DrawString("Alumnos agrupados por localidad - Circular", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));

            string tempPie = Path.Combine(Path.GetTempPath(), "pie.png");
            chartAlumnosAgrupados.SaveImage(tempPie);
            PdfImage imagenPie = PdfImage.FromFile(tempPie);
            pagina.Graphics.DrawImage(imagenPie, new PointF(0, y));

            // -------------------- GRÁFICO DE BARRAS --------------------
            pagina = pdf.Pages.Add();
            y = 40;
            pagina.Graphics.DrawString("Alumnos agrupados por localidad - Barras", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));

            string tempBar = Path.Combine(Path.GetTempPath(), "bar.png");
            chartAlumnos.SaveImage(tempBar);
            PdfImage imagenBar = PdfImage.FromFile(tempBar);
            pagina.Graphics.DrawImage(imagenBar, new PointF(0, y));

            string archivo = "ReporteAlumnos_Graphics.pdf";
            pdf.Save(archivo);
            pdf.Close(true);

            MessageBox.Show($"PDF generado: {archivo}");
        }

        private void btnExportarPdfGrid_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            PdfPage pagina = pdf.Pages.Add();

            PdfFont fuenteTitulo = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            PdfFont fuenteTexto = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            pagina.Graphics.DrawString("Reporte de Alumnos (PdfGrid)", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            float y = 40;

            PdfGrid grid = new PdfGrid();
            grid.DataSource = alumnos;

            PdfGridStyle estilo = new PdfGridStyle();
            estilo.CellPadding = new PdfPaddings(5, 5, 5, 5);
            estilo.Font = fuenteTexto;
            grid.Style = estilo;

            PdfGridLayoutResult resultado = grid.Draw(pagina, new PointF(0, y));


            // -------------------- NUEVA PÁGINA CON GRÁFICOS --------------------
            PdfPage paginaGraficos = pdf.Pages.Add();
            float yGraf = 40;

            paginaGraficos.Graphics.DrawString("Alumnos agrupados por localidad - Circular", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));

            string tempPie = Path.Combine(Path.GetTempPath(), "pie_grid.png");
            chartAlumnosAgrupados.SaveImage(tempPie);
            PdfImage imagenPie = PdfImage.FromFile(tempPie);
            paginaGraficos.Graphics.DrawImage(imagenPie, new PointF(0, yGraf));

            PdfPage paginaBar = pdf.Pages.Add();
            paginaBar.Graphics.DrawString("Alumnos agrupados por localidad - Barras", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));

            string tempBar = Path.Combine(Path.GetTempPath(), "bar_grid.png");
            chartAlumnos.SaveImage(tempBar);
            PdfImage imagenBar = PdfImage.FromFile(tempBar);
            paginaBar.Graphics.DrawImage(imagenBar, new PointF(0, 40));

            string archivo = "ReporteAlumnos_Grid.pdf";
            pdf.Save(archivo);
            pdf.Close(true);
            MessageBox.Show($"PDF generado correctamente: {archivo}");
        }
    }
}
