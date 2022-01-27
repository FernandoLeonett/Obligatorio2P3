using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Actividades")]
    public class Actividad
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20), Index(IsUnique = true)]
        public string Nombre { get; set; }
        public int MinimoEdad { get; set; }
        public int MaximoEdad { get; set; }

        public Actividad(string nombre, int minimoEdad, int maximoEdad)
        {
            this.Nombre = nombre;
            this.MinimoEdad = minimoEdad;
            this.MaximoEdad = maximoEdad;
        }

        public Actividad() { }
    }
}
