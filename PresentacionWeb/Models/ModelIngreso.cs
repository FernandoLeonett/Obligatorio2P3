using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace PresentacionWeb.Models
{
    public class ModelIngreso
    {
        public List<Actividad> actividades { get; set; }

        public int  Cedula { get; set; }

    }
}