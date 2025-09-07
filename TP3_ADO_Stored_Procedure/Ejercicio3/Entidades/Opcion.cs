using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Entidades
{
    internal class Opcion
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool EsCorrecta { get; set; }
        public int Pregunta { get; set; }
        public Opcion(int id, string texto, bool esCorrecta, int pregunta)
        {
            Id = id;
            Texto = texto;
            EsCorrecta = esCorrecta;
            Pregunta = pregunta;
        }
        public Opcion(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToBoolean(pDatos[2]),
            Convert.ToInt16(pDatos[3])
        ) { }
    }
}
