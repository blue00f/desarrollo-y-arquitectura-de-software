using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    internal class Vehiculo
    {
        public int Id { get; set; }
        public int Propietario { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public Vehiculo(int id, int propietario, string patente, string marca, string modelo, int anio)
        {
            Id = id;
            Propietario = propietario;
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
        }
        public Vehiculo(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToInt16(pDatos[1]),
            Convert.ToString(pDatos[2]),
            Convert.ToString(pDatos[3]),
            Convert.ToString(pDatos[4]),
            Convert.ToInt16(pDatos[5])
        ) { }
    }
}
