using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Parametros
    {
        public int Id { get; set; }

        public Parametros(decimal mensualidadCuotaFija, int antiguedadRequeridadParaDctoMensualidad, decimal descuentoXAntiguedad, decimal importeoUnitarioXAactividdad, decimal dtoXActividadesTope, int topeActiviadesDcto)
        {
            MensualidadCuotaFija = mensualidadCuotaFija;
            AntiguedadRequeridadParaDctoMensualidad = antiguedadRequeridadParaDctoMensualidad;
            DescuentoXAntiguedad = descuentoXAntiguedad;
            ImporteoUnitarioXAactividdad = importeoUnitarioXAactividdad;
            DtoXActividadesTope = dtoXActividadesTope;
            TopeActiviadesDcto = topeActiviadesDcto;
        }

        #region Parametros Mensualidad
        public decimal MensualidadCuotaFija { get; set; }
        public int AntiguedadRequeridadParaDctoMensualidad { get; set; }
        public decimal DescuentoXAntiguedad { get; set; }
        #endregion

        #region Parametros Cuponera
        public decimal ImporteoUnitarioXAactividdad { get; set; }
        public decimal DtoXActividadesTope { get; set; }
        public int TopeActiviadesDcto { get; set; }
        #endregion

        public Parametros() { }
    }
}
