using Ejercicio2.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    public abstract class Paquete : ICloneable
    {
        List<Canal> canales;
        List<Cliente> clientes;
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Importe { get; set; }
        public decimal Abono { get; set; }

        public Paquete(int pCodigo, string pNombre, decimal pImporte)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Importe = pImporte;
            canales = new List<Canal>();
            clientes = new List<Cliente>();
        }

        public abstract decimal CalcularAbono(decimal pPrecio);

        #region "ABM-C Canales"
        public void AgregarCanal(Canal pCanal) => canales.Add(pCanal);
        public void BorrarCanal(Canal pCanal)
        {
            var canal = canales.Find(x => x.Codigo == pCanal.Codigo);
            if (canal != null) canales.Remove(canal);
        }
        public void ModificarCanal(Canal pCanal)
        {
            var canal = canales.Find(x => x.Codigo == pCanal.Codigo);
            if (canal != null) canal.Nombre = pCanal.Nombre;
        }
        public List<Canal> ObtenerCanales() => (from c in canales select c.CloneTipado()).ToList<Canal>();
        #endregion

        public List<Cliente> ObtenerClientes() => (from c in clientes select c.CloneTipado()).ToList<Cliente>();
        public List<Serie> MostrarSeries()
        {
            var aux = new List<Serie>();
            foreach (var c in canales)
            {
                var consulta = from serie in c.ObtenerSeries() select serie;
                aux.AddRange(consulta.Cast<Serie>());
            }
            return aux;
        }
        public void AsignarCliente(Cliente pCliente) => clientes.Add(pCliente);

        public bool ValidarCanalRepetido(string pCodigo)
        {
            bool rdo = false;
            var canal = canales.Find(x => x.Codigo == pCodigo);
            if (canal != null) rdo = true;
            return rdo;
        }
        public object Clone() => this.MemberwiseClone();
        public Paquete? CloneTipado() => this.Clone() as Paquete;
        public override string ToString() => $"{this.Codigo}-{this.Nombre} - {this.GetType().Name.ToUpper()}";
    }
}
