namespace BE
{
    public class BE_Proveedor
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public BE_Proveedor(string pCodigo, string pNombre, string pDireccion)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Direccion = pDireccion;
        }
        public BE_Proveedor(string pCodigo) => Codigo = pCodigo;
        public override string ToString() => $"{this.Codigo} - {this.Nombre} - {this.Direccion}";
    }
}
