using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    [Table("Ingresos")]
    public class IngresoActividad
    {
        public int Id { get; set; }
        public Socio Socio { get; set; }
        public HorarioActividad HorarioActividad { get; set; }

       
       
        public DateTime Fecha { get; set; }

        public IngresoActividad(Socio socio, HorarioActividad horarioActividad, DateTime fecha)
        {
            Socio = socio;
            HorarioActividad = horarioActividad;
            Fecha = fecha;
        }

        public IngresoActividad(int id, Socio socio, HorarioActividad horarioActividad, DateTime fecha)
        {
            Id = id;
            Socio = socio;
            HorarioActividad = horarioActividad;
            Fecha = fecha;
        }

        public IngresoActividad() { }

        public static bool VerificarEdadParaIngreso(Actividad act, Socio socio)
        {
            bool edadValida = false;
            int edad = DateTime.Today.Year - socio.FechaNac.Year;// cantidad de anios desde su nacimiento a la fecha actual
            if (DateTime.Today < socio.FechaNac.AddYears(edad)) edad--;// si aun no es su cumpeanos
            if (edad >= act.MinimoEdad && edad <= act.MaximoEdad)
            {
                edadValida = true;
            }
            return edadValida;
        }
    }
}
