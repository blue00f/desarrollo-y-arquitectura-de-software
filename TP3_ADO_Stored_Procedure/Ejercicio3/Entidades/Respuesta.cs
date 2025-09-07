using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Entidades
{
    internal class Respuesta
    {
        public int Id { get; set; }
        public string NombreJugador { get; set; }
        public string Pregunta { get; set; }
        public string Opcion { get; set; }
        public int Puntos { get; set; }
        public Respuesta(int id, string nombreJugador, string pregunta, string opcion, int puntos)
        {
            Id = id;
            NombreJugador = nombreJugador;
            Pregunta = pregunta;
            Opcion = opcion;
            Puntos = puntos;
        }
        public Respuesta(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToString(pDatos[2]),
            Convert.ToString(pDatos[3]),
            Convert.ToInt16(pDatos[4])
        ) { }
    }
}
