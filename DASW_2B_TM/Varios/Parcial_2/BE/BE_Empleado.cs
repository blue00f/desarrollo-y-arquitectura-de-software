namespace BE
{
    public class BE_Empleado
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public BE_Empleado(string legajo, string nombre, string apellido, DateTime fechaIngreso)
        {
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            FechaIngreso = fechaIngreso;
        }
        public BE_Empleado(string legajo) => Legajo = legajo;

        public int CalcularAntiguedadEnAxos()
        {
            return (DateTime.Now.Year - this.FechaIngreso.Year);
        }
    }
}
