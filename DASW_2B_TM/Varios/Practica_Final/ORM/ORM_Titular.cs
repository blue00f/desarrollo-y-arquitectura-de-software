using BE;
using DAL;
using Interfaces;
using System.Data;

namespace ORM
{
    public class ORM_Titular : IABMC<BE_Titular>
    {
        DAO _dao;
        const string tabla = "titular";
        public ORM_Titular()
        {
            _dao = DAO.instancia;
        }
        public void Agregar(BE_Titular obj) => _dao.Agregar(tabla, obj.Dni, obj.Nombre, obj.Apellido);

        public void Borrar(BE_Titular obj) => _dao.Borrar(tabla, obj.Dni);
        public void Modificar(BE_Titular obj)
        {
            DataTable dt = _dao.Consultar(tabla);
            DataRow fila = dt.Rows.Find(obj.Dni);
            if (fila != null)
            {
                fila[1] = obj.Nombre;
                fila[2] = obj.Apellido;
            }
            _dao.Actualizar(tabla);
        }

        public List<BE_Titular> Consultar()
        {
            DataTable dt = _dao.Consultar(tabla);
            var titulares = new List<BE_Titular>();
            foreach (DataRow f in dt.Rows)
            {
                titulares.Add(new BE_Titular(
                    f.Field<string>(0),
                    f.Field<string>(1),
                    f.Field<string>(2)
                ));
            }
            return titulares;
        }

        public bool ValidarCodigoRepetido(BE_Titular obj)
        {
            bool rdo = false;
            foreach (var t in Consultar())
            {
                if (t.Dni == obj.Dni) rdo = true;
            }
            return rdo;
        }
        public List<BE_Cuenta> ConsultarCuentas(BE_Titular pTitular)
        {
            DataTable dt1 = _dao.Consultar("cajaahorroxtitular");
            DataTable dt2 = _dao.Consultar("cuentacorrientextitular");
            var cuentas = new List<BE_Cuenta>();

            foreach (DataRow f in dt1.Rows)
            {
                if (f.Field<string>(0) == pTitular.Dni)
                {
                    cuentas.Add(ReconstruirCuenta(f.Field<string>(1)));
                }
            }
            foreach (DataRow f in dt2.Rows)
            {
                if (f.Field<string>(0) == pTitular.Dni)
                {
                    cuentas.Add(ReconstruirCuenta(f.Field<string>(1)));
                }
            }
            return cuentas;
        }
        private BE_Cuenta ReconstruirCuenta(string pCodigo)
        {
            BE_Cuenta cuenta = null;
            DataTable dtCA = _dao.Consultar("cajaahorro");
            DataRow filaCA = dtCA.Rows.Find(pCodigo);

            if (filaCA != null)
            {
                cuenta = new BE_CajaAhorro(filaCA.Field<string>(0), filaCA.Field<decimal>(1));
            }

            DataTable dtCC = _dao.Consultar("cuentacorriente");
            DataRow filaCC = dtCC.Rows.Find(pCodigo);
            if (filaCC != null)
            {
                cuenta = new BE_Corriente(filaCC.Field<string>(0), filaCC.Field<decimal>(1), filaCC.Field<decimal>(2));
            }
            return cuenta;
        }
    }
}
