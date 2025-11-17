using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //if (HttpContext.Session.GetInt32("usuario") != null)
            {
                try
                {
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Error inesperado." + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Login(string mensaje)
        {
            ViewBag.Error = mensaje;
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string contrasenia)
        {
            try
            {
                
                //HttpContext.Session.SetInt32("usuario", (int)usuarioLogueado.Rol);
                //HttpContext.Session.SetString("email", usuarioLogueado.Email);
                //HttpContext.Session.SetInt32("idUsuario", usuarioLogueado.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Error inesperado." + e;
                return View();
            }
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
           
        }

    }
}
