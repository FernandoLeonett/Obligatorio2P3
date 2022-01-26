using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuponera : Pago
    {
        public int CantActividad { get; set; }
        public static decimal MontoUnitarioActividad { get; set; }
        public static int CantActprefijaDto { get; set; }
        public static decimal DescuentoCuponera { get; set; }



        public Cuponera(int cantidad, Socio socio):base(socio)
        {
            this.Socio = socio;
            this.CantActividad = cantidad;
            MontoPago();

            Tipo = "Cuponera";
         


        }

        public Cuponera()
        {

        }

        public override void MontoPago()
        {

            decimal montoPago = CantActividad * MontoUnitarioActividad;
            if (CantActividad > CantActprefijaDto)


            {
                Descuento = montoPago * DescuentoCuponera / 100;

       
            }
            Importe = montoPago -Descuento;
        }

    }
}
