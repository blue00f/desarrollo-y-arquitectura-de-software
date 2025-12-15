namespace BE
{
    abstract public class BE_Cuenta
    {
        public string Codigo { get; set; }
        public decimal Saldo { get; set; }
        public List<BE_Titular> Titulares { get; set; }
    }
}
