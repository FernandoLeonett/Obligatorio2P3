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
    public class RepoActividad : IRepoActividad
    {
        public bool Alta(Actividad obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Actividad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Actividad obj)
        {
            throw new NotImplementedException();
        }

        public List<HorarioActividad> TraerHorariosActividad()
        {
            throw new NotImplementedException();
        }

        public List<Actividad> TraerTodos()
        {
            using (GestionClubContext db = new GestionClubContext())
            {
                return db.Actividades.ToList();
            }
        }

        public List<Actividad> TraerActividadesPorNombre(string nombre)
        {
            List<Actividad> actividades = new List<Actividad>();
            using (GestionClubContext db = new GestionClubContext())
            {
                actividades = db.Horarios
                    .Where(h => h.Actividad.Nombre.ToLower().Contains(nombre.ToLower()))
                    .OrderBy(h => h.Actividad.Nombre).ThenBy(h => h.DiaDeSemana).ThenBy(h => h.Hora)
                    .Select(h => h.Actividad).Distinct()
                    .ToList();

            }
            return actividades;
        }

        public List<Actividad> TraerActividadesPorEdad(int edad)
        {
            List<Actividad> actividades = new List<Actividad>();
            using (GestionClubContext db = new GestionClubContext())
            {
                actividades = db.Horarios
                    .Where(h => h.Actividad.MaximoEdad >= edad && edad>= h.Actividad.MinimoEdad)
                    .OrderBy(h => h.Actividad.Nombre).ThenBy(h => h.DiaDeSemana).ThenBy(h => h.Hora)
                 
                    .Select(h => h.Actividad).Distinct()
                  
                    .ToList();

            }
            return actividades;
        }
    }
}
