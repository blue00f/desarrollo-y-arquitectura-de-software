namespace BE
{
    public class BE_Corriente : BE_Cuenta
    {
        public decimal Descubierto { get; set; }
        public BE_Corriente(string codigo, decimal saldo, decimal descubierto)
        {
            Codigo = codigo;
            Saldo = saldo;
            Descubierto = descubierto;
        }
        public BE_Corriente(string codigo, decimal saldo, decimal descubierto, List<BE_Titular> titulares)
        {
            Codigo = codigo;
            Saldo = saldo;
            Descubierto = descubierto;
            Titulares = titulares;
        }
        public BE_Corriente() { }
    }
}
