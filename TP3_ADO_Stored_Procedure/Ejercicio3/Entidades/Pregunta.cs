using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Entidades
{
    internal class Pregunta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int Nivel { get; set; }
        public int Valor { get; set; }
        public int Categoria { get; set; }
        public Pregunta(int id, string texto, int nivel, int valor, int categoria)
        {
            Id = id;
            Texto = texto;
            Nivel = nivel;
            Valor = valor;
            Categoria = categoria;
        }
        public Pregunta(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToInt16(pDatos[2]),
            Convert.ToInt16(pDatos[3]),
            Convert.ToInt16(pDatos[4])
        ) { }
    }
}
