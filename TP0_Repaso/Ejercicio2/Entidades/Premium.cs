using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    internal class Premium : Paquete
    {
        public Premium(int pCodigo, string pNombre, decimal pImporte) : base(pCodigo, pNombre, pImporte) { }

        public override decimal CalcularAbono(decimal pPrecio)
        {
            this.Abono = this.Importe * 0.2m;
            return this.Abono;
        }
    }
}
