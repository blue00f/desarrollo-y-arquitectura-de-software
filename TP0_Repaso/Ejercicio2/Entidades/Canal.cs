using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    public class Canal : ICloneable
    {
        List<Serie> series;
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Canal(string pCodigo, string pNombre)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            series = new List<Serie>();
        }

        #region "ABM-C Series"
        public void AgregarSerie(Serie pSerie) => series.Add(pSerie);
        public void BorrarSerie(Serie pSerie)
        {
            var serie = series.Find(x => x.Codigo == pSerie.Codigo);
            if (serie != null) series.Remove(serie);
        }
        public void ModificarSerie(Serie pSerie)
        {
            var serie = series.Find(x => x.Codigo == pSerie.Codigo);
            if (serie != null)
            {
                serie.CantTemporadas = pSerie.CantTemporadas;
                serie.CantEpisodios = pSerie.CantEpisodios;
                serie.Duracion = pSerie.Duracion;
                serie.Ranking = pSerie.Ranking;
                serie.TipoGenero = pSerie.TipoGenero;
                serie.Director = pSerie.Director;
            }
        }
        public List<Serie> ObtenerSeries() => (from s in series select s.CloneTipado()).ToList<Serie>();
        #endregion
        public bool ValidarCodigoSerie(string pCodigo)
        {
            bool rdo = false;
            var serie = series.Find(x => x.Codigo == pCodigo);
            if (serie != null) rdo = true;
            return rdo;
        }
        public override string ToString() => $"{this.Codigo}-{this.Nombre}";
        public object Clone() => this.MemberwiseClone();
        public Canal? CloneTipado() => this.Clone() as Canal;
    }
}
