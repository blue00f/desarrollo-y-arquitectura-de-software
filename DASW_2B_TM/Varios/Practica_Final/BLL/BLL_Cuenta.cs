using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Cuenta : IABMC<BE_Cuenta>
    {
        ORM_Cuenta _orm;
        public BLL_Cuenta() => _orm = new ORM_Cuenta();
        public void Agregar(BE_Cuenta obj) => _orm.Agregar(obj);
        public void Borrar(BE_Cuenta obj) => _orm.Borrar(obj);
        public void Modificar(BE_Cuenta obj) => _orm.Modificar(obj);
        public List<BE_Cuenta> Consultar() => _orm.Consultar();
        public List<object> ConsultarCuentas()
        {
            var consulta = from c in Consultar()
                           select new
                           {
                               Codigo = c.Codigo,
                               Saldo = c.Saldo,
                               Descubierto = (c is BE_CajaAhorro) ? "-" : ((BE_Corriente)c).Descubierto.ToString(),
                               Tipo = (c is BE_CajaAhorro) ? "Caja de ahorro" : "Cuenta corriente"
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaTotalOrdenado()
        {
            var consulta = from c in Consultar()
                           orderby c.Saldo + ((c is BE_CajaAhorro) ? 0 : ((BE_Corriente)c).Descubierto) descending
                           select new
                           {
                               Codigo = c.Codigo,
                               Saldo = c.Saldo,
                               Descubierto = (c is BE_CajaAhorro) ? "-" : ((BE_Corriente)c).Descubierto.ToString(),
                               Total = c.Saldo + ((c is BE_CajaAhorro) ? 0 : ((BE_Corriente)c).Descubierto),
                               Tipo = (c is BE_CajaAhorro) ? "Caja de ahorro" : "Cuenta corriente"
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaDesdeHastaPorSaldo(decimal pDesde, decimal pHasta)
        {
            var consulta = from c in Consultar()
                           where c.Saldo >= pDesde && c.Saldo <= pHasta
                           orderby c.Saldo descending
                           select new
                           {
                               Codigo = c.Codigo,
                               Saldo = c.Saldo,
                               Descubierto = (c is BE_CajaAhorro) ? "-" : ((BE_Corriente)c).Descubierto.ToString(),
                               Tipo = (c is BE_CajaAhorro) ? "Caja de ahorro" : "Cuenta corriente"
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaIncrementalPorCodigo(string pCodigo)
        {
            var consulta = from c in Consultar()
                           where c.Codigo.StartsWith(pCodigo, StringComparison.OrdinalIgnoreCase)
                           select new
                           {
                               Codigo = c.Codigo,
                               Saldo = c.Saldo,
                               Descubierto = (c is BE_CajaAhorro) ? "-" : ((BE_Corriente)c).Descubierto.ToString(),
                               Tipo = (c is BE_CajaAhorro) ? "Caja de ahorro" : "Cuenta corriente"
                           };
            return consulta.ToList<object>();
        }

        public bool ValidarCodigoRepetido(BE_Cuenta obj) => _orm.ValidarCodigoRepetido(obj);
        public BE_Cuenta RecuperarCuentaPorId(string pCodigo)
        {
            BE_Cuenta cuenta = null;
            foreach (var c in Consultar())
            {
                if (c.Codigo == pCodigo) cuenta = c;
            }
            return cuenta;
        }

        public void AsignarTitular(BE_Cuenta pCuenta, BE_Titular pTitular) => _orm.AsignarTitular(pCuenta, pTitular);
        public List<BE_Titular> ConsultarTitulares(BE_Cuenta pCuenta) => _orm.ConsultarTitulares(pCuenta);

        public void Depositar(BE_Cuenta pCuenta, decimal pMonto) => _orm.Depositar(pCuenta, pMonto);
        public void Extraer(BE_Cuenta pCuenta, decimal pMonto)
        {
            if (pCuenta is BE_CajaAhorro ca)
            {
                if (pMonto > ca.Saldo) throw new Exception("No hay saldo suficiente!");
                _orm.Extraer(pCuenta, pMonto);
            }
            else if (pCuenta is BE_Corriente cc)
            {
                if (pMonto > (cc.Saldo + cc.Descubierto)) throw new Exception("No hay saldo suficiente!");
                _orm.Extraer(pCuenta, pMonto);
            }
        }
        public void Transferir(BE_Cuenta pOrigen, BE_Cuenta pDestino, decimal pMonto)
        {
            if (pOrigen is BE_CajaAhorro ca)
            {
                if (pMonto > ca.Saldo) throw new Exception("No hay saldo suficiente!");
                _orm.Transferir(pOrigen, pDestino, pMonto);
            }
            else if (pOrigen is BE_Corriente cc)
            {
                if (pMonto > (cc.Saldo + cc.Descubierto)) throw new Exception("No hay saldo suficiente!");
                _orm.Transferir(pOrigen, pDestino, pMonto);
            }
        }
        public void GuardarXml() => _orm.GuardarXml();
    }
}
