using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class ActividadController : Controller
    {
        public ActionResult BuscarActividades()
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

        public ActionResult BuscarPorNombre()
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
        public ActionResult BuscarPorNombre(string nombre)
        {
            if (Session["user"] != null)
            {
                List<Actividad> actividades = new List<Actividad>();
                try
                {
                    string url = ConfigurationManager.AppSettings["ApiConexion"];
                    url += "Actividad/nombre/" + nombre;
                    Uri uri = new Uri(url);
                    HttpClient proxy = new HttpClient();
                    Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
                    tarea1.Wait();
                    if (tarea1.Result.IsSuccessStatusCode)
                    {
                        Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                        tarea2.Wait();
                        string json = tarea2.Result;
                        actividades = JsonConvert.DeserializeObject<List<Actividad>>(json);
                    }
                    else
                    {
                        ViewBag.Error = "Hubo un problema al buscar las categorías (" + tarea1.Result.StatusCode + ")";
                    }
                }
                catch
                {
                    return RedirectToAction("Login", "Usuario");
                }
                return View("ResultadoBuscado", actividades);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult BuscarPorEdad()
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
        public ActionResult BuscarPorEdad(int? edad)
        {
            if (Session["user"] != null)
            {
                List<Actividad> actividades = new List<Actividad>();
                try
                {
                    string url = ConfigurationManager.AppSettings["ApiConexion"];
                    url += "Actividad/edad/" + edad;
                    Uri uri = new Uri(url);
                    HttpClient proxy = new HttpClient();
                    Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
                    tarea1.Wait();
                    if (tarea1.Result.IsSuccessStatusCode)
                    {
                        Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                        tarea2.Wait();
                        string json = tarea2.Result;
                        actividades = JsonConvert.DeserializeObject<List<Actividad>>(json);
                    }
                    else
                    {
                        ViewBag.Error = "Hubo un problema al buscar las categorías (" + tarea1.Result.StatusCode + ")";
                    }
                }
                catch
                {
                    return View();
                }
                return View("ResultadoBuscado", actividades);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult BuscarPorDiaHora()
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
        // probando git
        public ActionResult BuscarPorDiaHora(string dia, int? hora)
        {
            if (Session["user"] != null)
            {
                List<Actividad> actividades = new List<Actividad>();
                try
                {
                    string url = ConfigurationManager.AppSettings["ApiConexion"];
                    url += "Actividad/fecha/" + dia + "/" + hora;
                    Uri uri = new Uri(url);
                    HttpClient proxy = new HttpClient();
                    Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
                    tarea1.Wait();
                    if (tarea1.Result.IsSuccessStatusCode)
                    {
                        Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                        tarea2.Wait();
                        string json = tarea2.Result;
                        actividades = JsonConvert.DeserializeObject<List<Actividad>>(json);
                    }
                    else
                    {
                        ViewBag.Error = "Hubo un problema al buscar las categorías (" + tarea1.Result.StatusCode + ")";
                    }
                }
                catch
                {
                    return View();
                }
                return View("ResultadoBuscado", actividades);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult ActividadesSocio()
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
        public ActionResult ActividadesSocio(string cedula, string nombre)
        {
            if (Session["user"] != null)
            {
                try
                {
                    if (nombre.Length > 0 && cedula.Length > 0)
                    {
                        int numCedula = Convert.ToInt32(cedula);

                        List<IngresoActividad> ingresos = new List<IngresoActividad>();


                        string url = ConfigurationManager.AppSettings["ApiConexion"];
                        url += "Ingreso/" + cedula + nombre;
                        Uri uri = new Uri(url);
                        HttpClient proxy = new HttpClient();
                        Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
                        tarea1.Wait();
                        if (tarea1.Result.IsSuccessStatusCode)
                        {
                            Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                            tarea2.Wait();
                            string json = tarea2.Result;
                            ingresos = JsonConvert.DeserializeObject<List<IngresoActividad>>(json);
                        }
                        else
                        {
                            ViewBag.Error = "Hubo un problema al buscar las categorías (" + tarea1.Result.StatusCode + ")";
                        }
                    }
                }
                catch
                {
                    ViewBag.mensaje = "Error en los datos";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
    }
}
