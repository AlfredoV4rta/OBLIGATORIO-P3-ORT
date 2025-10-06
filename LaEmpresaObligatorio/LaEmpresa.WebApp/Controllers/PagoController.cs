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

        public PagoController(IAltaPago altaPago, IObtenerTipoDeGasto obtenerTipoDeGasto)
        {
            _altaPago = altaPago;
            _obtenerTipoDeGasto = obtenerTipoDeGasto;
        }

        // GET: PagoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public ActionResult Create()
        {
            ViewBag.TiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();
            return View();
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {
                ViewBag.TiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();
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
    }
}
