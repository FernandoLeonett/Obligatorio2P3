using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auxiliar;
using Dominio;
using PresentacionWEB.Models;

namespace PresentacionWeb.Controllers
{
    public class SocioController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                List<Socio> socios = Fachada.MostrarSocios();
                return View(socios);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Details(int? cedula)
        {
            if (Session["user"] != null)

            {
                if (cedula != null)
                {

                    Socio socio = Fachada.BuscarSocio((int)cedula);
                    if (socio == null)
                    {
                        ViewBag.mensaje = "No Existe el socio";
                        return View("BuscarPorCedula");
                    }
                    else if (socio.Activo == false)
                    {
                        ViewBag.mensaje = "El socio ya fue dado de baja";
                        return View("BuscarPorCedula");
                    }
                    SocioAldia modelSocio = new SocioAldia(socio);
                    return View(modelSocio);
                }
                ViewBag.mensaje = "Cedula invalida";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                Socio socio = new Socio();
                return View(socio);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Create(Socio socio)
        {
            string mensaje = "No se pudo dar de alta el socio";
            try
            {
                if (ModelState.IsValid) { 
              
                    if (Fachada.RegistrarSocio(socio.Cedula, socio.Nombre, socio.FechaNac))
                    {
                        mensaje = "Alta de socio Exitosa";
                    }
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                else
                {
                    ViewBag.mensaje = mensaje;
                    return View(socio);
                }
            }
            catch
            {
                ViewBag.mensaje = mensaje;
                return View(socio);
            }
        }

        public ActionResult Edit(int? cedula)
        {
            Socio socio;
            if (Session["user"] != null)
            {
                socio = Fachada.BuscarSocio((int)cedula);
                return View(socio);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Edit(Socio socio)
        {
            string mensaje = "No de pudo actualizar datos del socio";
            try
            {
                if (Fachada.ModificarSocio(socio.Cedula, socio.Nombre, socio.FechaNac))
                {
                    mensaje = "Datos actualizados con exito";
                }
                ViewBag.mensaje = mensaje;
                return View();
            }
            catch
            {
                ViewBag.mensaje = mensaje;
                return View();
            }
        }

        public ActionResult BuscarPorCedula()
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
        public ActionResult BuscarPorCedula(int? cedula)
        {
            if (Session["user"] != null)
            {
                if(cedula != null)
                {
                    return RedirectToAction("Details", "Socio", new { cedula });

                }
                else
                {
                    ViewBag.mensaje = "Cedula incorrecta";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Delete(int? cedula)
        {
            if (Session["user"] != null)
            {
                Socio socio = Fachada.BuscarSocio((int)cedula);
                return View(socio);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int cedula, FormCollection collection)
        {
            string mensaje = "No se pudo dar de baja el Socio";
            try
            {
                if (Fachada.EliminarSocio(cedula))
                {
                    mensaje = "Baja de Socio Exitosa";
                }
                ViewBag.mensaje = mensaje;
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.mesaje = mensaje;
                return View();
            }
        }

        public ActionResult BajaSocio(int cedula)
        {
            string mensaje = "No se pudo dar de baja el Socio";
            try
            {
                if (Fachada.EliminarSocio(cedula))
                {
                    mensaje = "Baja de Socio Exitosa";
                }
                ViewBag.mensaje = mensaje;
                return View("Delete");
            }
            catch
            {
                ViewBag.mesaje = mensaje;
                return View("Delete");
            }
        }
    }
}
