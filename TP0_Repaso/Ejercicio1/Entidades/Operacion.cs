using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Operacion : ICloneable
    {
        public DateTime Fecha { get; set; }
        public string TipoOperacion { get; set; }
        public decimal Importe { get; set; }

        public Cuenta Cuenta { get; set; }

        public Operacion(string pTipoOperacion, decimal pImporte, Cuenta pCuenta)
        {
            Fecha = DateTime.Now;
            TipoOperacion = pTipoOperacion;
            Importe = pImporte;
            Cuenta = pCuenta;
        }

        public object Clone() => this.MemberwiseClone();
        public Operacion? CloneTipado() => this.Clone() as Operacion;
    }
}
