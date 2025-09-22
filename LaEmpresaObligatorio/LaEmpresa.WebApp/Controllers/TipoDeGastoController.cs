using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
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
            return View(_obtenerTipoDeGastoCU.ObtenerTiposDeGasto());
        }

 
        public ActionResult Details(int id)
        {
            return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
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

        public ActionResult Edit(TipoDeGastoDTO aEditar)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeGastoDTO aEditar, IFormCollection collection)
        {
            try
            {
                _editarTipoDeGasto.EditarTipoDeGasto(aEditar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _borrarTipoDeGasto.BorrarTipoDeGasto(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
