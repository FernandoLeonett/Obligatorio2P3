using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepoPago : IRepositorio<Pago>
    {
        bool VerificarMensualidadSocio(Socio socio);
        bool CargarTopes();

        List<Pago> FiltrarPagos(int mes, int anio);


    }
}
