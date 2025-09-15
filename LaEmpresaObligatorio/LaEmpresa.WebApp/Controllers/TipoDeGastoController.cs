using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class TipoDeGastoController : Controller
    {
        private IObtenerTipoDeGasto _obtenerTipoDeGastoCU;
        private IAltaTipoDeGasto _altaTipoDeGasto;
        
        public TipoDeGastoController (IObtenerTipoDeGasto obtenerTipoCU, IAltaTipoDeGasto altaTipoDeGasto)
        {
            _obtenerTipoDeGastoCU = obtenerTipoCU;
            _altaTipoDeGasto = altaTipoDeGasto;
        }

        public ActionResult Index()
        {
            return View(_obtenerTipoDeGastoCU.ObtenerTiposDeGasto());
        }

 
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeGastoDTO tipoDeGastoDTO)
        {
            try
            {
                _altaTipoDeGasto.AgregarTipoDeGasto(tipoDeGastoDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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


        public ActionResult Delete(int id)
        {
            return View();
        }

       
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
