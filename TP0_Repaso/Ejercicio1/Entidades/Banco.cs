using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Banco
    {
        List<Cliente> clientes;
        List<Cuenta> cuentas;
        List<Operacion> operaciones;

        public Banco()
        {
            clientes = new List<Cliente>();
            cuentas = new List<Cuenta>();
            operaciones = new List<Operacion>();
        }

        public void AltaCliente(Cliente pCliente) => clientes.Add(pCliente);
        public void BajaCliente(Cliente pCliente)
        {
            var cliente = clientes.Find(x => x.Dni == pCliente.Dni);
            if (cliente.ObtenerCuentas().Count > 0) throw new Exception("No se puede dar de baja al cliente porque tiene asociada una cuenta!");
            if (cliente != null) clientes.Remove(cliente);
        }
        public void ModificarCliente(Cliente pCliente)
        {
            var cliente = clientes.Find(x => x.Dni == pCliente.Dni);
            if (cliente != null)
            {
                cliente.Nombre = pCliente.Nombre;
                cliente.Apellido = pCliente.Apellido;
                cliente.Telefono = pCliente.Telefono;
                cliente.Correo = pCliente.Correo;
                cliente.FechaNacimiento = pCliente.FechaNacimiento;
                cliente.Edad = pCliente.Edad;
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            var consulta = from c in clientes select c.CloneTipado();
            return consulta.ToList<Cliente>();
        }

        public List<Cliente> ObtenerClientesPorFiltro(string pDni, string pNombre)
        {
            pDni = pDni ?? string.Empty;
            pNombre = pNombre ?? string.Empty;

            var consulta = from cliente in clientes
                           where (string.IsNullOrEmpty(pDni) || cliente.Dni.StartsWith(pDni))
                              && (string.IsNullOrEmpty(pNombre) || cliente.Nombre.StartsWith(pNombre, StringComparison.OrdinalIgnoreCase))
                           select cliente;

            return consulta.ToList();
        }

        public void AltaCuenta(Cuenta pCuenta, Cliente pCliente)
        {
            cuentas.Add(pCuenta);
            var cuenta = cuentas.Find(x => x.Codigo == pCuenta.Codigo);
            var cliente = clientes.Find(x => x.Dni == pCliente.Dni);
            cuenta.AsignarCliente(cliente);
            cliente.AsignarCuenta(cuenta);
        }
        public void BajaCuenta(Cuenta pCuenta)
        {
            var cuenta = cuentas.Find(x => x.Codigo == pCuenta.Codigo);
            if (cuenta != null)
            {
                if (cuenta.Saldo != 0) throw new Exception("No se puede dar de baja porque tiene un saldo distinto a 0!");
                cuenta.Cliente.DesasignarCuenta(cuenta);
                cuenta.DesasignarCliente();
                cuentas.Remove(cuenta);
            }
        }
        public void ModificarCuenta(Cuenta pCuenta, Cliente pCliente)
        {
            var cuenta = cuentas.Find(x => x.Codigo == pCuenta.Codigo);
            var cliente = clientes.Find(x => x.Dni == pCliente.Dni);

            if (cuenta.Cliente == cliente) throw new Exception("Se está asignando a la misma persona!");

            cuenta.Cliente.DesasignarCuenta(cuenta);
            cuenta.AsignarCliente(cliente);
            cliente.AsignarCuenta(cuenta);
            if (cuenta != null) cuenta.Cliente = cliente;
        }
        public List<object> ObtenerCuentasDeUnCliente(Cliente pCliente)
        {
            var cliente = clientes.Find(x => x.Dni == pCliente.Dni);
            var consulta = from c in cliente.ObtenerCuentas()
                           select new
                           {
                               c.Codigo,
                               c.Saldo,
                               c.Cliente.Nombre,
                           };
            return consulta.ToList<object>();
        }

        public void AltaOperacion(Operacion pOperacion) => operaciones.Add(pOperacion);
        public List<object> ObtenerOperaciones()
        {
            var consulta = from ope in operaciones
                           select new
                           {
                               ope.Fecha,
                               Operacion = ope.TipoOperacion,
                               ope.Importe,
                               DNI = ope.Cuenta.Cliente.Dni,
                               CodCuenta = ope.Cuenta.Codigo
                           };
            return consulta.ToList<object>();
        }

        public bool ValidarCliente(string pDni)
        {
            bool rdo = false;
            var cliente = clientes.Find(x => x.Dni == pDni);
            if (cliente != null) rdo = true;
            return rdo;
        }
        public bool ValidarCuenta(int pCodigo)
        {
            bool rdo = false;
            var cuenta = cuentas.Find(x => x.Codigo == pCodigo);
            if (cuenta != null) rdo = true;
            return rdo;
        }

        public Cuenta RecuperarCuentaPorCodigo(int pCodigo)
        {
            var cuenta = cuentas.Find(x => x.Codigo == pCodigo);
            if (cuenta == null) throw new Exception("La cuenta no existe!");
            return cuenta;
        }
    }
}
