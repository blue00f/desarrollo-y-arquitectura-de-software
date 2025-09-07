using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Entidades
{
    internal class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Jugador(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public Jugador(object[] pDatos) : this(Convert.ToInt16(pDatos[0]), Convert.ToString(pDatos[1])) { }
    }
}
