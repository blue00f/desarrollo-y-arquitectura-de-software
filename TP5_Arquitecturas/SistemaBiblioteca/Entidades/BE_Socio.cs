namespace BE
{
    public class BE_Socio
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Localidad { get; set; }
        public List<BE_Prestamo> Prestamos { get; set; }

        public BE_Socio(string pId, string pNombre, string pApellido, DateTime pFechaNacimiento, string pLocalidad)
        {
            Id = pId;
            Nombre = pNombre;
            Apellido = pApellido;
            FechaNacimiento = pFechaNacimiento;
            Localidad = pLocalidad;
            Prestamos = new List<BE_Prestamo>();
        }
        public BE_Socio(string pId)
        {
            Id = pId;
        }
        public override string ToString() => $"{this.Nombre} {this.Apellido}";
    }
}
