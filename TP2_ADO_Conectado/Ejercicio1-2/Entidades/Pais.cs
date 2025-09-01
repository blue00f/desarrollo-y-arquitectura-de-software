using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Pais(int pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
        public Pais(object[] pDatos) : this(Convert.ToInt32(pDatos[0]), Convert.ToString(pDatos[1])) { }
    }
}
