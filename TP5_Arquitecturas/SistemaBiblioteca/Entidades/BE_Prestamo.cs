namespace BE
{
    public class BE_Prestamo
    {
        public string Id { get; set; }
        public BE_Socio Socio { get; set; }
        public BE_Libro Libro { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public BE_Prestamo(string pId, BE_Socio pSocio, BE_Libro pLibro, DateTime pFechaPrestamo, DateTime pFechaDevolucion)
        {
            Id = pId;
            Socio = pSocio;
            Libro = pLibro;
            Estado = "Activo";
            FechaPrestamo = pFechaPrestamo;
            FechaDevolucion = pFechaDevolucion;
        }
        public BE_Prestamo(string pId, BE_Socio pSocio, BE_Libro pLibro, DateTime pFechaPrestamo, DateTime pFechaDevolucion, string pEstado)
        {
            Id = pId;
            Socio = pSocio;
            Libro = pLibro;
            Estado = pEstado;
            FechaPrestamo = pFechaPrestamo;
            FechaDevolucion = pFechaDevolucion;
        }
        public BE_Prestamo(string pId)
        {
            Id = pId;
        }
    }
}
