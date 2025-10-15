using LaEmpresa.LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        public IObtenerPagos _obtenerPagos;
        public IObtenerPagoPorId _obtenerPagoPorId;

        public PagoController(IObtenerPagos obtenerPagos, IObtenerPagoPorId obtenerPagoPorId)
        {
            _obtenerPagos = obtenerPagos;
            _obtenerPagoPorId = obtenerPagoPorId;
        }

        [HttpGet()]

        public IEnumerable<PagoDTO> Get()
        {
            return _obtenerPagos.ObtenerPagos();
        }

        [HttpGet("{id}")]

        public PagoDTO Get(int id)
        {
            return _obtenerPagoPorId.ObtenerPagoPorId(id);
        }
    }
}
