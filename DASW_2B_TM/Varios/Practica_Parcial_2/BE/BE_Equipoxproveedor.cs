namespace BE
{
    public class BE_Equipoxproveedor
    {
        public BE_Equipo Equipo { get; set; }
        public BE_Proveedor Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public BE_Equipoxproveedor(BE_Equipo pEquipo, BE_Proveedor pProveedor, string pNombre, string pApellido)
        {
            Equipo = pEquipo;
            Proveedor = pProveedor;
            Nombre = pNombre;
            Apellido = pApellido;
        }
    }
}
