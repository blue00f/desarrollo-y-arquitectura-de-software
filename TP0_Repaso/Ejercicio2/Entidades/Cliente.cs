using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    public class Cliente : ICloneable
    {
        List<Paquete> paquetes;
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Cliente(string pCodigo, string pNombre, string pApellido, string pDni, DateTime pFechaNacimiento)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Apellido = pApellido;
            Dni = pDni;
            FechaNacimiento = pFechaNacimiento;
            paquetes = new List<Paquete>();
        }

        public void ComprarPaquete(Paquete pPaquete)
        {
            paquetes.Add(pPaquete);
            pPaquete.CalcularAbono(pPaquete.Importe);
        }
        public List<Paquete> ObtenerPaquetes() => (from p in paquetes select p.CloneTipado()).ToList<Paquete>();
        public object Clone() => this.MemberwiseClone();
        public Cliente? CloneTipado() => this.Clone() as Cliente;
        public override string ToString() => $"{this.Codigo}-{this.Nombre} {this.Apellido}";
    }
}
