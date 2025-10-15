using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILogin _loginCU;
        private IObtenerUsuarios _obtenerUsuariosCU;

        public HomeController (ILogin loginCU, IObtenerUsuarios obtenerUsuariosCU)
        {
            _loginCU = loginCU;
            _obtenerUsuariosCU = obtenerUsuariosCU;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("rol") != null)
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
                UsuarioDTO usuarioLogueado = _loginCU.Login(email, contrasenia);
                HttpContext.Session.SetInt32("usuario", (int)usuarioLogueado.Rol);
                HttpContext.Session.SetString("email", usuarioLogueado.Email);
                HttpContext.Session.SetInt32("idUsuario", usuarioLogueado.Id);
                return RedirectToAction("Index");
            }
            catch (UsuarioException ue)
            {
                ViewBag.Error = ue.Message;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "Error inesperado." + e;
                return View();
            }
        }

    }
}
