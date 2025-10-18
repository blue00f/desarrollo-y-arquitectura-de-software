namespace Interfaces
{
    public interface Iabmc<T>
    {
        void Alta(T pObject);
        void Baja(T pObject);
        void Modificacion(T pObject);
        List<T> Consulta(T pObject);
        List<T> ConsultaDesdeHasta(T pObject1, T pObject2);
        List<T> ConsultaIncremental(T pObject);
    }
}
