using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Conectado
{
    internal class Alumno
    {
        public Alumno(object[] pDatos) : this(Convert.ToInt16(pDatos[0]), pDatos[1].ToString(), pDatos[2].ToString(), Convert.ToDateTime(pDatos[3]), Convert.ToBoolean(pDatos[4]))
        {}
        public Alumno(int pLegajo,string pNombre,string pApellido,DateTime pfechaIng,bool pActivo)
        {Legajo=pLegajo;Nombre=pNombre;Apellido=pApellido;FechaIng=pfechaIng; Activo = pActivo; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string  Apellido { get; set; }
        public DateTime FechaIng { get; set; }
        public bool Activo { get; set; }

    }
}
