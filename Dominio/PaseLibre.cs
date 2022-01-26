using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaseLibre : Pago
    {
        public static decimal CuotaFija { get; set; }

        public static decimal DescuentoAntiguedad { get; set; }


        public PaseLibre(Socio socio):base(socio)
        {
            this.Socio = socio;

       
            Tipo = "PaseLibre";
            MontoPago();

        }
        public PaseLibre()
        {

        }


        public override void MontoPago()
        {
         

            decimal montoPago = CuotaFija;
            if (this.Socio.CheckAntiguedad())
            {
                Descuento = montoPago * DescuentoAntiguedad / 100;
            }
            Importe = montoPago- Descuento;
        }
    }
}
