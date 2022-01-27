using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IRepositorio<T>
    {
        bool Alta(T obj);

        bool Baja(int id);
        bool Modificacion(T obj);
        List<T> TraerTodos();
        T BuscarPorId(int id);
    }
}
