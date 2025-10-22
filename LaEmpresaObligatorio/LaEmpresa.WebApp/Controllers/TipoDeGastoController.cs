using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class TipoDeGastoController : Controller
    {
        private IAltaTipoDeGasto _altaTipoDeGasto;
        private IBorrarTipoDeGasto _borrarTipoDeGasto;
        private IObtenerTipoDeGasto _obtenerTipoDeGastoCU;
        private IObtenerTipoDeGastoPorId _obtenerTipoDeGastoPorId;
        private IEditarTipoDeGasto _editarTipoDeGasto;
        
        public TipoDeGastoController (
            IObtenerTipoDeGasto obtenerTipoCU, 
            IAltaTipoDeGasto altaTipoDeGasto, 
            IBorrarTipoDeGasto borrarTipoDeGasto,
            IObtenerTipoDeGastoPorId obtenerTipoDeGastoPorId,
            IEditarTipoDeGasto editarTipoDeGasto)
        {
            _obtenerTipoDeGastoCU = obtenerTipoCU;
            _altaTipoDeGasto = altaTipoDeGasto;
            _borrarTipoDeGasto = borrarTipoDeGasto;
            _obtenerTipoDeGastoPorId = obtenerTipoDeGastoPorId;
            _editarTipoDeGasto = editarTipoDeGasto;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                { 
                    try
                    {
                        return View(_obtenerTipoDeGastoCU.ObtenerTiposDeGasto());
                    }
                    catch (TipoDeGastoException tg)
                    {
                        ViewBag.Mensaje = tg.Message;
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

 
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    try
                    {
                        return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
                    }
                    catch (TipoDeGastoException tg)
                    {
                        ViewBag.Mensaje = tg.Message;
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

        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");

            
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeGastoDTO tipoDeGastoDTO)
        {
            try
            {
                string email = HttpContext.Session.GetString("email");
                _altaTipoDeGasto.AgregarTipoDeGasto(tipoDeGastoDTO, email);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    try
                    {
                        return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
                    }
                    catch (TipoDeGastoException tg)
                    {
                        ViewBag.Mensaje = tg.Message;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeGastoDTO aEditar, IFormCollection collection)
        {
            try
            {
                string email = HttpContext.Session.GetString("email");
                _editarTipoDeGasto.EditarTipoDeGasto(aEditar, email);
                return RedirectToAction(nameof(Index));
            }
            catch (TipoDeGastoException tg)
            {
                ViewBag.Error = tg.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    try
                    {
                        return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
                    }
                    catch (TipoDeGastoException tg)
                    {
                        ViewBag.Mensaje = tg.Message;
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                string email = HttpContext.Session.GetString("email");
                _borrarTipoDeGasto.BorrarTipoDeGasto(id, email);
                return RedirectToAction(nameof(Index));
            }
            catch (TipoDeGastoException tg)
            {
                ViewBag.Error = tg.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }
    }
}
