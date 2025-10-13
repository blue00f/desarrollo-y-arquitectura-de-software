using Microsoft.VisualBasic;
using Reso_PrimerParcial.Entidades;
using System.Diagnostics;
using System.Resources.Extensions;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Reso_PrimerParcial
{
    public partial class Form1 : Form
    {
        Empresa emp;
        Equipo eq;
        public Form1()
        {
            InitializeComponent();
            emp = new Empresa();
        }
        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null; pDGV.DataSource = pO;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar(grillaEquipos, emp.RetornaEquipos());
            Mostrar(grillaProveedores, emp.RetornaProveedores());
            Mostrar(grillaEquiposDadosDeBaja, emp.RetornaEquiposBaja());
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        #region "Servicios"
        private void txtDesde_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtDesde.Text)) txtDesde.Text = "0";
            Mostrar(grillaEquiposPorValorResidual, emp.RetornaEquiposValorResidual(Convert.ToDecimal(txtDesde.Text), Convert.ToDecimal(txtHasta.Text)));
        }

        private void txtHasta_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtHasta.Text)) txtHasta.Text = "0";
            txtDesde_TextChanged(null, null);
        }

        private void txtBusquedaPorCodigo_TextChanged(object sender, EventArgs e)
        {
            Mostrar(grillaEquiposPorCodigo, emp.RetornaEquiposCodigoIncrementral(txtBusquedaPorCodigo.Text));
        }

        private void grillaEquipos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaEquipos.Rows.Count > 0)
                {
                    var codigo = grillaEquipos.SelectedRows[0].Cells[0].Value.ToString();
                    txtProveedoresDelEquipo.Text = emp.RetornaProveedorDelEquipo(new Equipo() { Codigo = codigo });
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region "ABM Equipo"
        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                var codigo = Interaction.InputBox("Ingrese el código con el siguiente formato [EQ-2025-001]:", "Equipo");
                Equipo eq = new Equipo();

                eq.CodigoErroneo += Funcion_EventoCodigo;
                eq.Codigo = codigo;
                if (emp.ExisteEquipo(eq)) throw new Exception("El código existe !!!");

                var fechaIngreso = Interaction.InputBox("Fecha de Ingreso: ", "Equipo");
                if (!Information.IsDate(fechaIngreso)) throw new Exception("La fecha de ingreso en inválida !!!");

                var axoCompra = Interaction.InputBox("Año de Compra: ", "Equipo");
                if (!Information.IsNumeric(axoCompra) || axoCompra.Length != 4) throw new Exception("El año de compra es incorrecto !!!");

                var valorCompra = Interaction.InputBox("Valor de compra: ", "Equipo");
                if (!Information.IsNumeric(valorCompra)) throw new Exception("El valor de compra debe ser numérico !!!");

                var enUso = MessageBox.Show("¿En uso por la empresa?", "Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;

                string fechaBaja = "";
                if (enUso) fechaBaja = "01/01/2999";
                else fechaBaja = Interaction.InputBox("Fecha de Baja: ", "Equipo");
                if (!Information.IsDate(fechaBaja)) throw new Exception("La fecha de baja es inválida !!!");

                eq.FechaIngreso = Convert.ToDateTime(fechaIngreso);
                eq.AxoCompra = Convert.ToInt32(axoCompra);
                eq.ValorDeCompra = Convert.ToDecimal(valorCompra);
                eq.EnUso = Convert.ToBoolean(enUso);
                eq.FechaBaja = Convert.ToDateTime(fechaBaja);
                emp.AgregarEquipo(eq);

                Mostrar(grillaEquipos, emp.RetornaEquipos());
                Mostrar(grillaEquiposDadosDeBaja, emp.RetornaEquiposBaja());
                Mostrar(grillaEquiposDelete, emp.RetornaEquiposDelete());
                Mostrar(grillaEquiposUpdate, emp.RetornaEquiposUpdate());
                Mostrar(grillaEquipoInsert, emp.RetornaEquiposInsert());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrarEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaEquipos.Rows.Count == 0) throw new Exception("No hay equipos para borrar !!!");
                Equipo equipo = new Equipo();
                equipo = ReconstruirObjetoEquipo(equipo);

                emp.BorrarEquipo(equipo);
                Mostrar(grillaEquipos, emp.RetornaEquipos());
                Mostrar(grillaEquiposDadosDeBaja, emp.RetornaEquiposBaja());
                Mostrar(grillaEquiposDelete, emp.RetornaEquiposDelete());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificarEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaEquipos.Rows.Count == 0) throw new Exception("No hay equipos para modificar !!!");
                Equipo equipo = new Equipo();
                Equipo equipoNuevo = new Equipo();
                equipo = ReconstruirObjetoEquipo(equipo);

                var fechaIngreso = Interaction.InputBox("Fecha de Ingreso: ", "Equipo", equipo.FechaIngreso.ToShortDateString());
                if (!Information.IsDate(fechaIngreso)) throw new Exception("La fecha de ingreso en inválida !!!");

                var axoCompra = Interaction.InputBox("Año de Compra: ", "Equipo", equipo.AxoCompra.ToString());
                if (!Information.IsNumeric(axoCompra) || axoCompra.Length != 4) throw new Exception("El año de compra es incorrecto !!!");

                var valorCompra = Interaction.InputBox("Valor de compra: ", "Equipo", equipo.ValorDeCompra.ToString());
                if (!Information.IsNumeric(valorCompra)) throw new Exception("El valor de compra debe ser numérico !!!");

                var enUso = MessageBox.Show("¿En uso por la empresa?", "Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, equipo.EnUso ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;

                string fechaBaja = "";
                if (enUso) fechaBaja = "01/01/2999";
                else fechaBaja = Interaction.InputBox("Fecha de Baja: ", "Equipo", DateTime.Now.ToShortDateString());
                if (!Information.IsDate(fechaBaja)) throw new Exception("La fecha de baja es inválida !!!");

                equipoNuevo.Codigo = equipo.Codigo;
                equipoNuevo.FechaIngreso = Convert.ToDateTime(fechaIngreso);
                equipoNuevo.AxoCompra = Convert.ToInt32(axoCompra);
                equipoNuevo.ValorDeCompra = Convert.ToDecimal(valorCompra);
                equipoNuevo.EnUso = Convert.ToBoolean(enUso);
                equipoNuevo.FechaBaja = Convert.ToDateTime(fechaBaja);

                emp.ModificarEquipo(equipoNuevo);
                Mostrar(grillaEquipos, emp.RetornaEquipos());
                Mostrar(grillaEquiposDadosDeBaja, emp.RetornaEquiposBaja());
                Mostrar(grillaEquiposUpdate, emp.RetornaEquiposUpdate());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Equipo ReconstruirObjetoEquipo(Equipo pEquipo)
        {
            pEquipo.Codigo = grillaEquipos.SelectedRows[0].Cells[0].Value.ToString();
            pEquipo.FechaIngreso = Convert.ToDateTime(grillaEquipos.SelectedRows[0].Cells[5].Value);
            pEquipo.FechaBaja = Convert.ToDateTime(grillaEquipos.SelectedRows[0].Cells[6].Value);
            pEquipo.AxoCompra = Convert.ToInt32(grillaEquipos.SelectedRows[0].Cells[1].Value);
            pEquipo.EnUso = Convert.ToBoolean(grillaEquipos.SelectedRows[0].Cells[3].Value);
            pEquipo.ValorDeCompra = Convert.ToDecimal(grillaEquipos.SelectedRows[0].Cells[4].Value);

            return pEquipo;
        }
        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
            emp.Guardar();
            Mostrar(grillaEquiposDelete, emp.RetornaEquiposDelete());
            Mostrar(grillaEquiposUpdate, emp.RetornaEquiposUpdate());
            Mostrar(grillaEquipoInsert, emp.RetornaEquiposInsert());
        }
        private void btnVerXml_Click(object sender, EventArgs e)
        {
            emp.GuardarXML();
            Process.Start(new ProcessStartInfo("datos.xml") { UseShellExecute = true });
        }
        private void Funcion_EventoCodigo(object sender, EventArgs e) => throw new Exception("El código no responde a la forma solicitada !!!");
        #endregion

        #region "ABM Proveedor"
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                string id = Interaction.InputBox("Ingresa el ID:", "Proveedor");
                if (id.Length == 0) throw new Exception("Está vacío !!!");
                proveedor.Id = id;
                if (emp.ExisteProveedor(proveedor)) throw new Exception("El ID está repetido !!!");

                string nombre = Interaction.InputBox("Ingresa el nombre", "Proveedor");
                if (nombre.Length == 0) throw new Exception("Está vacío !!!");

                string direccion = Interaction.InputBox("Ingresa la dirección", "Proveedor");
                if (direccion.Length == 0) throw new Exception("Está vacío !!!");

                proveedor.Nombre = nombre;
                proveedor.Direccion = direccion;

                emp.AgregarProveedor(proveedor);
                Mostrar(grillaProveedores, emp.RetornaProveedores());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaProveedores.Rows.Count == 0) throw new Exception("No hay proveedores para borrar !!!");
                Proveedor proveedor = new Proveedor();
                proveedor.Id = grillaProveedores.SelectedRows[0].Cells[0].Value.ToString();
                proveedor.Nombre = grillaProveedores.SelectedRows[0].Cells[1].Value.ToString();
                proveedor.Direccion = grillaProveedores.SelectedRows[0].Cells[2].Value.ToString();

                emp.BorrarProveedor(proveedor);
                Mostrar(grillaProveedores, emp.RetornaProveedores());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaProveedores.Rows.Count == 0) throw new Exception("No hay proveedores para modificar !!!");
                Proveedor proveedor = new Proveedor();
                proveedor.Id = grillaProveedores.SelectedRows[0].Cells[0].Value.ToString();
                proveedor.Nombre = grillaProveedores.SelectedRows[0].Cells[1].Value.ToString();
                proveedor.Direccion = grillaProveedores.SelectedRows[0].Cells[2].Value.ToString();

                Proveedor proveedorNuevo = new Proveedor();
                string nombre = Interaction.InputBox("Ingresa el nombre", "Proveedor", proveedor.Nombre);
                if (nombre.Length == 0) throw new Exception("Está vacío !!!");

                string direccion = Interaction.InputBox("Ingresa la dirección", "Proveedor", proveedor.Direccion);
                if (direccion.Length == 0) throw new Exception("Está vacío !!!");

                proveedorNuevo.Id = proveedor.Id;
                proveedorNuevo.Nombre = nombre;
                proveedorNuevo.Direccion = direccion;

                emp.ModificarProveedor(proveedorNuevo);
                Mostrar(grillaProveedores, emp.RetornaProveedores());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnAsignarProveedorAlEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaEquipos.Rows.Count == 0) throw new Exception("No hay equipos !!!");
                if (grillaProveedores.Rows.Count == 0) throw new Exception("No hay proveedores !!!");

                Equipo equipo = new Equipo();
                Proveedor proveedor = new Proveedor();

                equipo = ReconstruirObjetoEquipo(equipo);
                proveedor.Id = grillaProveedores.SelectedRows[0].Cells[0].Value.ToString();
                proveedor.Nombre = grillaProveedores.SelectedRows[0].Cells[1].Value.ToString();
                proveedor.Direccion = grillaProveedores.SelectedRows[0].Cells[2].Value.ToString();

                string nombreTecnico = Interaction.InputBox("Ingrese el nombre del técnico que le hará mantenimiento al equipo:", "Asignación entre el equipo y el proveedor");
                if (nombreTecnico.Length == 0) throw new Exception("El nombre del técnico está vacio !!!");

                EquipoProveedor equipoProveedor = new EquipoProveedor();
                equipoProveedor.Equipo = equipo;
                equipoProveedor.Proveedor = proveedor;
                equipoProveedor.NombreTecnico = nombreTecnico;

                emp.AsignarProveedorAlEquipo(equipoProveedor);
                grillaEquipos_RowEnter(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
