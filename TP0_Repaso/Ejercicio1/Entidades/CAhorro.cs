using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class CAhorro : Cuenta
    {
        public CAhorro(int pCodigo) : base(pCodigo) { }
        public override void Extraer(decimal pMonto)
        {
            if (pMonto > this.Saldo) throw new Exception("Saldo insuficiente!");
            this.Saldo -= pMonto;
        }
    }
}
