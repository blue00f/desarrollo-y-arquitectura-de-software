using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    public class Empresa
    {
        List<Cliente> clientes;
        List<Paquete> paquetes;

        public Empresa()
        {
            clientes = new List<Cliente>();
            paquetes = new List<Paquete>();
        }

        #region "ABM-C Cliente"
        public void AgregarCliente(Cliente pCliente) => clientes.Add(pCliente);
        public void BorrarCliente(Cliente pCliente)
        {
            var cliente = clientes.Find(x => x.Codigo == pCliente.Codigo);
            if (cliente != null) clientes.Remove(cliente);
        }
        public void ModificarCliente(Cliente pCliente)
        {
            var cliente = clientes.Find(x => x.Codigo == pCliente.Codigo);
            if (cliente != null)
            {
                cliente.Nombre = pCliente.Nombre;
                cliente.Apellido = pCliente.Apellido;
                cliente.Dni = pCliente.Dni;
                cliente.FechaNacimiento = pCliente.FechaNacimiento;
            }
        }
        public List<Cliente> ObtenerClientes() => (from c in clientes select c.CloneTipado()).ToList<Cliente>();
        #endregion

        #region "ABM-C Paquetes"
        public void AgregarPaquete(Paquete pPaquete) => paquetes.Add(pPaquete);
        public void BorrarPaquete(Paquete pPaquete)
        {
            var paquete = paquetes.Find(x => x.Nombre == pPaquete.Nombre);
            if (paquete != null) paquetes.Remove(paquete);
        }
        public void ModificarPaquete(Paquete pPaquete)
        {
            var paquete = paquetes.Find(x => x.Codigo == pPaquete.Codigo);
            if (paquete != null)
            {
                paquete.Nombre = pPaquete.Nombre;
                paquete.Importe = pPaquete.Importe;
            }
        }
        public List<Paquete> ObtenerPaquetes() => (from p in paquetes select p.CloneTipado()).ToList<Paquete>();
        #endregion

        #region "Métodos de comportamiento entre objetos"

        public void AsignarClienteConPaquete(Cliente pCliente, Paquete pPaquete)
        {
            var cliente = clientes.Find(x => x.Codigo == pCliente.Codigo);
            var paquete = paquetes.Find(x => x.Codigo == pPaquete.Codigo);

            if(cliente != null && paquete != null)
            {
                var clienteAComparar = paquete.ObtenerClientes().Find(x => x.Codigo == cliente.Codigo);
                if (clienteAComparar != null) throw new Exception("El cliente ya tiene este paquete!");
                cliente.ComprarPaquete(paquete);
                paquete.AsignarCliente(cliente);
            }
        }
        #endregion

        #region "Métodos de servicio"
        public bool ExistenVentas()
        {
            bool rdo = false;
            var paquete = paquetes.FirstOrDefault(x => x.ObtenerClientes() != null);
            if (paquete != null) rdo = true;
            return rdo;
        }
        public bool ValidarCodigoCliente(string pCodigo)
        {
            bool rdo = false;
            var cliente = clientes.Find(x => x.Codigo == pCodigo);
            if (cliente != null) rdo = true;
            return rdo;
        }
        public bool ValidarCodigoPaquete(int pCodigo)
        {
            bool rdo = false;
            var paquete = paquetes.Find(x => x.Codigo == pCodigo);
            if (paquete != null) rdo = true;
            return rdo;
        }
        public Cliente BuscarClientePorCodigo(string pCodigo)
        {
            Cliente cliente = clientes.Find(x => x.Codigo == pCodigo);
            if (cliente == null) throw new Exception("Cliente no encontrado!");
            else return cliente;
        }
        public Paquete BuscarPaquetePorCodigo(int pCodigo)
        {
            Paquete paquete = paquetes.Find(x => x.Codigo == pCodigo);
            if (paquete == null) throw new Exception("Paquete no encontrado!");
            else return paquete;
        }
        public Canal ObtenerCanalPorCodigo(string pCodigo)
        {
            Canal canalFiltrado = null;
            foreach (var p in paquetes)
            {
                canalFiltrado = p.ObtenerCanales().Find(x => x.Codigo == pCodigo);
                if (canalFiltrado != null) break;
            }
            if (canalFiltrado == null) throw new Exception("El canal no existe!");
            return canalFiltrado;
        }
        #endregion

        #region "Consultas LINQ"
        public List<object> ObtenerInformacionDelPaquete(Paquete pPaquete)
        {
            var paquete = paquetes.Find(x => x.Codigo == pPaquete.Codigo);
            if (paquete == null) throw new Exception("El paquete no existe!");


            var consulta = from s in paquete.MostrarSeries()
                           select new
                           {
                               s.Nombre,
                               s.CantTemporadas,
                               s.CantEpisodios,
                               s.TipoGenero,
                           };
            return consulta.ToList<object>();
        }
        public List<object> ObtenerComprasDelCliente(Cliente pCliente)
        {
            var cliente = clientes.Find(x => x.Codigo == pCliente.Codigo);
            if (cliente == null) throw new Exception("El cliente no existe!");

            var consulta = from p in cliente.ObtenerPaquetes()
                           select new
                           {
                               Cliente = $"{cliente.Nombre} {cliente.Apellido}",
                               Edad = DateTime.Today.Year - cliente.FechaNacimiento.Year - (DateTime.Today < cliente.FechaNacimiento.AddYears(DateTime.Today.Year - cliente.FechaNacimiento.Year) ? 1 : 0),
                               Paquete = p.Nombre,
                               Tipo = p.GetType().Name,
                               TotalAbonado = p.Importe + p.Abono,
                           };
            return consulta.ToList<object>();
        }
        public List<object> ObtenerSeriesConRanking()
        {
            decimal filtroRanking = 3.5m;
            var seriesFiltradas = new List<object>();
            foreach (var p in paquetes)
            {
                var consulta = from s in p.MostrarSeries() where s.Ranking > filtroRanking
                               select new
                               {
                                   Serie = s.Nombre,
                                   Temporadas = s.CantTemporadas,
                                   Episodios = s.CantEpisodios,
                                   Ranking = s.Ranking,
                                   Genero = s.TipoGenero,
                                   Director = s.Director,
                               };
                seriesFiltradas.AddRange(consulta.Cast<object>());
            }
            return seriesFiltradas;
        }
        public decimal ObtenerTotalRecaudado()
        {
            decimal totalRecaudado = 0;
            foreach (var c in clientes)
            {
                foreach (var p in c.ObtenerPaquetes())
                {
                    totalRecaudado += p.Importe + p.Abono;
                }
            }
            return totalRecaudado;
        }

        public List<object> ObtenerInfoPaqueteMasVendido()
        {
            var paqueteMasVendido = paquetes.OrderByDescending(x => x.ObtenerClientes().Count).FirstOrDefault();
            if (paqueteMasVendido == null) throw new Exception("No se encontró el paquete más vendido");
            var consulta = from s in paqueteMasVendido.MostrarSeries()
                           select new
                           {
                               Paquete = paqueteMasVendido.Nombre,
                               Tipo = paqueteMasVendido.GetType().Name,
                               Serie = s.Nombre,
                               Genero = s.TipoGenero,
                               Ranking = s.Ranking,
                           };
            return consulta.ToList<object>();
        }
        #endregion
    }
}
