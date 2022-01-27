using Auxiliar;
using Dominio;

namespace PresentacionWEB.Models
{
    public class SocioAldia
    {
        public Socio Socio { get; set; }
        public bool Aldia()
        {
            return Fachada.VerificarMensualidadSocio(Socio.Cedula);
        }
        public SocioAldia(Socio socio)
        {
            Socio = socio;
        }
    }
}