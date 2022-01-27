using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IRepoPago : IRepositorio<Pago>
    {
        bool VerificarMensualidadSocio(Socio socio);
      

        List<Pago> FiltrarPagos(int mes, int anio);


    }
}
