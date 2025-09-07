using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    internal class Multa
    {
        public int Id { get; set; }
        public int Vehiculo { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Monto { get; set; }
        public string Situacion { get; set; }
        public Multa(int id, int vehiculo, DateTime fechaHora, decimal monto, string situacion)
        {
            Id = id;
            Vehiculo = vehiculo;
            FechaHora = fechaHora;
            Monto = monto;
            Situacion = situacion;
        }
        public Multa(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToInt16(pDatos[1]),
            Convert.ToDateTime(pDatos[2]),
            Convert.ToDecimal(pDatos[3]),
            Convert.ToString(pDatos[4])
        ) { }
    }
}
