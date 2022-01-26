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
     

        [Route("api/Ingreso/{cedula}/{nombreAct}")]
        public IHttpActionResult Get(int cedula, string nombreAct)
        {
            List<IngresoActividad> ingresos = Fachada.FiltrarIngresoSocios(cedula, nombreAct);
            return Ok(ingresos);
        }


    }
}
