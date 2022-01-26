using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Auxiliar;

namespace WepApi.Controllers
{
    public class ActividadController : ApiController
    {
        [Route("api/Actividad/texto/{nombre}")]
        public IHttpActionResult GetTexto([FromUri] string nombre)
        {
            List<Actividad> actividades = Fachada.TraerActividadesPorNombre(nombre);
            return Ok(actividades);
        }

        [Route("api/Actividad/edad/{edad}")]
        public IHttpActionResult GetEdad(int edad)
        {
            List<Actividad> actividades = Fachada.TraerActividadesPorEdad(edad);
            return Ok(actividades);
        }

        [Route("api/Actividad/fecha/{dia}/{hora}")]
        public IHttpActionResult GetFecha(string dia, int hora)
        {
            List<Actividad> actividades = Fachada.TraerActividadesPorFecha(dia, hora);
            return Ok(actividades);
        }

        // POST: api/Actividad
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Actividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividad/5
        public void Delete(int id)
        {
        }
    }
}
