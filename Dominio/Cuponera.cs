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

     

        public Cuponera()
        {
       
            Tipo = "Cuponera";

           
        }

        public override void MontoPago()
        {

            Descuento = (this.CantActividad * MontoUnitarioActividad) - Importe;
            decimal montoPago = CantActividad * MontoUnitarioActividad;
            if (CantActividad > CantActprefijaDto)
            {
                montoPago *= ((100 - DescuentoCuponera) / 100);
            }
            Importe = montoPago;
        }

    }
}
