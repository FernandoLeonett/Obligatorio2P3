using Auxiliar;
using Dominio;
using System.Collections.Generic;
using System.Web.Http;

namespace WepApi.Controllers
{
    public class IngresoController : ApiController
    {
        // GET: api/Ingreso


        [Route("api/Ingreso/{cedula}/{nombreAct}")]
        public IHttpActionResult Get(int cedula, string nombreAct)
        {
            List<IngresoActividad> ingresos = Fachada.FiltrarIngresoSocios(cedula, nombreAct);
            return Ok(ingresos);
        }


    }
}
