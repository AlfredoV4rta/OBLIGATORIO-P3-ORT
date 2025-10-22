using LaEmpresa.LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaNegocio.Exceptions;

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

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                PagoDTO pago = _obtenerPagoPorId.ObtenerPagoPorId(id);
                return Ok(pago);
            }
            catch (PagoException pe)
            {
                return BadRequest(new { error = pe.Message});
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, new {error = ex.Message});
            }
        }
    }
}
