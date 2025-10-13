using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reso_PrimerParcial.Entidades
{
    internal class Proveedor : ICloneable
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public object[] RetornaDatosColeccion() => new object[] { Id, Nombre, Direccion };
        public object Clone() => this.MemberwiseClone();
        public Proveedor? CloneTipado() => this.Clone() as Proveedor;
    }
}
