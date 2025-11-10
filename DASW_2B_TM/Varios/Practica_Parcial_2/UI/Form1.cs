using BE;
using BLL;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace UI
{
    public partial class Form1 : Form
    {
        BLL_Equipo bllEquipo;
        BLL_Proveedor bllProveedor;
        BLL_Equipoxproveedor bllEquipoxproveedor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            ctrlEquipo.Agregar += ctrlEquipo_Agregar;
            ctrlEquipo.Borrar += ctrlEquipo_Borrar;
            ctrlEquipo.Modificar += ctrlEquipo_Modificar;

            ctrlProveedor.Agregar += ctrlProveedor_Agregar;
            ctrlProveedor.Borrar += ctrlProveedor_Borrar;
            ctrlProveedor.Modificar += ctrlProveedor_Modificar;

            bllEquipo = new BLL_Equipo();
            bllProveedor = new BLL_Proveedor();
            bllEquipoxproveedor = new BLL_Equipoxproveedor();

            ctrlEquipo.CargarDatos<object>(bllEquipo.ConsultaPersonalizada1());
            ctrlProveedor.CargarDatos<BE_Proveedor>(bllProveedor.Consultar());
            Mostrar(grillaEquipoProveedor, bllEquipoxproveedor.Consultar());

            Mostrar(grillaDadosDeBaja, bllEquipo.ConsultaDadosDeBajaAsc());
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }
        private void Funcion_AlertaCodigoIncorrecto(object? sender, EventArgs e)
        {
            MessageBox.Show("El formato del código es incorrecto!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            throw new Exception("Se cancela la operación!");
        }

        private void ctrlEquipo_Agregar(object? sender, EventArgs e)
        {
            try
            {
                string codigo = Interaction.InputBox("Ingrese el código", "Equipo");
                BE_Equipo equipoAux = new BE_Equipo();
                equipoAux.AlertaCodigoIncorrecto += Funcion_AlertaCodigoIncorrecto;
                equipoAux.Codigo = codigo;
                if (bllEquipo.ValidarCodigoRepetido(equipoAux)) throw new Exception("El código está repetido!");

                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de ingreso", "Equipo", DateTime.Now.ToShortDateString()));
                bool enUso = MessageBox.Show("¿Está en uso por la empresa?", "Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                DateTime fechaBaja;
                if (enUso) fechaBaja = Convert.ToDateTime("01-01-2999");
                else
                {
                    fechaBaja = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de baja", "Equipo", DateTime.Now.ToShortDateString()));
                    if (fechaBaja < fechaIngreso) throw new Exception("La fecha de baja es anterior a la fecha de ingreso!");
                }
                string inputAxoCompra = Interaction.InputBox("Ingrese el año de compra", "Equipo");
                if (!int.TryParse(inputAxoCompra, out int axoCompra)) throw new Exception("El año de compra es inválido!");
                string inputValorCompra = Interaction.InputBox("Ingrese el valor de compra", "Equipo");
                if (!decimal.TryParse(inputValorCompra, out decimal valorCompra)) throw new Exception("El valor de compra es inválido!");
                if (valorCompra < 0) throw new Exception("El valor de compra es negativo!");
                BE_Equipo equipo = new BE_Equipo(codigo, fechaIngreso, fechaBaja, axoCompra, enUso, valorCompra);
                bllEquipo.Agregar(equipo);
                Mostrar(grillaEquiposAdded, bllEquipo.ConsultarAdded());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlEquipo_Borrar(object? sender, EventArgs e)
        {
            try
            {
                var equipo = bllEquipo.RecuperarEquipoPorCodigo(ctrlEquipo.ObtenerCodigo());
                bllEquipo.Borrar(equipo);
                Mostrar(grillaEquiposDeleted, bllEquipo.ConsultarDeleted());
                ctrlEquipo.CargarDatos<object>(bllEquipo.ConsultaPersonalizada1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlEquipo_Modificar(object? sender, EventArgs e)
        {
            try
            {
                var equipoViejo = bllEquipo.RecuperarEquipoPorCodigo(ctrlEquipo.ObtenerCodigo());
                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de ingreso", "Equipo", equipoViejo.FechaIngreso.ToShortDateString()));
                bool enUso = MessageBox.Show("¿Está en uso por la empresa?", "Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, equipoViejo.EnUso ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;
                DateTime fechaBaja;
                if (enUso) fechaBaja = Convert.ToDateTime("01-01-2999");
                else
                {
                    fechaBaja = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de baja", "Equipo", DateTime.Now.ToShortDateString()));
                    if (fechaBaja < fechaIngreso) throw new Exception("La fecha de baja es anterior a la fecha de ingreso!");
                }
                string inputAxoCompra = Interaction.InputBox("Ingrese el año de compra", "Equipo", equipoViejo.AxoCompra.ToString());
                if (!int.TryParse(inputAxoCompra, out int axoCompra)) throw new Exception("El año de compra es inválido!");
                string inputValorCompra = Interaction.InputBox("Ingrese el valor de compra", "Equipo", equipoViejo.ValorCompra.ToString());
                if (!decimal.TryParse(inputValorCompra, out decimal valorCompra)) throw new Exception("El valor de compra es inválido!");
                if (valorCompra < 0) throw new Exception("El valor de compra es negativo!");
                BE_Equipo equipo = new BE_Equipo(equipoViejo.Codigo, fechaIngreso, fechaBaja, axoCompra, enUso, valorCompra);
                bllEquipo.Modificar(equipo);
                Mostrar(grillaEquiposModified, bllEquipo.ConsultarModified());
                ctrlEquipo.CargarDatos<object>(bllEquipo.ConsultaPersonalizada1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlProveedor_Agregar(object? sender, EventArgs e)
        {
            try
            {
                string codigo = Interaction.InputBox("Ingrese el código", "Proveedor");
                var proveedorAux = new BE_Proveedor(codigo);
                if (bllProveedor.ValidarCodigoRepetido(proveedorAux)) throw new Exception("El código está repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Proveedor");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string direccion = Interaction.InputBox("Ingrese la dirección", "Proveedor");
                if (direccion.Length == 0) throw new Exception("La dirección está vacia!");

                var proveedor = new BE_Proveedor(codigo, nombre, direccion);
                bllProveedor.Agregar(proveedor);
                ctrlProveedor.CargarDatos<BE_Proveedor>(bllProveedor.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlProveedor_Borrar(object? sender, EventArgs e)
        {
            try
            {
                var proveedor = ctrlProveedor.ObtenerSeleccionado<BE_Proveedor>();
                bllProveedor.Borrar(proveedor);
                ctrlProveedor.CargarDatos<BE_Proveedor>(bllProveedor.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlProveedor_Modificar(object? sender, EventArgs e)
        {
            try
            {
                var proveedorViejo = ctrlProveedor.ObtenerSeleccionado<BE_Proveedor>();
                string nombre = Interaction.InputBox("Ingrese el nombre", "Proveedor", proveedorViejo.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string direccion = Interaction.InputBox("Ingrese la dirección", "Proveedor", proveedorViejo.Direccion);
                if (direccion.Length == 0) throw new Exception("La dirección está vacia!");

                var proveedor = new BE_Proveedor(proveedorViejo.Codigo, nombre, direccion);
                bllProveedor.Modificar(proveedor);
                ctrlProveedor.CargarDatos<BE_Proveedor>(bllProveedor.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                var equipo = ctrlEquipo.ObtenerSeleccionado<BE_Equipo>();
                var proveedor = ctrlProveedor.ObtenerSeleccionado<BE_Proveedor>();

                string nombre = Interaction.InputBox("Ingrese el nombre del técnico", "Equipo y Proveedor");
                if (nombre.Length == 0) throw new Exception("El nombre está vacío!");
                string apellido = Interaction.InputBox("Ingrese el apellido del técnico", "Equipo y Proveedor");
                if (apellido.Length == 0) throw new Exception("El apellido está vacío!");

                var equipoxproveedor = new BE_Equipoxproveedor(equipo, proveedor, nombre, apellido);
                bllEquipoxproveedor.Agregar(equipoxproveedor);
                Mostrar(grillaEquipoProveedor, bllEquipoxproveedor.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarPorValorResidual_Click(object sender, EventArgs e)
        {
            try
            {
                decimal desde = Convert.ToDecimal(Interaction.InputBox("Desde", "Búsqueda por valor residual"));
                if (desde < 0) throw new Exception("No puede ser negativo el valor Desde!");
                decimal hasta = Convert.ToDecimal(Interaction.InputBox("Hasta", "Búsqueda por valor residual"));
                if (hasta < 0) throw new Exception("No puede ser negativo el valor Hasta!");
                if (desde > hasta) throw new Exception("El valor inicial es mayor que el valor final!");
                Mostrar(grillaValorResidual, bllEquipo.ConsultaValorResidualDesdeHasta(desde, hasta));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusquedaIncremental_TextChanged(object sender, EventArgs e)
        {
            Mostrar(grillaCodigos, bllEquipo.ConsultaIncrementalPorCodigo(txtBusquedaIncremental.Text));
        }

        private void btnConfirmarCambiosEquipo_Click(object sender, EventArgs e)
        {
            bllEquipo.ConfirmarCambios();

            ctrlEquipo.CargarDatos<object>(bllEquipo.ConsultaPersonalizada1());
            Mostrar(grillaDadosDeBaja, bllEquipo.ConsultaDadosDeBajaAsc());

            grillaEquiposAdded.DataSource = null;
            grillaEquiposModified.DataSource = null;
            grillaEquiposDeleted.DataSource = null;
        }

        private void btnGrabarXml_Click(object sender, EventArgs e)
        {
            bllEquipo.GuardarXml();
            MessageBox.Show("Archivo guardado en XML correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAbrirXml_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", @"C:\Users\Blue\source\repos\DAS\DASW_2B_TM\Varios\Practica_Parcial_2\UI\bin\Debug\net8.0-windows\equipos.xml");
            //Process.Start(new ProcessStartInfo(@"C:\Users\Blue\source\repos\DAS\DASW_2B_TM\Varios\Practica_Parcial_2\UI\bin\Debug\net8.0-windows\equipos.xml") { UseShellExecute = true });
        }
    }
}
