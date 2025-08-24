using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    internal class Silver : Paquete
    {
        public Silver(int pCodigo,string pNombre, decimal pImporte) : base(pCodigo, pNombre, pImporte) { }

        public override decimal CalcularAbono(decimal pPrecio)
        {
            this.Abono = this.Importe * 0.15m;
            return this.Abono;
        }
    }
}
