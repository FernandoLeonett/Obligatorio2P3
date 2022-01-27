using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Socios")]
    public class Socio : IComparable<Socio>
    {
        [Display(Name = "Cédula")]
        [CedulaValida(ErrorMessage = "La cedula es invalida")]
        [Index(IsUnique = true)]


        public int Cedula { get; set; }
        [Display(Name = "Nombre Completo")]
        [Nombre(ErrorMessage = "El nombre no es valido")]
        public string Nombre { get; set; }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [FechaNac(ErrorMessage = "La fecha de nacimiento no es valida")]
        public DateTime FechaNac { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        public static int AntiguedadDto { get; set; }
        public bool Activo { get; set; }
        [CedulaValida(ErrorMessage = "La cédula no es valida")]

        public Socio(int cedula, string nombre, DateTime fechaNac)
        {
            Cedula = cedula;
            Nombre = nombre;
            FechaNac = fechaNac;
            FechaIngreso = DateTime.Today;
            Activo = true;
        }

        public Socio() { }

        public bool CheckAntiguedad()
        {
            int antiguedadSocio = DateTime.Today.Year - FechaIngreso.Year;
            if (DateTime.Today < FechaIngreso.AddYears(antiguedadSocio)) antiguedadSocio--;
            bool ok = antiguedadSocio >= AntiguedadDto;
            return ok;
        }

        public static bool ValidarEdad(DateTime fechaNac)
        {
            int edad = DateTime.Today.Year - fechaNac.Year;// cantidad de anios desde su nacimiento a la fecha actual
            if (DateTime.Today < fechaNac.AddYears(edad)) edad--;// si aun no es su cumpeanos
            bool edadValida = edad > 3 && edad < 90;
            return edadValida;
        }

        public static bool ValidarCedula(int cedula)
        {
            bool ok = cedula >= 1000000 && cedula <= 999999999;
            return ok;

        }

        public static bool ValidarNombreApellido(string nombreApellido)
        {
            bool ok = false;
            if (nombreApellido == nombreApellido.Trim())
            {
                if (nombreApellido.IndexOf(" ") != -1)
                {
                    if (nombreApellido.Length >= 6)
                    {
                        ok = true;
                    }
                }
            }
            return ok;
        }

        public int CompareTo(Socio otroSocio)
        {
            int comparacion = 0;
            if (otroSocio != null)
            {
                string nombreUno = Nombre.Substring(0, Nombre.IndexOf(" "));
                string nombreDos = otroSocio.Nombre.Substring(0, Nombre.IndexOf(" "));
                comparacion = nombreUno.CompareTo(nombreDos);
            }
            if (comparacion == 0)
            {
                comparacion = Cedula.CompareTo(otroSocio.Cedula) * -1;
            }
            return comparacion;
        }

        public class CedulaValidaAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                return ValidarCedula((int)value);
            }
        }

        public class FechaNacAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                return ValidarEdad((DateTime)value);
            }
        }

        public class NombreAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                return ValidarNombreApellido((string)value);
            }
        }


    }
}