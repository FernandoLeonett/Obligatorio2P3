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
    public class RepoUsuario : IRepoUsuario
    {
        public bool Alta(Usuario obj)
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                try
                {
                    int cant = db.Usuarios.Count(u => u.Email == obj.Email);
                    if (cant == 0)
                    {
                        db.Usuarios.Add(obj);
                        db.SaveChanges();
                        ok = true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return ok;
            }
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmaii(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(Usuario obj)
        {
            Usuario usu;
            using (GestionClubContext db = new GestionClubContext())
            {
                usu = db.Usuarios.SingleOrDefault(u => u.Email.Equals(obj.Email) && u.Password.Equals(obj.Password));
            }
            return usu;
        }

        public bool Modificacion(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

