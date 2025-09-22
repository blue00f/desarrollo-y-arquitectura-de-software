using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practica_Parcial_1
{
    internal class Auto
    {
        public event EventHandler PatenteIncorrecta;
        public string Patente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }
        public int Anio { get; set; }
        public bool EnUso { get; set; }
        public decimal Valor { get; set; }

        public Auto(string patente, DateTime fechaIngreso, DateTime fechaBaja, int anio, bool enUso, decimal valor)
        {
            Patente = patente;
            FechaIngreso = fechaIngreso;
            Anio = anio;
            EnUso = enUso;
            Valor = valor;

            if (enUso == false) FechaBaja = Convert.ToDateTime("01-01-2999");
            else FechaBaja = fechaBaja;
        }
        public void ValidarPatenteYNotificar()
        {
            if (ValidarPatente(Patente)) PatenteIncorrecta?.Invoke(this, null);
        }
        static public bool ValidarPatente(string patente)
        {
            bool rdo = false;
            string patron = "^[A-Z]{2}[0-9]{3}[A-Z]{3}";
            if (!Regex.IsMatch(patente, patron)) rdo = true;
            return rdo;
        }
    }
}
