using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Ejemplar
    {
        public int Id { get; set; }
        public int Obra { get; set; }
        public int NumeroInventario { get; set; }
        public decimal Precio { get; set; }
        public Ejemplar(int id, int obra, int numeroInventario, decimal precio)
        {
            Id = id;
            Obra = obra;
            NumeroInventario = numeroInventario;
            Precio = precio;
        }
        public Ejemplar(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToInt16(pDatos[1]),
            Convert.ToInt16(pDatos[2]),
            Convert.ToDecimal(pDatos[3])
        ) { }
    }
}
