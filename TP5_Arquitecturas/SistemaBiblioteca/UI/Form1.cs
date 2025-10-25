using BE;
using BLL;
using Microsoft.VisualBasic;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Windows.Forms.Chart;
using System;

namespace UI
{
    public partial class Form1 : Form
    {
        BLL_Libro _blllibro;
        BLL_Socio _bllsocio;
        BLL_Prestamo _bllprestamo;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            _blllibro = new BLL_Libro();
            _bllsocio = new BLL_Socio();
            _bllprestamo = new BLL_Prestamo();
            Mostrar(grillaLibros, _blllibro.ObtenerDatosAnonimos());
            Mostrar(grillaSocios, _bllsocio.ObtenerDatosAnonimos());
            Mostrar(grillaPrestamos, _bllprestamo.ObtenerDatosAnonimos());
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }
        private void btnAgregarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Interaction.InputBox("Ingrese el ID", "Alta socio");
                if (id.Length == 0) throw new Exception("El ID está vacio!");
                BE_Socio aux = new BE_Socio(id);
                if (_bllsocio.ValidarIdRepetido(aux)) throw new Exception("El ID del socio está repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alta socio");
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Alta socio");
                if (apellido.Length == 0) throw new Exception("Apellido vacío!");
                DateTime fechaNacimiento = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de nacimiento", "Alta socio", DateTime.Now.ToShortDateString()));
                string localidad = Interaction.InputBox("Ingrese la localidad", "Alta socio");
                if (localidad.Length == 0) throw new Exception("Localidad vacía!");

                BE_Socio socio = new BE_Socio(id, nombre, apellido, fechaNacimiento, localidad);
                _bllsocio.Agregar(socio);
                Mostrar(grillaSocios, _bllsocio.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaSocios.Rows.Count == 0) throw new Exception("No hay socios para borrar!");
                var socio = grillaSocios.SelectedRows[0].DataBoundItem as BE_Socio;
                _bllsocio.Borrar(socio);
                Mostrar(grillaSocios, _bllsocio.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaSocios.Rows.Count == 0) throw new Exception("No hay socios para modificar!");
                var socio = grillaSocios.SelectedRows[0].DataBoundItem as BE_Socio;

                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificación socio", socio.Nombre);
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Modificación socio", socio.Apellido);
                if (apellido.Length == 0) throw new Exception("Apellido vacío!");
                DateTime fechaNacimiento = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de nacimiento", "Modificación socio", socio.FechaNacimiento.ToShortDateString()));
                string localidad = Interaction.InputBox("Ingrese la localidad", "Modificación socio", socio.Localidad);
                if (localidad.Length == 0) throw new Exception("Localidad vacía!");

                BE_Socio nuevoSocio = new BE_Socio(socio.Id, nombre, apellido, fechaNacimiento, localidad);
                _bllsocio.Modificar(nuevoSocio);
                Mostrar(grillaSocios, _bllsocio.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Interaction.InputBox("Ingrese el ID", "Alta libro");
                if (id.Length == 0) throw new Exception("El ID está vacio!");
                BE_Libro aux = new BE_Libro(id);
                if (_blllibro.ValidarIdRepetido(aux)) throw new Exception("El ID del libro está repetido!");
                string titulo = Interaction.InputBox("Ingrese el título", "Alta libro");
                if (titulo.Length == 0) throw new Exception("Título vacio!");
                string autor = Interaction.InputBox("Ingrese el autor", "Alta libro");
                if (autor.Length == 0) throw new Exception("Autor vacío!");

                BE_Libro libro = new BE_Libro(id, titulo, autor);
                _blllibro.Agregar(libro);
                Mostrar(grillaLibros, _blllibro.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaLibros.Rows.Count == 0) throw new Exception("No hay libros para borrar!");
                var libro = grillaLibros.SelectedRows[0].DataBoundItem as BE_Libro;
                _blllibro.Borrar(libro);
                Mostrar(grillaLibros, _blllibro.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaLibros.Rows.Count == 0) throw new Exception("No hay libros para modificar!");
                var libro = grillaLibros.SelectedRows[0].DataBoundItem as BE_Libro;

                string titulo = Interaction.InputBox("Ingrese el título", "Modificación libro", libro.Titulo);
                string autor = Interaction.InputBox("Ingrese el autor", "Modificación libro", libro.Autor);

                BE_Libro nuevoLibro = new BE_Libro(libro.Id, titulo, autor);

                _blllibro.Modificar(nuevoLibro);
                Mostrar(grillaLibros, _blllibro.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaSocios.Rows.Count == 0) throw new Exception("No está seleccionado un socio para crear el préstamo!");
                if (grillaLibros.Rows.Count == 0) throw new Exception("No está seleccionado un libro para crear el préstamo!");
                var socio = grillaSocios.SelectedRows[0].DataBoundItem as BE_Socio;
                var libro = grillaLibros.SelectedRows[0].DataBoundItem as BE_Libro;

                string id = Interaction.InputBox("Ingrese el ID", "Alta préstamo");
                if (id.Length == 0) throw new Exception("El ID está vacio!");
                BE_Prestamo aux = new BE_Prestamo(id);
                if (_bllprestamo.ValidarIdRepetido(aux)) throw new Exception("El ID del préstamo está repetido!");
                DateTime fechaDevolucion = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de devolución", "Alta préstamo", DateTime.Now.ToShortDateString()));
                if (fechaDevolucion <= DateTime.Now) throw new Exception("La fecha de devolución es anterior a la fecha actual!");

                BE_Prestamo prestamo = new BE_Prestamo(id, socio, libro, DateTime.Now.Date, fechaDevolucion);
                _bllprestamo.Agregar(prestamo);
                Mostrar(grillaPrestamos, _bllprestamo.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos para borrar!");
                var prestramo = grillaPrestamos.SelectedRows[0].DataBoundItem as BE_Prestamo;
                _bllprestamo.Borrar(prestramo);
                Mostrar(grillaPrestamos, _bllprestamo.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos para modificar");
                var prestamo = grillaPrestamos.SelectedRows[0].DataBoundItem as BE_Prestamo;

                DateTime fechaPrestamo = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de préstamo", "Modificación préstamo", prestamo.FechaPrestamo.ToShortDateString()));
                DateTime fechaDevolucion = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de devolución", "Modificación préstamo", prestamo.FechaDevolucion.ToShortDateString()));
                if (fechaDevolucion <= fechaPrestamo) throw new Exception("La fecha de devolución es anterior a la fecha de préstamo!");
                string estado = Interaction.InputBox("Ingrese el estado", "Modificación préstamo", prestamo.Estado);

                BE_Prestamo nuevoPrestamo = new BE_Prestamo(prestamo.Id, prestamo.Socio, prestamo.Libro, fechaPrestamo, fechaDevolucion, estado);
                _bllprestamo.Modificar(nuevoPrestamo);
                Mostrar(grillaPrestamos, _bllprestamo.ObtenerDatosAnonimos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPdfGraphics_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            PdfFont fuenteTitulo = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            PdfFont fuenteTexto = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

            // Crear lista socios
            PdfPage pagina1 = pdf.Pages.Add();
            pagina1.Graphics.DrawString("REPORTE DE BIBLIOTECA", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            pagina1.Graphics.DrawString("Información de todos los socios", fuenteTitulo, PdfBrushes.Black, new PointF(0, 15));
            float y = 40;
            float altoLinea = 20;
            float margen = 40;
            foreach (var a in _bllsocio.ObtenerDatos())
            {
                if (y + altoLinea > pagina1.GetClientSize().Height - margen)
                {
                    pagina1 = pdf.Pages.Add();
                    y = 40;
                }
                string linea = $"{a.Id} - {a.Nombre} {a.Apellido} - {a.FechaNacimiento.ToShortDateString()} - {a.Localidad}";
                pagina1.Graphics.DrawString(linea, fuenteTexto, PdfBrushes.Black, new PointF(0, y));
                y += altoLinea;
            }

            // Crear lista libros
            PdfPage pagina2 = pdf.Pages.Add();
            pagina2.Graphics.DrawString("Información de todos los libros", fuenteTitulo, PdfBrushes.Black, new PointF(0, 15));
            y = 40;
            foreach (var a in _blllibro.ObtenerDatos())
            {
                if (y + altoLinea > pagina2.GetClientSize().Height - margen)
                {
                    pagina2 = pdf.Pages.Add();
                    y = 40;
                }
                string linea = $"{a.Id} - {a.Titulo} - {a.Autor}";
                pagina2.Graphics.DrawString(linea, fuenteTexto, PdfBrushes.Black, new PointF(0, y));
                y += altoLinea;
            }

            // Crear lista préstamos
            PdfPage pagina3 = pdf.Pages.Add();
            pagina3.Graphics.DrawString("Información de todos los préstamos", fuenteTitulo, PdfBrushes.Black, new PointF(0, 15));
            y = 40;
            foreach (var a in _bllprestamo.ObtenerDatos())
            {
                if (y + altoLinea > pagina3.GetClientSize().Height - margen)
                {
                    pagina3 = pdf.Pages.Add();
                    y = 40;
                }
                string linea = $"{a.Id}, {a.Socio.ToString()}, {a.Libro.ToString()}, Préstamo: {a.FechaPrestamo.ToShortDateString()}, Devolución: {a.FechaDevolucion.ToShortDateString()}";
                pagina3.Graphics.DrawString(linea, fuenteTexto, PdfBrushes.Black, new PointF(0, y));
                y += altoLinea;
            }

            //-------------------- GRÁFICOS --------------------

            // Gráfico de barras
            ChartControl chart1 = new ChartControl();
            chart1.Size = new Size(600, 600);
            chart1.Text = "Libros agrupados por autor";
            chart1.Legend.Visible = false;
            ChartSeries series1 = new ChartSeries("Libros", ChartSeriesType.Bar);
            var consulta = from libro in _blllibro.ObtenerDatos() group libro by libro.Autor into grupo select new { Autor = grupo.Key, Cantidad = grupo.Count() };
            foreach (var a in consulta)
            {
                series1.Points.Add(a.Autor, a.Cantidad);
            }
            chart1.Series.Add(series1);
            
            string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_bar.png");
            chart1.SaveImage(tempFile);

            PdfPage paginaGraficos1 = pdf.Pages.Add();
            paginaGraficos1.Graphics.DrawString("Libros agrupados por autor - Gráfico de barras", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen = PdfImage.FromFile(tempFile);
            paginaGraficos1.Graphics.DrawImage(imagen, new PointF(0, 40));

            // Gráfico de torta
            ChartControl chart2 = new ChartControl();
            chart2.Size = new Size(600, 600);
            chart2.Text = "Socios agrupados por localidad";
            chart2.Legend.Visible = false;
            chart2.Legend.Position = ChartDock.Bottom;
            ChartSeries series2 = new ChartSeries("Socios", ChartSeriesType.Pie);
            series2.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Outside;
            var consulta2 = from socio in _bllsocio.ObtenerDatos() group socio by socio.Localidad into grupo select new { Localidad = grupo.Key, Cantidad = grupo.Count() };

            foreach (var a in consulta2)
            {
                series2.Points.Add(a.Localidad, a.Cantidad);
            }
            chart2.Series.Add(series2);

            chart2.Series[0].Style.DisplayText = true;
            for (int i = 0; i < series2.Points.Count; i++)
            {
                series2.Styles[i].Text = $"{series2.Points[i].Category}: {series2.Points[i].YValues[0]}";
            }

            string tempFile2 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_pie.png");
            chart2.SaveImage(tempFile2);

            PdfPage paginaGraficos2 = pdf.Pages.Add();
            paginaGraficos2.Graphics.DrawString("Socios agrupados por localidad - Gráfico de torta", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen2 = PdfImage.FromFile(tempFile2);
            paginaGraficos2.Graphics.DrawImage(imagen2, new PointF(0, 40));

            // Gráfico lineal
            ChartControl chart3 = new ChartControl();
            chart3.Size = new Size(600, 600);
            chart3.Text = "Préstamos totales por mes";
            chart3.Legend.Visible = false;
            ChartSeries series3 = new ChartSeries("Préstamos", ChartSeriesType.Line);
            var consulta3 = from prestamo in _bllprestamo.ObtenerDatos() group prestamo by prestamo.FechaPrestamo.Month into grupo select new { Mes = grupo.Key, TotalPrestamos = grupo.Count() };
            foreach (var a in consulta3)
            {
                series3.Points.Add(a.Mes, a.TotalPrestamos);
            }
            chart3.Series.Add(series3);

            string tempFile3 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_linea.png");
            chart3.SaveImage(tempFile3);

            PdfPage paginaGraficos3 = pdf.Pages.Add();
            paginaGraficos3.Graphics.DrawString("Préstamos totales por mes - Gráfico lineal", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen3 = PdfImage.FromFile(tempFile3);
            paginaGraficos3.Graphics.DrawImage(imagen3, new PointF(0, 40));


            // Gráfico de área
            ChartControl chart4 = new ChartControl();
            chart4.Size = new Size(600, 600);
            chart4.Text = "Préstamos acumulados por autor";
            chart4.Legend.Visible = false;
            chart4.PrimaryXAxis.LabelRotateAngle = 45;
            chart4.PrimaryXAxis.LabelIntersectAction = ChartLabelIntersectAction.MultipleRows;
            ChartSeries series4 = new ChartSeries("Préstamos", ChartSeriesType.Area);
            var consulta4 = from prestamo in _bllprestamo.ObtenerDatos()
                            join libro in _blllibro.ObtenerDatos() on prestamo.Libro.Id equals libro.Id
                            group prestamo by libro.Autor into grupo
                            select new
                            {
                                Autor = grupo.Key,
                                TotalPrestamos = grupo.Count()
                            };
            foreach (var a in consulta4)
            {
                series4.Points.Add(a.Autor, a.TotalPrestamos);
            }
            chart4.Series.Add(series4);

            string tempFile4 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_area.png");
            chart4.SaveImage(tempFile4);

            PdfPage paginaGraficos4 = pdf.Pages.Add();
            paginaGraficos4.Graphics.DrawString("Préstamos acumulados por autor - Gráfico de área", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen4 = PdfImage.FromFile(tempFile4);
            paginaGraficos4.Graphics.DrawImage(imagen4, new PointF(0, 40));

            // Gráfico de burbuja
            ChartControl chart5 = new ChartControl();
            chart5.Size = new Size(720, 700);
            chart5.Text = "Socios activos";
            chart5.Legend.Visible = false;
            ChartSeries series5 = new ChartSeries("Socios", ChartSeriesType.Bubble);
            var consulta5 = from socio in _bllsocio.ObtenerDatos()
                            join prestamo in _bllprestamo.ObtenerDatos() on socio.Id equals prestamo.Socio.Id into grupo
                            select new
                            {
                                Socio = socio.Id,
                                CantidadPrestamos = grupo.Count(),
                                Tamaño = 1 + grupo.Select(x => x.Libro.Id).Distinct().Count()
                            };
            foreach (var a in consulta5)
            {
                series5.Points.Add(a.Socio, a.CantidadPrestamos, a.Tamaño);
            }
            chart5.Series.Add(series5);
            
            string tempFile5 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_burbuja.png");
            chart5.SaveImage(tempFile5);

            PdfPage paginagraficos5 = pdf.Pages.Add();
            paginagraficos5.Graphics.DrawString("Socios activos - Gráfico de burbuja", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen5 = PdfImage.FromFile(tempFile5);
            paginagraficos5.Graphics.DrawImage(imagen5, new PointF(0, 40));


            // Gráfico de dispersión
            ChartControl chart6 = new ChartControl();
            chart6.Size = new Size(700, 600);
            chart6.Text = "Edades en función de la cantidad de préstamos que realizó";
            chart6.Legend.Visible = false;
            ChartSeries series6 = new ChartSeries("Cantidad de préstamos por persona", ChartSeriesType.Scatter);
            series6.Style.Symbol.Shape = ChartSymbolShape.Square;
            series6.Style.Symbol.Color = Color.Orange;
            var consulta6 = from prestamo in _bllprestamo.ObtenerDatos()
                            join socio in _bllsocio.ObtenerDatos() on prestamo.Socio.Id equals socio.Id
                            group prestamo by new
                            {
                                socio.Id,
                                Edad = DateTime.Now.Year - socio.FechaNacimiento.Year
                            } into grupo
                            select new
                            {
                                Edad = grupo.Key.Edad,
                                CantidadPrestamos = grupo.Count()
                            };
            foreach (var a in consulta6)
            {
                series6.Points.Add(a.Edad, a.CantidadPrestamos);
            }
            chart6.Series.Add(series6);
            
            string tempFile6 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_dispersion.png");
            chart6.SaveImage(tempFile6);

            PdfPage paginaGraficos6 = pdf.Pages.Add();
            paginaGraficos6.Graphics.DrawString("Edades en función de la cantidad de préstamos que realizó - Gráfico de dispersión", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen6 = PdfImage.FromFile(tempFile6);
            paginaGraficos6.Graphics.DrawImage(imagen6, new PointF(0, 40));

            string archivo = "Reporte_PdfGraphics.pdf";
            pdf.Save(archivo);
            pdf.Close(true);
            MessageBox.Show($"PDF generado: {archivo}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnExportarPdfGrid_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            PdfFont fuenteTitulo = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            PdfFont fuenteTexto = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

            // Crear lista socios
            PdfPage pagina1 = pdf.Pages.Add();
            pagina1.Graphics.DrawString("REPORTE DE BIBLIOTECA", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            pagina1.Graphics.DrawString("Información de todos los socios", fuenteTitulo, PdfBrushes.Black, new PointF(0, 15));
            PdfGrid grid1 = new PdfGrid();
            grid1.DataSource = _bllsocio.ObtenerListaFiltrada();
            PdfGridStyle estilo = new PdfGridStyle();
            estilo.CellPadding = new PdfPaddings(5, 5, 5, 5);
            estilo.Font = fuenteTexto;
            grid1.Style = estilo;
            PdfGridLayoutResult resultado = grid1.Draw(pagina1, new PointF(0, 40));

            // Crear lista libros
            PdfPage pagina2 = pdf.Pages.Add();
            pagina2.Graphics.DrawString("Información de todos los libros", fuenteTitulo, PdfBrushes.Black, new PointF(0, 15));
            PdfGrid grid2 = new PdfGrid();
            grid2.DataSource = _blllibro.ObtenerListaFiltrada();
            grid2.Style = estilo;
            PdfGridLayoutResult resultado2 = grid2.Draw(pagina2, new PointF(0, 40));

            // Crear lista préstamos
            PdfPage pagina3 = pdf.Pages.Add();
            pagina3.Graphics.DrawString("Información de todos los préstamos", fuenteTitulo, PdfBrushes.Black, new PointF(0, 15));
            PdfGrid grid3 = new PdfGrid();
            grid3.DataSource = _bllprestamo.ObtenerListaFiltrada(_blllibro, _bllsocio);
            grid3.Style = estilo;
            PdfGridLayoutResult resultado3 = grid3.Draw(pagina3, new PointF(0, 40));

            //-------------------- GRÁFICOS --------------------

            // Gráfico de barras
            ChartControl chart1 = new ChartControl();
            chart1.Size = new Size(600, 600);
            chart1.Text = "Libros agrupados por autor";
            ChartSeries series1 = new ChartSeries("Libros", ChartSeriesType.Bar);
            var consulta = from libro in _blllibro.ObtenerDatos() group libro by libro.Autor into grupo select new { Autor = grupo.Key, Cantidad = grupo.Count() };
            foreach (var a in consulta)
            {
                series1.Points.Add(a.Autor, a.Cantidad);
            }
            chart1.Series.Add(series1);
            chart1.Legend.Visible = false;

            string tempFile1 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_bar.png");
            chart1.SaveImage(tempFile1);

            PdfPage paginaGraficos1 = pdf.Pages.Add();
            paginaGraficos1.Graphics.DrawString("Libros agrupados por autor - Gráfico de barras", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen = PdfImage.FromFile(tempFile1);
            paginaGraficos1.Graphics.DrawImage(imagen, new PointF(0, 40));

            // Gráfico de torta
            ChartControl chart2 = new ChartControl();
            chart2.Size = new Size(600, 600);
            chart2.Text = "Socios agrupados por localidad";
            chart2.Legend.Visible = false;
            chart2.Legend.Position = ChartDock.Bottom;
            ChartSeries series2 = new ChartSeries("Socios", ChartSeriesType.Pie);
            series2.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Outside;
            
            var consulta2 = from socio in _bllsocio.ObtenerDatos() group socio by socio.Localidad into grupo select new { Localidad = grupo.Key, Cantidad = grupo.Count() };
            foreach (var a in consulta2)
            {
                series2.Points.Add(a.Localidad, a.Cantidad);
            }
            chart2.Series.Add(series2);

            chart2.Series[0].Style.DisplayText = true;
            for (int i = 0; i < series2.Points.Count; i++)
            {
                series2.Styles[i].Text = $"{series2.Points[i].Category}: {series2.Points[i].YValues[0]}";
            }

            string tempFile2 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_pie.png");
            chart2.SaveImage(tempFile2);

            PdfPage paginaGraficos2 = pdf.Pages.Add();
            paginaGraficos2.Graphics.DrawString("Socios agrupados por localidad - Gráfico de torta", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen2 = PdfImage.FromFile(tempFile2);
            paginaGraficos2.Graphics.DrawImage(imagen2, new PointF(0, 40));

            // Gráfico lineal
            ChartControl chart3 = new ChartControl();
            chart3.Size = new Size(600, 600);
            chart3.Text = "Préstamos totales por mes";
            chart3.Legend.Visible = false;

            ChartSeries series3 = new ChartSeries("Préstamos", ChartSeriesType.Line);
            var consulta3 = from prestamo in _bllprestamo.ObtenerDatos() group prestamo by prestamo.FechaPrestamo.Month into grupo select new { Mes = grupo.Key, TotalPrestamos = grupo.Count() };
            foreach (var a in consulta3)
            {
                series3.Points.Add(a.Mes, a.TotalPrestamos);
            }
            chart3.Series.Add(series3);

            string tempFile3 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_linea.png");
            chart3.SaveImage(tempFile3);

            PdfPage paginaGraficos3 = pdf.Pages.Add();
            paginaGraficos3.Graphics.DrawString("Préstamos totales por mes - Gráfico lineal", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen3 = PdfImage.FromFile(tempFile3);
            paginaGraficos3.Graphics.DrawImage(imagen3, new PointF(0, 40));

            // Gráfico de área
            ChartControl chart4 = new ChartControl();
            chart4.Size = new Size(600, 600);
            chart4.Text = "Préstamos acumulados por autor";
            chart4.PrimaryXAxis.LabelRotateAngle = 45;
            chart4.PrimaryXAxis.LabelIntersectAction = ChartLabelIntersectAction.MultipleRows;
            chart4.Legend.Visible = false;

            ChartSeries series4 = new ChartSeries("Préstamos", ChartSeriesType.Area);
            var consulta4 = from prestamo in _bllprestamo.ObtenerDatos()
                            join libro in _blllibro.ObtenerDatos() on prestamo.Libro.Id equals libro.Id
                            group prestamo by libro.Autor into grupo
                            select new
                            {
                                Autor = grupo.Key,
                                TotalPrestamos = grupo.Count()
                            };
            foreach (var a in consulta4)
            {
                series4.Points.Add(a.Autor, a.TotalPrestamos);
            }
            chart4.Series.Add(series4);

            string tempFile4 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_area.png");
            chart4.SaveImage(tempFile4);

            PdfPage paginaGraficos4 = pdf.Pages.Add();
            paginaGraficos4.Graphics.DrawString("Préstamos acumulados por autor - Gráfico de área", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen4 = PdfImage.FromFile(tempFile4);
            paginaGraficos4.Graphics.DrawImage(imagen4, new PointF(0, 40));

            // Gráfico de burbuja
            ChartControl chart5 = new ChartControl();
            chart5.Size = new Size(720, 700);
            chart5.Text = "Cantidad de préstamos por socio";
            chart5.Legend.Visible = false;
            ChartSeries series5 = new ChartSeries("Socios", ChartSeriesType.Bubble);
            var consulta5 = from socio in _bllsocio.ObtenerDatos()
                            join prestamo in _bllprestamo.ObtenerDatos() on socio.Id equals prestamo.Socio.Id into grupo
                            select new
                            {
                                Socio = socio.Id,
                                CantidadPrestamos = grupo.Count(),
                                Tamaño = 1 + grupo.Select(x => x.Libro.Id).Distinct().Count()
                            };
            foreach (var a in consulta5)
            {
                series5.Points.Add(a.Socio, a.CantidadPrestamos, a.Tamaño);
            }
            chart5.Series.Add(series5);
            
            string tempFile5 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_burbuja.png");
            chart5.SaveImage(tempFile5);

            PdfPage paginaGraficos5 = pdf.Pages.Add();
            paginaGraficos5.Graphics.DrawString("Cantidad de préstamos por socio - Gráfico de burbuja", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen5 = PdfImage.FromFile(tempFile5);
            paginaGraficos5.Graphics.DrawImage(imagen5, new PointF(0, 40));

            // Gráfico de dispersión
            ChartControl chart6 = new ChartControl();
            chart6.Size = new Size(700, 600);
            chart6.Text = "Edades en función de la cantidad de préstamos que realizó";
            chart6.Legend.Visible = false;

            ChartSeries series6 = new ChartSeries("Cantidad de préstamos por edad", ChartSeriesType.Scatter);
            series6.Style.Symbol.Shape = ChartSymbolShape.Square;
            series6.Style.Symbol.Color = Color.Orange;
            var consulta6 = from prestamo in _bllprestamo.ObtenerDatos()
                            join socio in _bllsocio.ObtenerDatos() on prestamo.Socio.Id equals socio.Id
                                        group prestamo by new
                                        {
                                            socio.Id,
                                            Edad = DateTime.Now.Year - socio.FechaNacimiento.Year
                                        } into grupo
                                        select new
                                        {
                                            Edad = grupo.Key.Edad,
                                            CantidadPrestamos = grupo.Count()
                                        };
            foreach (var a in consulta6)
            {
                series6.Points.Add(a.Edad, a.CantidadPrestamos);
            }
            chart6.Series.Add(series6);

            string tempFile6 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_grafico_dispersion.png");
            chart6.SaveImage(tempFile6);

            PdfPage paginaGraficos6 = pdf.Pages.Add();
            paginaGraficos6.Graphics.DrawString("Edades en función de la cantidad de préstamos que realizó - Gráfico de dispersión", fuenteTitulo, PdfBrushes.Black, new PointF(0, 0));
            PdfImage imagen6 = PdfImage.FromFile(tempFile6);
            paginaGraficos6.Graphics.DrawImage(imagen6, new PointF(0, 40));

            string archivo = "Reporte_PdfGrid.pdf";
            pdf.Save(archivo);
            pdf.Close(true);
            MessageBox.Show($"PDF generado correctamente: {archivo}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
