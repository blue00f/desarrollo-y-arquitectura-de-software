using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_5.Entidades
{
    internal class Log
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public int IdUsuario { get; set; }
        public Log(int pId, DateTime pFecha, string pOperacion, int pIdUsuario)
        {
            Id = pId;
            Fecha = pFecha;
            Operacion = pOperacion;
            IdUsuario = pIdUsuario;
        }
        public Log(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToDateTime(pDatos[1]),
            Convert.ToString(pDatos[2]),
            Convert.ToInt16(pDatos[3])
        ) { }
    }
}
