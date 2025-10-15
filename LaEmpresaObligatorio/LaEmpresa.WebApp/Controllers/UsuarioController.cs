using LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosEquipo;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private IAltaUsuario _altaUsuario;
        private IObtenerEquipos _obtenerEquipos;

        public UsuarioController(IAltaUsuario altaUsuario, IObtenerEquipos obtenerEquipos)
        {
            _altaUsuario = altaUsuario;
            _obtenerEquipos = obtenerEquipos;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("rol") != null)
            {
                if (HttpContext.Session.GetInt32("rol") == 0)
                {
                    try
                    {
                        ViewBag.Equipos = _obtenerEquipos.ObtenerEquipos();
                        return View();
                    }
                    catch (UsuarioException uex)
                    {
                        ViewBag.Mensaje = uex.Message;
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }


        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, UsuarioDTO userDto)
        {
            try
            {
                ViewBag.Equipos = _obtenerEquipos.ObtenerEquipos();
                _altaUsuario.AltaUsuario(userDto);
                ViewBag.Mensaje = "Usuario creado con exito";
                return View();
                
            }
            catch (UsuarioException ue)
            {
                ViewBag.Error = ue.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
