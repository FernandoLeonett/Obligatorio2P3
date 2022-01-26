using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using ContextoEntity;
using System.Data.Entity;

namespace Repositorios
{
    public class RepositorioHorarioActividad : IrepoHorario
    {
        public bool Alta(HorarioActividad obj)
        {
            bool ok = false;
            // verificar quela misma actividad no este a la misma hora el mismo dia
            using (GestionClubContext db = new GestionClubContext())
            {
                try
                {
                    Actividad actividad = db.Actividades.SingleOrDefault(a => a.Nombre == obj.Actividad.Nombre);
                    if (actividad == null)
                    {
                        actividad = obj.Actividad;
                        db.Entry(actividad).State = EntityState.Added;
                    }
                    obj.Actividad = actividad;
                    HorarioActividad repetido = db.Horarios.SingleOrDefault(h => h.Actividad.Nombre == obj.Actividad.Nombre && h.DiaDeSemana == obj.DiaDeSemana && obj.Hora == h.Hora);
                    
                    if (repetido == null)
                    {
                        db.Horarios.Add(obj);
                        db.SaveChanges();
                        ok = true;
                    }
                }
                catch (Exception e)
                {
                    return ok;
                }
            }
            return ok;
        }



        public List<Actividad> TraerActividadesPorFecha(string dia, int hora)
        {
            using (GestionClubContext db = new GestionClubContext())
            {
                return db.Horarios
                    .Where(h => h.DiaDeSemana == dia && h.Hora == hora)
                    .OrderBy(h => h.Actividad.Nombre).ThenBy(h => h.DiaDeSemana).ThenBy(h => h.Hora)
                    .Select(h => h.Actividad)
                    .ToList();
            }
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public HorarioActividad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(HorarioActividad obj)
        {
            throw new NotImplementedException();
        }

        public List<HorarioActividad> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
