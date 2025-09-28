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
            return View(_obtenerUsuariosCU.ObtenerUsuarios());
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
                HttpContext.Session.SetString("usuario", usuarioLogueado.Nombre);
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
