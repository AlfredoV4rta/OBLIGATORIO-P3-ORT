using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static string uriHome = "http://localhost:5140/api/Home";
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
                HttpClient cliente = new HttpClient();
                Uri uri = new Uri(uriHome);
                
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
