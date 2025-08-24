using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class CCorriente : Cuenta
    {
        public decimal Descubierto { get; set; }
        public CCorriente(int pCodigo, decimal pDescubierto) : base(pCodigo)
        {
            Descubierto = pDescubierto;
        }
        public override void Extraer(decimal pMonto)
        {
            if (pMonto > (this.Saldo + Descubierto)) throw new Exception("Saldo insuficiente!");
            this.Saldo -= pMonto;
        }
    }
}
