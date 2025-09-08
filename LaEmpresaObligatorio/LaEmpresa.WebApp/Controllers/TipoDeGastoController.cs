using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class TipoDeGastoController : Controller
    {
        private IObtenerTipoDeGasto _obtenerTipoDeGastoCU;
        
        public TipoDeGastoController (IObtenerTipoDeGasto obtenerTipoCU)
        {
            _obtenerTipoDeGastoCU = obtenerTipoCU;
        }
        // GET: TipoDeGastoController
        public ActionResult Index()
        {
            return View(_obtenerTipoDeGastoCU.ObtenerTiposDeGasto());
        }

        // GET: TipoDeGastoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDeGastoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeGastoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TipoDeGastoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoDeGastoController/Edit/5
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

        // GET: TipoDeGastoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDeGastoController/Delete/5
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
