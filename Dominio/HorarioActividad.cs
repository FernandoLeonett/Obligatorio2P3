using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    [Table("Horarios")]
    public class HorarioActividad
    {
        public int ID { get; set; }
        [Display(Name = "Dia")]
        [Required]
        public string DiaDeSemana { get; set; }
        [Required]
        public int Hora { get; set; }
        [Required]
        public virtual Actividad Actividad { get; set; }

        public HorarioActividad() { }
        public HorarioActividad(Actividad actividad, int hora, string diaDeSemana)
        {
            DiaDeSemana = diaDeSemana;
            Hora = hora;
            Actividad = actividad;
        }

        public static string ValidarDiaSemana(string dia)
        {
            string res = null;
            dia = dia.Trim();
            dia = dia.ToUpper();
            if (dia == "LUNES" || dia == "MARTES" || dia == "MIERCOLES" || dia == "JUEVES" || dia == "VIERNES")
            {
                res = dia;
            }
            return res;
        }

        public static int ValidarHora(string strHora)

        {
            strHora = strHora.Trim();
            int hora;
            //bool punto = false;
            try
            {
                hora = Convert.ToInt32(strHora.Substring(0, 2));
                string enPunto = strHora.Substring(strHora.IndexOf(':')).Trim();
                if (hora > 3 && hora < 21 && enPunto == ":00")
                {
                    return hora;
                }
            }
            catch
            {


                throw new Exception("Formato de hora no valido");
            }


            return hora;
        }

    }
}