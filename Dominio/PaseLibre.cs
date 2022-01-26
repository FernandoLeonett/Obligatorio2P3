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


        public PaseLibre()
        {


            Tipo = "PaseLibre";

        }


        public override void MontoPago()
        {
            Descuento = CuotaFija - Importe;

            decimal montoPago = CuotaFija;
            if (this.Socio.CheckAntiguedad())
            {
                montoPago *= ((100 - DescuentoAntiguedad) / 100);
            }
            Importe = montoPago;
        }
    }
}
