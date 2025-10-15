using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace LaEmpresa.WebApp.Controllers
{
    public class PagoController : Controller
    {
        private IAltaPago _altaPago;
        private IObtenerTipoDeGasto _obtenerTipoDeGasto;
        private IObtenerPagos _obtenerPagos;
        private IObtenerPagosMensuales _obtenerPagosMensuales;
        private IObtenerUsuariosMayorMonto _obtenerUsuariosMayorMonto;

        public PagoController(
            IAltaPago altaPago, 
            IObtenerTipoDeGasto obtenerTipoDeGasto,
            IObtenerPagos obtenerPagos,
            IObtenerPagosMensuales obtenerPagosMensuales,
            IObtenerUsuariosMayorMonto obtenerUsuariosMayorMonto)
        {
            _altaPago = altaPago;
            _obtenerTipoDeGasto = obtenerTipoDeGasto;
            _obtenerPagos = obtenerPagos;
            _obtenerPagosMensuales = obtenerPagosMensuales;
            _obtenerUsuariosMayorMonto = obtenerUsuariosMayorMonto;
        }

        // GET: PagoController
        public ActionResult Index()
        {
            if(HttpContext.Session.GetInt32("rol") != null)
            {
                try
                {
                    return View();
                }
                catch (PagoException pe)
                {
                    ViewBag.Error = pe.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado" + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("rol") != null)
            {
                try
                {
                    ViewBag.TiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();
                    return View();
                }
                catch (PagoException pe)
                {
                    ViewBag.Error = pe.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado" + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {
                ViewBag.TiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();
                pagoDto.IdUsuario = (int)HttpContext.Session.GetInt32("idUsuario");
                _altaPago.AltaPago(pagoDto);
                return RedirectToAction(nameof(Index));
            }
            catch(PagoException pe)
            {
                ViewBag.Error = pe.Message;
                return View();
            }catch(Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }

        // GET: PagoController/Create
        public ActionResult CreateUnico()
        {

            if (HttpContext.Session.GetInt32("rol") != null)
            {
                try
                {
                    ViewBag.TiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();
                    return View();
                }
                catch (PagoException pex)
                {
                    ViewBag.Error = pex.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado" + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUnico(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {
                ViewBag.TiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();
                pagoDto.IdUsuario = (int)HttpContext.Session.GetInt32("idUsuario");
                _altaPago.AltaPago(pagoDto);
                return RedirectToAction(nameof(Index));
            }
            catch (PagoException pe)
            {
                ViewBag.Error = pe.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }



        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagoController/Edit/5
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

        // GET: PagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagoController/Delete/5
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

        public IActionResult ListarPagosMensuales()
        {
            if (HttpContext.Session.GetInt32("rol") != null)
            {
                if (HttpContext.Session.GetInt32("rol") == 2)
                {
                    try
                    {
                        return View();
                    }
                    catch (PagoException pe)
                    {
                        ViewBag.Error = pe.Message;
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error inesperado" + ex;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult ListarPagosMensuales(int mes, int anio)
        {
            try
            {
                if (mes == 0 || anio == 0)
                {
                    ViewBag.Error = "El mes y el año no deben ser vacios";
                    return View();
                }

                IEnumerable<PagoDTO> pagos = _obtenerPagosMensuales.ObtenerPagosMensuales(mes, anio).ToList();

                if (pagos == null || pagos.Count() == 0)
                {
                    ViewBag.Error = "No hay pagos filtrados para esa fecha, ingrese otro mes y año para continuar";
                    return View();
                }
                return View(pagos);
            }
            catch (PagoException pe)
            {
                ViewBag.Error = pe.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }

        public IActionResult ListarUsuariosPagoMonto()
        {
            if (HttpContext.Session.GetInt32("rol") != null)
            {
                if (HttpContext.Session.GetInt32("rol") == 2)
                {
                    try
                    {
                        return View();
                    }
                    catch (PagoException pe)
                    {
                        ViewBag.Error = pe.Message;
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error inesperado" + ex;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]

        public IActionResult ListarUsuariosPagoMonto(int monto)
        {
            try
            {
                if (monto <= 0)
                {
                    ViewBag.Error = "El monto debe ser mayor a cero";
                    return View();
                }

                IEnumerable<UsuarioDTO> usuarios = _obtenerUsuariosMayorMonto.ObtenerUsuariosPagosMayoresMonto(monto);

                if (usuarios == null || usuarios.Count() == 0)
                {
                    ViewBag.Error = "No hay usuarios que superen ese monto de pago";
                    return View();
                }

                return View(usuarios);
            }
            catch (PagoException pe)
            {
                ViewBag.Error = pe.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }
    }
}
