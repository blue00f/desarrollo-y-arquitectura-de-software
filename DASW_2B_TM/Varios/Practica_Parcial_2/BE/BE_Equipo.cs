using System.Text.RegularExpressions;

namespace BE
{
    public class BE_Equipo
    {
        Regex regex = new Regex(@"^EQ-[0-9]{4}-[0-9]{3}$");
        public event EventHandler AlertaCodigoIncorrecto;
        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!regex.IsMatch(value)) AlertaCodigoIncorrecto?.Invoke(this, EventArgs.Empty);
                codigo = value;
            }
        }

        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }
        public int AxoCompra { get; set; }
        public bool EnUso { get; set; }
        public decimal ValorCompra { get; set; }
        public BE_Equipo(string pCodigo, DateTime pFechaIngreso, DateTime pFechaBaja, int pAxoCompra, bool pEnUso, decimal pValorCompra)
        {
            Codigo = pCodigo;
            FechaIngreso = pFechaIngreso;
            FechaBaja = pFechaBaja;
            AxoCompra = pAxoCompra;
            EnUso = pEnUso;
            ValorCompra = pValorCompra;
        }
        public BE_Equipo()
        {

        }
        public decimal CalcularValorResidual()
        {
            decimal valorResidual = this.ValorCompra;
            int diferenciaAxo = DateTime.Now.Year - this.AxoCompra;
            decimal valorDescuento = (valorResidual * 0.15m) * diferenciaAxo;
            if (valorDescuento > valorResidual) valorResidual = 0;
            else valorResidual -= valorDescuento;
            return valorResidual;
        }
        public int CalcularCantidadDiasEnEmpresa()
        {
            int dias = 0;
            if (this.EnUso) dias = (DateTime.Now - this.FechaIngreso).Days;
            else dias = (this.FechaBaja - this.FechaIngreso).Days;
            return dias;
        }

        public override string ToString() => $"{this.Codigo} {this.ValorCompra}";
    }
}
