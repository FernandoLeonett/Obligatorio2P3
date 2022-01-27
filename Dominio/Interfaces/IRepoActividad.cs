using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IRepoActividad : IRepositorio<Actividad>
    {

        List<HorarioActividad> TraerHorariosActividad();
        List<Actividad> TraerActividadesPorNombre(string nombre);
        List<Actividad> TraerActividadesPorEdad(int edad);
    }
}
