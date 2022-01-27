using ContextoEntity;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


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
