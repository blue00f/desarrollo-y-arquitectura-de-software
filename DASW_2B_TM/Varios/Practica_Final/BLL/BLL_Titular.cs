using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Titular : IABMC<BE_Titular>
    {
        ORM_Titular _orm;
        public BLL_Titular() => _orm = new ORM_Titular();
        public void Agregar(BE_Titular obj) => _orm.Agregar(obj);
        public void Borrar(BE_Titular obj) => _orm.Borrar(obj);
        public void Modificar(BE_Titular obj) => _orm.Modificar(obj);
        public List<BE_Titular> Consultar() => _orm.Consultar();
        public bool ValidarCodigoRepetido(BE_Titular obj) => _orm.ValidarCodigoRepetido(obj);
        public List<BE_Cuenta> ConsultarCuentas(BE_Titular pTitular) => _orm.ConsultarCuentas(pTitular);
        public List<object> ConsultarCuentasAnonimo(BE_Titular pTitular)
        {
            var consulta = from c in ConsultarCuentas(pTitular)
                           select new
                           {
                               Codigo = c.Codigo,
                               Saldo = c.Saldo,
                               Descubierto = (c is BE_CajaAhorro) ? "-" : ((BE_Corriente)c).Descubierto.ToString(),
                               Tipo = (c is BE_CajaAhorro) ? "Caja de ahorro" : "Cuenta corriente"
                           };
            return consulta.ToList<object>();
        }
    }
}
