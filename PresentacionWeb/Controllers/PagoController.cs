using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Auxiliar;
using PresentacionWEB.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

namespace PresentacionWEB.Controllers
{
    public class PagoController : Controller
    {
        public ActionResult Create(string nombre, int? cedula, DateTime? fechaNac, DateTime? fechaIngreso, int? id)
        {
            if (Session["user"] != null)
            {
                Socio socio = new Socio
                {
                    Nombre = nombre,
                    Id = (int)id,
                    FechaIngreso = (DateTime)fechaIngreso,
                    FechaNac = (DateTime)fechaNac,
                    Cedula = (int)cedula
                };
                return View(socio);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Create(Socio socio, int? cantidad)
        {
            if (Session["user"] != null)
            {
                try
                {
                    ViewBag.mensaje = (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1)).ToLongDateString();
                    ; if (cantidad == null)
                    {
                        PaseLibre paseLibre = new PaseLibre(socio);
                        TempData["PaseLibre"] = paseLibre;
                        return View("ConfirmarPaseLibre", paseLibre);
                    }
                    else
                    {
                        Cuponera cupo = new Cuponera((int)cantidad, socio);
                        TempData["Cuponera"] = cupo;
                        return View("ConfirmarCuponera", cupo);
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult ConfirmarCuponera()
        {
            if (Session["user"] != null)
            {
                try
                {
                    Cuponera cuponera = (Cuponera)TempData["Cuponera"];


                    if (Fachada.RegistrarPagoSocio(cuponera))
                    {
                        ViewBag.mensaje = "Pago Exitoso";
                        return RedirectToAction("Index", "Socio");
                    }
                    else
                    {
                        ViewBag.mensaje = "Hubo un problema al crear el pago)";
                        return View(cuponera);
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult ConfirmarPaseLibre()
        {
            if (Session["user"] != null)
            {
                try
                {
                    PaseLibre paseLibre = (PaseLibre)TempData["PaseLibre"];


                    if (Fachada.RegistrarPagoSocio(paseLibre))
                    {
                        ViewBag.mensaje = "Pago Exitoso";
                        return RedirectToAction("Index", "Socio");
                    }
                    else
                    {
                        ViewBag.mensaje = "Hubo un problema al crear el pago)";
                        return View(paseLibre);
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult BuscarPagos()
        {
            if (Session["user"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpGet]
        public ActionResult TraerPagos()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult TraerPagos(int? mes, int? anio)
        {
            if (Session["user"] != null)
            {
                if (mes != null && anio != null)
                {
                    List<Pago> pagos = Fachada.TraerPagos((int)mes, (int)anio);
                    return View(pagos);
                }
                else
                {
                    ViewBag.mensaje = "Datos incorrectos.";
                    return View("BuscarPagos");
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
    }
}

