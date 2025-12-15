using BE;
using DAL;
using Interfaces;
using System.Data;

namespace ORM
{
    public class ORM_Cuenta : IABMC<BE_Cuenta>
    {
        DAO _dao;
        const string tablaCC = "cuentacorriente";
        const string tablaCA = "cajaahorro";
        public ORM_Cuenta()
        {
            _dao = DAO.instancia;
        }
        public void Agregar(BE_Cuenta obj)
        {
            if (obj is BE_Corriente cc) _dao.Agregar(tablaCC, cc.Codigo, cc.Saldo, cc.Descubierto);
            if (obj is BE_CajaAhorro ca) _dao.Agregar(tablaCA, ca.Codigo, ca.Saldo);
        }

        public void Borrar(BE_Cuenta obj)
        {
            if (obj is BE_Corriente) _dao.Borrar(tablaCC, obj.Codigo);
            if (obj is BE_CajaAhorro) _dao.Borrar(tablaCA, obj.Codigo);
        }
        public void Modificar(BE_Cuenta obj)
        {
            if(obj is BE_Corriente cc)
            {
                DataTable dt = _dao.Consultar(tablaCC);
                DataRow fila = dt.Rows.Find(cc.Codigo);
                if (fila != null)
                {
                    fila[1] = cc.Saldo;
                    fila[2] = cc.Descubierto;
                }
                _dao.Actualizar(tablaCC);
            }
            if (obj is BE_CajaAhorro ca)
            {
                DataTable dt = _dao.Consultar(tablaCA);
                DataRow fila = dt.Rows.Find(ca.Codigo);
                if (fila != null) fila[1] = ca.Saldo;
                _dao.Actualizar(tablaCA);
            }
        }
        public List<BE_Cuenta> Consultar()
        {
            var cuentas = new List<BE_Cuenta>();

            DataTable dtCC = _dao.Consultar(tablaCC);
            foreach (DataRow f in dtCC.Rows)
            {
                cuentas.Add(new BE_Corriente(
                    f.Field<string>(0),
                    f.Field<decimal>(1),
                    f.Field<decimal>(2)
                ));
            }
            DataTable dtCA = _dao.Consultar(tablaCA);
            foreach (DataRow f in dtCA.Rows)
            {
                cuentas.Add(new BE_CajaAhorro(
                    f.Field<string>(0),
                    f.Field<decimal>(1)
                ));
            }
            return cuentas;
        }

        public bool ValidarCodigoRepetido(BE_Cuenta obj)
        {
            bool rdo = false;
            foreach (var c in Consultar())
            {
                if (c.Codigo == obj.Codigo) rdo = true;
            }
            return rdo;
        }

        public void AsignarTitular(BE_Cuenta pCuenta, BE_Titular pTitular)
        {
            if (pCuenta is BE_Corriente cc) _dao.Agregar("cuentacorrientextitular", pTitular.Dni, cc.Codigo);
            if (pCuenta is BE_CajaAhorro ca) _dao.Agregar("cajaahorroxtitular", pTitular.Dni, ca.Codigo);
        }

        public List<BE_Titular> ConsultarTitulares(BE_Cuenta pCuenta)
        {
            var titulares = new List<BE_Titular>();
            if (pCuenta is BE_Corriente cc)
            {
                DataTable dt = _dao.Consultar("cuentacorrientextitular");
                foreach (DataRow f in dt.Rows)
                {
                    if (f.Field<string>(1) == pCuenta.Codigo) titulares.Add(ReconstruirTitular(f.Field<string>(0)));
                }
            }
            else
            {
                DataTable dt = _dao.Consultar("cajaahorroxtitular");
                foreach (DataRow f in dt.Rows)
                {
                    if (f.Field<string>(1) == pCuenta.Codigo) titulares.Add(ReconstruirTitular(f.Field<string>(0)));
                }
            }
            return titulares;
        }
        private BE_Titular ReconstruirTitular(string pDni)
        {
            DataTable dt = _dao.Consultar("titular");
            DataRow fila = dt.Rows.Find(pDni);
            BE_Titular titular = new BE_Titular(fila.Field<string>(0), fila.Field<string>(1), fila.Field<string>(2));
            return titular;
        }

        public void Depositar(BE_Cuenta pCuenta, decimal pMonto)
        {
            if (pCuenta is BE_CajaAhorro ca)
            {
                DataTable dt = _dao.Consultar(tablaCA);
                DataRow fila = dt.Rows.Find(ca.Codigo);
                if (fila != null)
                {
                    fila[1] = fila.Field<decimal>(1) + pMonto;
                }
                _dao.Actualizar(tablaCA);
            }
            else
            {
                DataTable dt = _dao.Consultar(tablaCC);
                DataRow fila = dt.Rows.Find(pCuenta.Codigo);
                if (fila != null)
                {
                    fila[1] = fila.Field<decimal>(1) + pMonto;
                }
                _dao.Actualizar(tablaCC);
            }
        }
        public void Extraer(BE_Cuenta pCuenta, decimal pMonto)
        {
            if (pCuenta is BE_CajaAhorro ca)
            {
                DataTable dt = _dao.Consultar(tablaCA);
                DataRow fila = dt.Rows.Find(ca.Codigo);
                if (fila != null)
                {
                    fila[1] = fila.Field<decimal>(1) - pMonto;
                }
                _dao.Actualizar(tablaCA);
            }
            else
            {
                DataTable dt = _dao.Consultar(tablaCC);
                DataRow fila = dt.Rows.Find(pCuenta.Codigo);
                if (fila != null)
                {
                    fila[1] = fila.Field<decimal>(1) - pMonto;
                }
            }
        }
        public void Transferir(BE_Cuenta pOrigen, BE_Cuenta pDestino, decimal pMonto)
        {
            Extraer(pOrigen, pMonto);
            Depositar(pDestino, pMonto);
        }
        public void GuardarXml() => _dao.GuardarXml();
    }
}
