using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    public class Serie : ICloneable
    {
        public enum Genero
        {
            Accion,
            Comedia,
            Drama,
            CienciaFiccion,
            Terror,
            Documental
        }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int CantTemporadas { get; set; }
        public int CantEpisodios { get; set; }
        public TimeSpan Duracion { get; set; }
        public decimal Ranking { get; set; }
        public Genero TipoGenero { get; set; }
        public string Director { get; set; }
        public Canal Canal { get; set; }

        public Serie(string pCodigo, string pNombre, int pCantTemporadas, int pCantEpisodios, TimeSpan pDuracion, decimal pRanking, Genero pTipoGenero, string pDirector, Canal pCanal)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            CantTemporadas = pCantTemporadas;
            CantEpisodios = pCantEpisodios;
            Duracion = pDuracion;
            Ranking = pRanking;
            TipoGenero = pTipoGenero;
            Director = pDirector;
            Canal = pCanal;
        }
        public object Clone() => this.MemberwiseClone();
        public Serie? CloneTipado() => this.Clone() as Serie;
    }
}
