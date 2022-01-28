using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using System.Data.Entity;
using ContextoEntity;
using Dominio;


using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Repositorios
{
    public class RepoPrecarga : IRepoPrecargas
    {

        public bool Precarga()
        {
            bool ok = false;
            using (GestionClubContext db = new GestionClubContext())
            {
                Parametros p = new Parametros();
                if (db.Parametros.Count() == 0)
                {
                    p = new Parametros(5000, 3, 30, 300, 20, 40);
                    db.Parametros.Add(p);
                    ok = true;
                    db.SaveChanges();
                }
                p = db.Parametros.FirstOrDefault();
                PaseLibre.CuotaFija = p.MensualidadCuotaFija;
                Socio.AntiguedadDto = p.AntiguedadRequeridadParaDctoMensualidad;
                PaseLibre.DescuentoAntiguedad = p.DescuentoXAntiguedad;
                Cuponera.MontoUnitarioActividad = p.ImporteoUnitarioXAactividdad;
                Cuponera.CantActprefijaDto = p.TopeActiviadesDcto;
                Cuponera.DescuentoCuponera = p.DtoXActividadesTope;
            }
            if (ok)
                Inicializar();
            return ok;
        }
        private bool Inicializar()
        {

            bool ok = false;
            string sql = "SET DATEFORMAT dmy; insert into Socios values(123451,'Carlos Perez','22-11-1987',GETDATE(),1),(123452, 'Jose Perez', '22-11-1987', GETDATE(), 1),(123453, 'Maria Perez', '22-11-1987', GETDATE(), 1),(123454, 'Brenda Perez', '22-11-1987', GETDATE(), 1),(123455, 'Jacinto Perez', '22-11-1987', GETDATE(), 1),(123456, 'Matias Perez', '22-11-1987', GETDATE(), 1),(123457, 'Fernando Perez', '22-11-1987', GETDATE(), 1),(123458, 'Jose Perez', '22-11-1987', GETDATE(), 1),(123459, 'Pablo Perez', '22-11-1987', GETDATE(), 1),(123450, 'Ricardo Perez', '22-11-1987', GETDATE(), 1)insert into Actividades values('Futbol',10,50),('Ajedrez', 12, 70),('Natacion', 5, 60),('Yoga', 18, 70),('Maraton', 15, 60),('Baile', 10, 50),('Futbol Sala', 10, 50)insert into Horarios values('Lunes',10,1),('Martes', 12, 2),('Miercoles', 5, 3),('Jueves', 18, 4),('Viernes', 15, 5),('Lunes', 10, 6),('Miercoles', 10, 7)insert into Ingresos values('11-01-2021',1,1),('12-12-2021', 2, 2),('13-12-2021', 3, 3),('15-12-2021', 4, 4),('14-12-2021', 5, 1),('16-12-2021', 6, 6),('17-12-2021', 7, 10),('22-12-2021', 2, 3),('5-12-2021', 1, 3),('1-12-2021', 3, 5),('21-12-2021', 4, 3)";

            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


            SqlConnection conexion = new SqlConnection(cadenaConexion);



            conexion.Open();
            SqlTransaction tran = conexion.BeginTransaction();
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                Transaction = tran,
                CommandText = sql
            };


            try
            {



                comando.ExecuteNonQuery();
                tran.Commit();
                ok = true;





            }
            catch (Exception e)
            {
                if (tran != null)
                    tran.Rollback();
            }
            finally
            {
                if (conexion != null)
                {
                    if (conexion.State == ConnectionState.Open) conexion.Close();
                    conexion.Dispose();

                }
            }
            return ok;
        }

    }
}

