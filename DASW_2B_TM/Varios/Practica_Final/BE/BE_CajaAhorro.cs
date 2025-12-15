namespace BE
{
    public class BE_CajaAhorro : BE_Cuenta
    {
        public BE_CajaAhorro(string codigo, decimal saldo)
        {
            Codigo = codigo;
            Saldo = saldo;
        }
        public BE_CajaAhorro(string codigo, decimal saldo, List<BE_Titular> titulares)
        {
            Codigo = codigo;
            Saldo = saldo;
            Titulares = titulares;
        }
        public BE_CajaAhorro() { }
    }
}
