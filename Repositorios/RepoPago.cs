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
    public class RepoPago : IRepoPago
    {
        public bool Alta(Pago obj)
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                obj.Socio = db.Socios.SingleOrDefault(s => s.Cedula == obj.Socio.Cedula);
                db.Entry(obj).State = EntityState.Added;
                db.SaveChanges();
                ok = true;
            }
            return ok;
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Pago BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }


        public bool CargarTopes()
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                Parametros p = new Parametros();
                if (db.Parametros.Count() != 0)
                {
                    p = db.Parametros.FirstOrDefault();
                    PaseLibre.CuotaFija = p.MensualidadCuotaFija;
                    Socio.AntiguedadDto = p.AntiguedadRequeridadParaDctoMensualidad;
                    PaseLibre.DescuentoAntiguedad = p.DescuentoXAntiguedad;
                    Cuponera.MontoUnitarioActividad = p.ImporteoUnitarioXAactividdad;
                    Cuponera.CantActprefijaDto = p.TopeActiviadesDcto;
                    Cuponera.DescuentoCuponera = p.DtoXActividadesTope;
                }
                else
                {
                    p = new Parametros(5000, 3, 30, 300, 20, 40);
                    db.Parametros.Add(p);
                    db.SaveChanges();
                }
            }
            return ok;
        }

        public bool Modificacion(Pago obj)
        {
            throw new NotImplementedException();
        }

        public List<Pago> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public List<Pago> FiltrarPagos(int mes, int anio)
        {
            List<Pago> pagos = new List<Pago>();
            using (GestionClubContext db = new GestionClubContext())
            {
                pagos = db.Pagos
                    .Include(p => p.Socio)
                    .Where(p => p.FechaPago.Month == mes && p.FechaPago.Year == anio).ToList();                                
            }
            return pagos;
        }

        public bool VerificarMensualidadSocio(Socio socio)
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                DateTime primerDiaDelMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime UltimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
                int count = db.Pagos.Count(p => p.Socio.Cedula == socio.Cedula && p.FechaPago >= primerDiaDelMes && p.FechaPago <= UltimoDiaDelMes);
                if (count > 0)
                {
                    ok = true;
                }
            }
            return ok;
        }
    }
}
