using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Prestamo
    {
        public int Id { get; set; }
        public int Alumno { get; set; }
        public int Ejemplar { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public Prestamo(int id, int alumno, int ejemplar, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            Id = id;
            Alumno = alumno;
            Ejemplar = ejemplar;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }
        public Prestamo(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToInt16(pDatos[1]),
            Convert.ToInt16(pDatos[2]),
            Convert.ToDateTime(pDatos[3]),
            Convert.ToDateTime(pDatos[4])
        ) { }  
    }
}
