using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Pais { get; set; }
        public int Provincia { get; set; }
        public Socio(int pId, string pNombre, string pApellido, string pEmail, int pPais, int pProvincia)
        {
            Id = pId;
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
            Pais = pPais;
            Provincia = pProvincia;
        }
        public Socio(object[] pDatos) : this(Convert.ToInt32(pDatos[0]), Convert.ToString(pDatos[1]), Convert.ToString(pDatos[2]), Convert.ToString(pDatos[3]), Convert.ToInt16(pDatos[4]), Convert.ToInt16(pDatos[5])) { }
    }
}
