using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reso_PrimerParcial.Entidades
{
    internal class EquipoProveedor : ICloneable
    {
        public Equipo Equipo { get; set; }
        public Proveedor Proveedor { get; set; }
        public string NombreTecnico { get; set; }

        public object Clone() => this.MemberwiseClone();
        public EquipoProveedor? CloneTipado() => this.Clone() as EquipoProveedor;
    }
}
