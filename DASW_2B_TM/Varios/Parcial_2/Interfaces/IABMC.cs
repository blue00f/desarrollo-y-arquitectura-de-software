namespace Interfaces
{
    public interface IABMC<T>
    {
        void Agregar(T pObjeto);
        void Borrar (T pObjeto);
        void Modificar(T pObjeto);
        List<T> Consultar();
        bool ValidarCodigoRepetido(T pObjeto);
    }
}
