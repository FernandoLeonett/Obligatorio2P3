using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio.Interfaces
{
   public interface IrepoHorario:IRepositorio<HorarioActividad>
    {
        List<Actividad> TraerActividadesPorFecha(string dia, int hora);
    }
}
