using BE;
using BLL;
using Microsoft.VisualBasic;

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
    }
}
