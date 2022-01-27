using Auxiliar;
using Dominio;
using System.Collections.Generic;
using System.Web.Http;

namespace WepApi.Controllers
{
    public class ActividadController : ApiController
    {




        [Route("api/Actividad/nombre/{nombre}")]
        public IHttpActionResult Get(string nombre)
        {
            List<Actividad> actividades = Fachada.TraerActividadesPorNombre(nombre);
            return Ok(actividades);
        }

        [Route("api/Actividad/edad/{edad}")]
        public IHttpActionResult Get(int edad)
        {
            List<Actividad> actividades = Fachada.TraerActividadesPorEdad(edad);
            return Ok(actividades);
        }

        [Route("api/Actividad/fecha/{dia}/{hora}")]
        public IHttpActionResult Get(string dia, int hora)
        {
            List<Actividad> actividades = Fachada.TraerActividadesPorFecha(dia, hora);
            return Ok(actividades);
        }



    }
}
