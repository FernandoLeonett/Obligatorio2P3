using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Auxiliar
{
    public static class Fachada
    {

        private static IRepoPrecargas repoPrecasr = Fabrica.ObtenerRepoPrecarga();
        private static IRepoSocio repoSocio = Fabrica.ObtenerRepositorioSocio();
        private static IRepoPago repoPago = Fabrica.ObtenerRepositorioPago();
        private static IRepoIngresoActividad repoIngreso = Fabrica.ObtenerRepoIngresoActiviad();
        private static IRepoUsuario repositorioUsuario = Fabrica.ObtenerRepoUsuario();
        private static IRepoActividad repositorioActividad = Fabrica.ObtenerRepoActividad();
        private static IrepoHorario repositoriHorario = Fabrica.ObtenerRepoHorario();

        public static List<IngresoActividad> FiltrarIngresoSocios(int cedula, string nombreAct)
        {
            return repoIngreso.FiltrarIngresoSocios(cedula, nombreAct);
        }

        public static List<Actividad> TraerActividadesPorNombre(string nombre)
        {
            return repositorioActividad.TraerActividadesPorNombre(nombre);
        }

        public static List<Actividad> TraerActividadesPorEdad(int edad)
        {
            return repositorioActividad.TraerActividadesPorEdad(edad);
        }

        public static List<Actividad> TraerActividadesPorFecha(string dia, int hora)
        {
            return repositoriHorario.TraerActividadesPorFecha(dia, hora);
        }

        public static bool AltaUsuario(Usuario u)
        {
            bool ok = false;
            if (Usuario.VerificarEmail(u.Email) && Usuario.VerificarPassword(u.Password))
            {
                ok = repositorioUsuario.Alta(u);
            }
            return ok;
        }

        public static bool Precargas()
        {
            return repoPrecasr.Precarga();
        }

        public static bool AltaHorario(HorarioActividad h)
        {
            bool ok = false;
            if (h.Actividad.MinimoEdad >= 3 && h.Actividad.MaximoEdad <= 90)
            {
                ok = repositoriHorario.Alta(h);
            }
            return ok;
        }

        public static List<Pago> TraerPagos(int mes, int anio)
        {
            return repoPago.FiltrarPagos(mes, anio);
        }

        public static string ControlarDiaActividad(string dia)
        {
            return HorarioActividad.ValidarDiaSemana(dia);
        }

        public static int ValidarHora(string strHora)
        {
            return HorarioActividad.ValidarHora(strHora);
        }

        public static bool RegistrarSocio(int cedula, string mombreApellido, DateTime fechaNac)
        {
            bool ok = false;
            Socio unSocio = null;
            int edad = DateTime.Today.Year - fechaNac.Year;// cantidad de anios desde su nacimiento a la fecha actual
            if (DateTime.Today < fechaNac.AddYears(edad)) edad--;// si aun no es su cumpeanos
            bool edadValida = edad > 3 && edad < 90;
            if (Socio.ValidarCedula(cedula) && Socio.ValidarEdad(fechaNac) && Socio.ValidarNombreApellido(mombreApellido))
            {
                unSocio = new Socio(cedula, mombreApellido, fechaNac);
            }
            if (unSocio != null)
            {
                repoSocio = Fabrica.ObtenerRepositorioSocio();
                ok = repoSocio.Alta(unSocio);
            }
            return ok;
        }

        public static Socio BuscarSocio(int cedula)
        {
            Socio unSocio = repoSocio.BuscarPorId(cedula);
            return unSocio;
        }
        public static bool EliminarSocio(int cedula)
        {
            bool ok = true;
            repoSocio = Fabrica.ObtenerRepositorioSocio();
            if (repoSocio.Baja(cedula))
            {
                Socio socio = BuscarSocio(cedula);
                ok = true;
            }
            return ok;
        }

        public static bool ModificarSocio(int cedula, string mombreApellido, DateTime fechaNac)
        {
            bool ok = false;
            if (Socio.ValidarCedula(cedula) && Socio.ValidarNombreApellido(mombreApellido) && Socio.ValidarEdad(fechaNac))
            {
                repoSocio = Fabrica.ObtenerRepositorioSocio();
                int id = Convert.ToInt32(cedula);
                Socio unSocio = repoSocio.BuscarPorId(id);
                unSocio.Nombre = mombreApellido;
                unSocio.FechaNac = fechaNac;
                ok = repoSocio.Modificacion(unSocio);
            }
            return ok;
        }

        public static List<Socio> MostrarSocios()
        {
            List<Socio> socios = repoSocio.TraerTodos();
            socios.Sort();
            return socios;
        }

        public static List<IngresoActividad> Ingresos(Socio socio, DateTime fechaMenor, DateTime fechaMayor)
        {
            if (fechaMenor == default)
            {
                fechaMenor = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }
            if (fechaMayor == default)
            {
                fechaMayor = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            }
            repoIngreso = Fabrica.ObtenerRepoIngresoActiviad();
            List<IngresoActividad> ingresos = repoIngreso.TraerTodos(socio, fechaMenor, fechaMayor);
            return ingresos;
        }

        public static bool RegistrarPagoSocio(Pago unPago)
        {
            return repoPago.Alta(unPago);
        }

        public static bool VerificarMensualidadSocio(int cedula)
        {
            Socio unSocio = repoSocio.BuscarPorId(cedula);
            repoPago = Fabrica.ObtenerRepositorioPago();
            return repoPago.VerificarMensualidadSocio(unSocio);
        }

        public static Usuario Login(Usuario u)
        {
            return Fabrica.ObtenerRepoUsuario().Login(u);
        }

        public static List<Usuario> TraerUsuarios()
        {
            return repositorioUsuario.TraerTodos();
        }

        public static List<Socio> TraerSocios()
        {
            return repoSocio.TraerTodos();
        }

        public static List<HorarioActividad> TraerHorariosAct()
        {
            return repositorioActividad.TraerHorariosActividad();
        }
        public static List<Actividad> TraerActividades()
        {
            return repositorioActividad.TraerTodos();
        }

        public static List<IngresoActividad> TraerIngresoActividades()
        {
            return repoIngreso.TraerTodos();
        }

        public static List<HorarioActividad> TraerHorariosActividadPorHora()
        {
            List<HorarioActividad> listaHorarioActividades = new List<HorarioActividad>();
            try
            {

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                //client.Close();
            }
            return listaHorarioActividades;
        }

        public static bool ControlIngresoActividad(int idSocio, int idActividad)
        {
            return repoIngreso.SocioYaIngresado(idSocio, idActividad);
        }

        public static int ObtenercantidadDeIngresoActividad(DateTime fecha, TimeSpan hora)
        {
            return repoIngreso.ContadorDeIngresoActividad(fecha, hora);
        }

     
    }
}
