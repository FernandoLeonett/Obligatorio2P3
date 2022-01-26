using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepoActividad : IRepositorio<Actividad>
    {

        List<HorarioActividad> TraerHorariosActividad();
        List<Actividad> TraerActividadesPorNombre(string nombre);
        List<Actividad> TraerActividadesPorEdad(int edad);
    }
}
