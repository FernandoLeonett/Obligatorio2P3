using Dominio;
using System.Data.Entity;

namespace ContextoEntity
{
    public class GestionClubContext : DbContext
    {
        public GestionClubContext() : base("conexion") { }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<HorarioActividad> Horarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Cuponera> Cuponeras { get; set; }
        public DbSet<PaseLibre> Mensualidades { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<IngresoActividad> Ingresos { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

