using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionEquipos
{
    internal class Equipo
    {
        static public event EventHandler PatenteIncorrecta;
        public string Codigo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }
        public int AnioCompra { get; set; }
        public bool EnUso { get; set; }
        public decimal ValorCompra { get; set; }

        public Equipo(string codigo, DateTime fechaIngreso, DateTime fechaBaja, int anioCompra, bool enUso, decimal valorCompra)
        {
            Codigo = codigo;
            FechaIngreso = fechaIngreso;
            AnioCompra = anioCompra;
            EnUso = enUso;
            ValorCompra = valorCompra;
            if (enUso) FechaBaja = Convert.ToDateTime("01-01-2999");
            else FechaBaja = fechaBaja;
        }

        static public bool ValidarCodigo(string pCodigo)
        {
            bool rdo = false;
            string patron = @"^EQ[0-9]{4}[0-9]{3}";
            if (!Regex.IsMatch(pCodigo, patron))
            {
                PatenteIncorrecta?.Invoke(null, null);
                rdo = true;
            }
            return rdo;
        }
    }
}
