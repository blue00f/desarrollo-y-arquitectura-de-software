using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal abstract class Cuenta : ICloneable
    {
        public int Codigo { get; set; }
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; }

        public Cuenta(int pCodigo)
        {
            Codigo = pCodigo;
            Saldo = 0;
        }

        public void Depositar(decimal pMonto) => this.Saldo += pMonto;
        public abstract void Extraer(decimal pMonto);
        public void AsignarCliente(Cliente pCliente) => this.Cliente = pCliente;
        public void DesasignarCliente() => this.Cliente = null;

        public object Clone() => this.MemberwiseClone();
        public Cuenta? CloneTipado() => this.Clone() as Cuenta;
    }
}
