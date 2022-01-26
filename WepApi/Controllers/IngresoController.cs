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
    public class IngresoController : ApiController
    {
        // GET: api/Ingreso
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/Ingreso/{cedula}/{nombreAct}")]
        public IHttpActionResult Get(int cedula, string nombreAct)
        {
            List<IngresoActividad> ingresos = Fachada.FiltrarIngresoSocios(cedula, nombreAct);
            return Ok(ingresos);
        }

        // POST: api/Ingreso
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ingreso/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ingreso/5
        public void Delete(int id)
        {
        }
    }
}
