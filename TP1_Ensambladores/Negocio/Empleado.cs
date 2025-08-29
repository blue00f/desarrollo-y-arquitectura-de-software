namespace Negocio
{
    public class Empleado
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Empleado(int pLegajo, string pNombre, string pApellido)
        {
            Legajo = pLegajo;
            Nombre = pNombre;
            Apellido = pApellido;
        }
        public override string ToString() => $"{Legajo} - {Nombre} {Apellido}";
    }
}
