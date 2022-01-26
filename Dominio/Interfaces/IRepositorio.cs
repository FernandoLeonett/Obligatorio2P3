using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
