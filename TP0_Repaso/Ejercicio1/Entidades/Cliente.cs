using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Cliente : ICloneable
    {
        List<Cuenta> cuentas;
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public Cliente(string pDni, string pNombre, string pApellido, string pTelefono, string pCorreo, DateTime pFechaNacimiento)
        {
            Dni = pDni;
            Nombre = pNombre;
            Apellido = pApellido;
            Telefono = pTelefono;
            Correo = pCorreo;
            FechaNacimiento = pFechaNacimiento;
            Edad = DateTime.Now.Year - pFechaNacimiento.Year;
            if (DateTime.Now.Date < pFechaNacimiento.AddYears(Edad)) this.Edad--;
            cuentas = new List<Cuenta>();
        }

        public List<Cuenta> ObtenerCuentas()
        {
            var consulta = from c in cuentas select c.CloneTipado();
            return consulta.ToList<Cuenta>();
        }

        public void AsignarCuenta(Cuenta pCuenta) => cuentas.Add(pCuenta);
        public void DesasignarCuenta(Cuenta pCuenta)
        {
            var cuenta = cuentas.Find(x => x.Codigo == pCuenta.Codigo);
            if (cuenta != null)
            {
                cuentas.Remove(cuenta);
            }
        }


        public object Clone() => this.MemberwiseClone();
        public Cliente? CloneTipado() => this.Clone() as Cliente;
    }
}
