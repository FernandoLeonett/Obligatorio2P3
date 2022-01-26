using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Repositorios;

namespace Auxiliar
{
    public class Fabrica
    {
        public static IRepoSocio ObtenerRepositorioSocio()
        {
            return new RepoSocio();
        }
        public static IRepoPago ObtenerRepositorioPago()
        {
            return new RepoPago();
        }
        public static IRepoUsuario ObtenerRepoUsuario()
        {
            return new RepoUsuario();
        }
        public static IRepoIngresoActividad ObtenerRepoIngresoActiviad()
        {
            return new RepoIngresoActividad();
        }
        public static IRepoActividad ObtenerRepoActividad()
        {
            return new RepoActividad();
        }
        public static IrepoHorario ObtenerRepoHorario()
        {
            return new RepositorioHorarioActividad();
        }
    }
}
