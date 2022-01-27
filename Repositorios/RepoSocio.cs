using ContextoEntity;
using Dominio;
using Dominio.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositorios
{
    public class RepoSocio : IRepoSocio
    {
        public bool Alta(Socio obj)
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                Socio socio = db.Socios.SingleOrDefault(s => s.Cedula == obj.Cedula);
                if (socio == null)
                {
                    db.Socios.Add(obj);
                    db.SaveChanges();
                    ok = true;
                }
            }
            return ok;
        }

        public bool Baja(int cedula)
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                Socio socio = db.Socios.SingleOrDefault(s => s.Cedula == cedula);
                if (socio != null)
                {
                    socio.Activo = false;
                    db.Entry(socio).State = EntityState.Modified;
                    db.SaveChanges();
                    ok = true;
                }
            }
            return ok;
        }

        public Socio BuscarPorId(int cedula)
        {
            Socio socio = null;
            using (GestionClubContext db = new GestionClubContext())
            {
                socio = db.Socios.SingleOrDefault(s => s.Cedula == cedula);
            }
            return socio;
        }

        public bool Modificacion(Socio obj)
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                Socio socio = obj;
                db.Entry(socio).State = EntityState.Modified;
                db.SaveChanges();
                ok = true;
            }
            return ok;
        }

        public List<Socio> TraerTodos()
        {
            using (GestionClubContext db = new GestionClubContext())
            {
                return db.Socios
                    .Where(s => s.Activo == true)
                    .ToList();
            }
        }
    }
}
