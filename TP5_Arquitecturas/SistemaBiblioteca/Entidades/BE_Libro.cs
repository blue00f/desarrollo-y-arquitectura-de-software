namespace BE
{
    public class BE_Libro
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public List<BE_Prestamo> Prestamos { get; set; }

        public BE_Libro(string pId, string pTitulo, string pAutor)
        {
            Id = pId;
            Titulo = pTitulo;
            Autor = pAutor;
            Prestamos = new List<BE_Prestamo>();
        }
        public BE_Libro(string pId)
        {
            Id = pId;
        }
        public override string ToString() => $"{this.Titulo}";
    }
}