using ContextoEntity;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Repositorios
{
    public class RepoIngresoActividad : IRepoIngresoActividad
    {
        public bool Alta(IngresoActividad obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public IngresoActividad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public int ContadorDeIngresoActividad(DateTime fecha, TimeSpan hora)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(IngresoActividad obj)
        {
            throw new NotImplementedException();
        }

        public bool SocioYaIngresado(int IdSocio, int idActividad)
        {
            throw new NotImplementedException();
        }

        public List<IngresoActividad> TraerTodos(Socio socio, DateTime uno, DateTime dos)
        {
            throw new NotImplementedException();
        }

        public List<IngresoActividad> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public List<IngresoActividad> FiltrarIngresoSocios(int cedula, string nombreAct)
        {
            List<IngresoActividad> ingresos = new List<IngresoActividad>();
            using (GestionClubContext db = new GestionClubContext())
            {
                ingresos = db.Ingresos
                    .Include(i => i.Socio)
                    .Include(i => i.HorarioActividad.Actividad)
                    .Where(i => i.Socio.Cedula == cedula && i.HorarioActividad.Actividad.Nombre == nombreAct)
                    .OrderByDescending(i => i.Fecha)
                    .ToList();
            }
            return ingresos;
        }


       
    }
}
