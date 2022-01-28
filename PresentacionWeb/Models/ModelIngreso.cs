using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace PresentacionWeb.Models
{
    public class ModelIngreso
    {
        public  List<SelectListItem> Actividades { get; set; }

        public int  Cedula { get; set; }

    }
}