namespace Interfaces
{
    public interface IABMC<T>
    {
        void Agregar(T obj);
        void Borrar(T obj);
        void Modificar(T obj);
        List<T> Consultar();
        bool ValidarCodigoRepetido(T obj);
    }
}
