using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    [Table("Pagos")]
    abstract public class Pago
    {
        public int Id { get; set; }
        [Display(Name = "Fecha de pago")]
        public DateTime FechaPago { get; set; }
        public Socio Socio { get; set; }
        public decimal Importe { get; set; }
        [NotMapped]
        public string Tipo { get; set; }
        public decimal Descuento { get; set; }
    

        public Pago(Socio socio)
        {
            this.Socio = socio;
            this.FechaPago = DateTime.Today;
   
        }
        public Pago()
        {

        }

        public abstract void MontoPago();
   
    }
}
