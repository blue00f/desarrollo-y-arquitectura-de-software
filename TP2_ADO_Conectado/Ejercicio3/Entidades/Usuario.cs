using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Entidades
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public string Rol { get; set; }
        public Usuario(int pId, string pNombre, string pClave, int pIntentosFallidos, bool pBloqueado, string pRol)
        {
            Id = pId;
            Nombre = pNombre;
            Clave = pClave;
            Rol = pRol;
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Rol = pRol;
        }
        public Usuario(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToString(pDatos[2]),
            Convert.ToInt16(pDatos[3]),
            Convert.ToBoolean(pDatos[4]),
            Convert.ToString(pDatos[5])
        ) { }
    }
}
