using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BE_Persona
    {
        public BE_Persona() { }
        public BE_Persona(string pDNI) { DNI = pDNI; }
        public BE_Persona(object[] pItemArray) : this(pItemArray[0].ToString())
        { Nombre = pItemArray[1].ToString(); Apellido = pItemArray[2].ToString(); }
        public BE_Persona(string pDNI, string pNombre, string pApellido) : this(new object[] {pDNI,pNombre, pApellido}){}
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public override string ToString()
        {
            return $"{DNI} {Apellido}, {Nombre}"; 
        }
    }
}
