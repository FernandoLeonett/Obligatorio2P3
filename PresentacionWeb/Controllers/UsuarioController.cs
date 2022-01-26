using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Auxiliar;
using System.IO;

namespace PresentacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login()
        {
            if (Session["user"] == null)
            {
                return View(new Usuario());
            }
            else
            {
                return RedirectToAction("Index", "Socio");
            }
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {
            if (Session["user"] != null)
            {
                return Redirect("Login");
            }
            if (ModelState.IsValid)
            {
                Usuario unUsuario = Fachada.Login(u);
                if (unUsuario == null)
                {
                    ViewBag.Mensaje = "Usuario y/o contraseña incorrectas";
                    
                }
                else
                {
                    Session["user"] = unUsuario.Email;
                    return RedirectToAction("Index", "Socio");
                }
            }
            return View();
        }

        public ActionResult Usuarios()
        {
            int contAltas = 0;
            int contNoAltas = 0;
            string raizAppWeb = HttpRuntime.AppDomainAppPath;
            string rutaCarpeta = Path.Combine(raizAppWeb, "Archivos");
            string rutaUsuario = rutaCarpeta + "\\Usuarios.txt";
            Stream streamU = new FileStream(rutaUsuario, FileMode.Open);
            StreamReader lectorUsuario = new StreamReader(streamU);
            try
            {
                string lineaUsuario = lectorUsuario.ReadLine().Trim();
                while (lineaUsuario != null)
                {
                    string[] mtUsuario = lineaUsuario.Split('|');
                    Usuario u = new Usuario(mtUsuario[0].Trim(), mtUsuario[1].Trim());

                    if (!Fachada.AltaUsuario(u))
                    {
                        contNoAltas++;
                    }
                    else
                    {
                        contAltas++;
                    }
                    lineaUsuario = lectorUsuario.ReadLine();
                    ViewBag.OK = "Usuarios con alta: " + contAltas;
                    ViewBag.NO = "Usuarios no cargados: " + contNoAltas;
                }
            }
            catch
            {
                ViewBag.Error += "Error en la lectura del archivo";
                lectorUsuario.Close();
            }
            finally
            {
                lectorUsuario.Close();
            }
            return View("Login");
        }


        public ActionResult Horarios()// cambiar nombre a horarios
        {
            int contAltas = 0;
            int contNoAltas = 0;
            string raizAppWeb = HttpRuntime.AppDomainAppPath;
            string rutaCarpeta = Path.Combine(raizAppWeb, "Archivos");
            string rutaUsuario = rutaCarpeta + "\\Horarios.txt";
            Stream streamH = new FileStream(rutaUsuario, FileMode.Open);
            StreamReader streamLinea = new StreamReader(streamH);
            try
            {
                string LineaUsuario = streamLinea.ReadLine().Trim();
                while (LineaUsuario != null)
                {
                    string[] mtHorarioAct = LineaUsuario.Split('|');
                    Actividad a = new Actividad(mtHorarioAct[0].Trim(), Convert.ToInt32(mtHorarioAct[1]), Convert.ToInt32(mtHorarioAct[2]));
                    string diaOK = Fachada.ControlarDiaActividad(mtHorarioAct[4]);
                    int horaOK = Fachada.ValidarHora(mtHorarioAct[3]);//arreglar
                    if (diaOK != null && horaOK > 0)
                    {
                        HorarioActividad horario = new HorarioActividad(a, horaOK, diaOK);
                        if (!Fachada.AltaHorario(horario))
                        {
                            contNoAltas++;
                        }
                        else
                        {
                            contAltas++;
                        }
                    }
                    LineaUsuario = streamLinea.ReadLine();
                }
                ViewBag.OK = "Actividades con alta: " + contAltas;
                ViewBag.NO = "Actividades no cargados: " + contNoAltas;
            }
            catch (Exception e)
            {
                ViewBag.Error += "Error en la lectura del archivo" + e.Message;
                streamH.Close();
            }
            finally
            {
                streamH.Close();
            }
            return View("Login");
        }

        public ActionResult Salir()
        {
            if (Session["user"] != null)
            {
                Session.Abandon();
                return Redirect("Login");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
