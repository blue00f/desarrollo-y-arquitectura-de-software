using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_5.Entidades
{
    internal class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Categoria(int pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
        public Categoria(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1])
        ) { }
    }
}
