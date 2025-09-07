using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime? FechaLanzamiento { get; set; }
        public Obra(int id, string titulo, string autor, DateTime? fechaLanzamiento)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            FechaLanzamiento = fechaLanzamiento;
        }
        public Obra(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToString(pDatos[2]),
            pDatos[3] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pDatos[3])
        ) { }
    }
}
