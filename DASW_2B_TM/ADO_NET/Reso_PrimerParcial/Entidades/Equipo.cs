using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Reso_PrimerParcial.Entidades
{
    internal class Equipo : ICloneable
    {
        public event EventHandler CodigoErroneo;
        Regex re;
        string codigo;
        public Equipo() { re = new Regex(@"EQ-\d{4}-\d{3}"); codigo = ""; }
        public string Codigo
        {
            get => codigo;
            set
            {
                if (ValidaCodigo(value)) codigo = value;
                else CodigoErroneo?.Invoke(this, EventArgs.Empty);
            }
        }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }
        public int AxoCompra { get; set; }
        public bool EnUso { get; set; }
        public decimal ValorDeCompra { get; set; }

        public decimal ValorResidual()
        {
            var axo = DateTime.Now.Year - AxoCompra;
            var dto = axo * 0.15 <= 1 ? axo * 0.15 : 1;
            var rdo = ValorDeCompra * (1 - Convert.ToDecimal(dto));
            return rdo;
        }
        public int CantidadDeDiasEnUso()
        {
            int rdo = 0;
            if (EnUso) rdo = (DateTime.Now.Date - FechaIngreso).Days;
            else rdo = (FechaBaja - FechaIngreso).Days;
            return rdo;
        }
        public object Clone() => this.MemberwiseClone();
        public Equipo? CloneTipado() => this.Clone() as Equipo;
        public object[] RetornaDatosColeccion() => new object[] { Codigo, FechaIngreso, FechaBaja, AxoCompra, EnUso, ValorDeCompra };
        private bool ValidaCodigo(string pCodigo) => re.IsMatch(pCodigo);
    }
}
