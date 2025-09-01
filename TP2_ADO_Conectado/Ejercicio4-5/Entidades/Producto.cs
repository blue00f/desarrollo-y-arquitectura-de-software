using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_5.Entidades
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }

        public Producto(int pId, string pNombre, decimal pPrecio, int pIdCategoria)
        {
            Id = pId;
            Nombre = pNombre;
            Precio = pPrecio;
            IdCategoria = pIdCategoria;
        }
        public Producto(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToDecimal(pDatos[2]),
            Convert.ToInt16(pDatos[3])
        ) { }
    }
}
