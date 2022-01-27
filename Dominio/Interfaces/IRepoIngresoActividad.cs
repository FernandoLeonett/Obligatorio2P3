using System;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IRepoIngresoActividad : IRepositorio<IngresoActividad>
    {
        bool SocioYaIngresado(int IdSocio, int idActividad);
        List<IngresoActividad> TraerTodos(Socio socio, DateTime uno, DateTime dos);
        int ContadorDeIngresoActividad(DateTime fecha, TimeSpan hora);
        List<IngresoActividad> FiltrarIngresoSocios(int cedula, string nombreAct);
   
    }
}
