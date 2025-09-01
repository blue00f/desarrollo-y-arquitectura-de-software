using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO_Transaction_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_empleados_ej_transaction;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            con.Open();

            // Creo el objeto transaction
            SqlTransaction trans;
            SqlCommand com;

            // Asigno la conexión al objeto transaction
            trans = con.BeginTransaction();
            try
            {
                com = new SqlCommand("insert into empleado(id_empleado,nombre,sueldo) values(7,'JOSE',2000)", con);
                com.Transaction = trans; // Al objeto connection le paso el objeto transaction
                com.ExecuteNonQuery();

                // Comienza ejemplo para atomicidad
                com = new SqlCommand("insert into empleado(id_empleado,nombre,sueldo) values(8,'LUIS',5000)", con);
                com.Transaction = trans;
                com.ExecuteNonQuery();

                com = new SqlCommand("insert into empleado(id_empleado,nombre,sueldo) values(8,'PEDRO',4000)", con);
                com.Transaction = trans;
                com.ExecuteNonQuery();
                // Finaliza el ejemplo para atomicidad

                // Si esta todo OK la transaction se ejecuta
                trans.Commit();
                MessageBox.Show("Datos ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si no se realizó la transaction OK, se hace un rollback
                trans.Rollback();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnCargarUsandoSP_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_empleados_ej_transaction;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True"))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    EjecutarGuardarEmpleado(con, trans, 1, "PEPE", 5000);
                    EjecutarGuardarEmpleado(con, trans, 2, "MANUEL", 2500);
                    EjecutarGuardarEmpleado(con, trans, 2, "DIEGO", 6000);
                    trans.Commit();
                    MessageBox.Show("Datos ingresados correctamente");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }

        private void EjecutarGuardarEmpleado(SqlConnection pCon, SqlTransaction pTrans, int pId, string pNombre, decimal pSueldo)
        {
            using (SqlCommand com = new SqlCommand("sp_guardar_empleado", pCon))
            {
                com.Transaction = pTrans;
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id_empleado", pId).DbType = DbType.Int32;
                com.Parameters.AddWithValue("@nombre", pNombre).DbType = DbType.String;
                com.Parameters.AddWithValue("@sueldo", pSueldo).DbType = DbType.Decimal;

                SqlParameter mensaje = new SqlParameter("@message", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(mensaje);

                com.ExecuteNonQuery();
                MessageBox.Show(mensaje.Value?.ToString() ?? "Sin mensaje");
            }
        }

    }
}
