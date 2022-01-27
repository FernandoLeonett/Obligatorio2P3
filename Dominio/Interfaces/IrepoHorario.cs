using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IrepoHorario : IRepositorio<HorarioActividad>
    {
        List<Actividad> TraerActividadesPorFecha(string dia, int hora);
    }
}
