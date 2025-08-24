using Ejercicio2.Entidades;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ejercicio2.Entidades.Serie;

namespace Ejercicio2.Formularios
{
    public partial class frmGestionSeries : Form
    {
        private Empresa empresa;
        public frmGestionSeries(Empresa pEmpresa)
        {
            InitializeComponent();
            empresa = pEmpresa;
        }

        private void frmGestionSeries_Load(object sender, EventArgs e)
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
            foreach (var p in empresa.ObtenerPaquetes())
            {
                foreach (var c in p.ObtenerCanales())
                {
                    cbxCanales.Items.Add(c.ToString());
                }
            }
            cbxGeneros.DataSource = null;
            cbxGeneros.DataSource = Enum.GetValues(typeof(Serie.Genero));
        }

        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }

        private Canal ObtenerCanal()
        {
            if (cbxCanales.SelectedIndex == -1) throw new Exception("Debe haber un canal seleccionado!");
            string codigoCanal = cbxCanales.Text.Split("-")[0].Trim();
            var canal = empresa.ObtenerCanalPorCodigo(codigoCanal);
            return canal;
        }
        private void btnAgregarSerie_Click(object sender, EventArgs e)
        {
            try
            {
                Canal canal = ObtenerCanal();
                string codigo = Interaction.InputBox("Ingrese el código", "Alta serie");
                if (canal.ValidarCodigoSerie(codigo)) throw new Exception("El código está repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre de la serie", "Alta serie");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string inputCantTemporadas = Interaction.InputBox("Ingrese la cantidad de temporadas", "Alta serie");
                if (!int.TryParse(inputCantTemporadas, out int cantTemporadas)) throw new Exception("La cantidad de temporadas debe ser numérico!");
                string inputCantEpisodios = Interaction.InputBox("Ingrese la cantidad de episodios", "Alta serie");
                if (!int.TryParse(inputCantEpisodios, out int cantEpisodios)) throw new Exception("La cantidad de episodios debe ser numérico!");
                TimeSpan duracion = TimeSpan.Parse(Interaction.InputBox("Ingrese la duración por episodio", "Alta serie", "00:00:00"));
                if (duracion.TotalSeconds < 1) throw new Exception("La duración debe ser mayor que 0!");
                string inputRanking = Interaction.InputBox("Ingrese el ranking de la serie (entre 1 y 10)", "Alta serie");
                if (!decimal.TryParse(inputRanking, out decimal ranking)) throw new Exception("La cantidad de episodios debe ser numérico!");
                if (ranking < 0 && ranking > 10) throw new Exception("El ranking debe ser un valor entre 1 y 10!");
                Genero genero = (Genero)Enum.Parse(typeof(Genero), cbxGeneros.Text);
                string director = Interaction.InputBox("Ingrese el director", "Alta serie");
                if (director.Length == 0) throw new Exception("El director no puede estar vacio!");

                Serie serie = new Serie(codigo, nombre, cantTemporadas, cantEpisodios, duracion, ranking, genero, director, canal);
                canal.AgregarSerie(serie);
                Mostrar(grillaSeries, canal.ObtenerSeries());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarSerie_Click(object sender, EventArgs e)
        {
            try
            {
                Canal canal = ObtenerCanal();
                if (grillaSeries.Rows.Count == 0) throw new Exception("No hay registros de series!");
                var serie = grillaSeries.SelectedRows[0].DataBoundItem as Serie;
                canal.BorrarSerie(serie);
                Mostrar(grillaSeries, canal.ObtenerSeries());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSerie_Click(object sender, EventArgs e)
        {
            try
            {
                Canal canal = ObtenerCanal();
                if (grillaSeries.Rows.Count == 0) throw new Exception("No hay registros de series!");
                var serie = grillaSeries.SelectedRows[0].DataBoundItem as Serie;

                string nombre = Interaction.InputBox("Ingrese el nombre de la serie", "Modificar serie", serie.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string inputCantTemporadas = Interaction.InputBox("Ingrese la cantidad de temporadas", "Modificar serie", serie.CantTemporadas.ToString());
                if (!int.TryParse(inputCantTemporadas, out int cantTemporadas)) throw new Exception("La cantidad de temporadas debe ser numérico!");
                string inputCantEpisodios = Interaction.InputBox("Ingrese la cantidad de episodios", "Modificar serie", serie.CantEpisodios.ToString());
                if (!int.TryParse(inputCantEpisodios, out int cantEpisodios)) throw new Exception("La cantidad de episodios debe ser numérico!");
                TimeSpan duracion = TimeSpan.Parse(Interaction.InputBox("Ingrese la duración por episodio", "Modificar serie", serie.Duracion.ToString(@"hh\:mm\:ss")));
                if (duracion.TotalSeconds < 1) throw new Exception("La duración debe ser mayor que 0!");
                string inputRanking = Interaction.InputBox("Ingrese el ranking de la serie (entre 1 y 10)", "Modificar serie", serie.Ranking.ToString());
                if (!decimal.TryParse(inputRanking, out decimal ranking)) throw new Exception("La cantidad de episodios debe ser numérico!");
                if (ranking < 0 && ranking > 10) throw new Exception("El ranking debe ser un valor entre 1 y 10!");
                Genero genero = (Genero)Enum.Parse(typeof(Genero), cbxGeneros.Text);
                string director = Interaction.InputBox("Ingrese el director", "Modificar serie", serie.Director);
                if (director.Length == 0) throw new Exception("El director no puede estar vacio!");

                var serieActualizada = new Serie(serie.Codigo, nombre, cantTemporadas, cantEpisodios, duracion, ranking, genero, director, canal);
                canal.ModificarSerie(serieActualizada);
                Mostrar(grillaSeries, canal.ObtenerSeries());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCanales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxCanales.SelectedIndex == -1) throw new Exception("Debe haber un canal seleccionado!");
                Canal canal = ObtenerCanal();
                Mostrar(grillaSeries, canal.ObtenerSeries());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
