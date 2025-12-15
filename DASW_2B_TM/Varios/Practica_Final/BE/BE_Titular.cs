using System.Text.RegularExpressions;

namespace BE
{
    public class BE_Titular
    {
        Regex reg = new Regex(@"^[0-9]{8}$");
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<BE_Cuenta> Cuentas { get; set; }

        public BE_Titular(string dni, string nombre, string apellido)
        {
            if (!reg.IsMatch(dni)) throw new Exception("Formato del DNI incorrecto!");
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
        }
        public BE_Titular() { }
    }
}
