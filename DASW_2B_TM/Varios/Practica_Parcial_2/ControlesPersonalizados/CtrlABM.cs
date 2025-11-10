namespace ControlesPersonalizados
{
    public partial class CtrlABM : UserControl
    {
        public CtrlABM()
        {
            InitializeComponent();
        }
        public event EventHandler? Agregar;
        public event EventHandler? Borrar;
        public event EventHandler? Modificar;

        private void btnAgregar_Click(object sender, EventArgs e) => Agregar?.Invoke(this, e);
        private void btnBorrar_Click(object sender, EventArgs e) => Borrar?.Invoke(this, e);
        private void btnModificar_Click(Object sender, EventArgs e) => Modificar?.Invoke(this, e);
        public void CargarDatos<T>(List<T> pDatos)
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = pDatos;
        }
        public T? ObtenerSeleccionado<T>() where T : class
        {
            if (!TieneFilas()) throw new Exception("No hay registros en la grilla!");
            return dgvDatos.SelectedRows[0].DataBoundItem as T;
        }
        public string ObtenerCodigo()
        {
            if (!TieneFilas()) throw new Exception("No hay registros en la grilla!");
            return dgvDatos.SelectedRows[0].Cells[0].Value.ToString();
        }
        private bool TieneFilas()
        {
            bool rdo = true;
            if (dgvDatos.Rows.Count == 0) rdo = false;
            return rdo;
        }
        private void CtrlABM_Load(object sender, EventArgs e)
        {
            dgvDatos.MultiSelect = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
