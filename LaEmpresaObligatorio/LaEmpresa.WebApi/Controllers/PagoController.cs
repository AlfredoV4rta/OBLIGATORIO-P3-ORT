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
        public IObtenerPagosMensuales _obtenerPagosMensuales;
        public IObtenerUsuariosMayorMonto _obtenerUsuariosMayorMonto;

        public PagoController(
                IObtenerPagos obtenerPagos, 
                IObtenerPagoPorId obtenerPagoPorId, 
                IObtenerPagosMensuales obtenerPagosMensuales,
                IObtenerUsuariosMayorMonto obtenerUsuariosMayorMonto)
        {
            _obtenerPagos = obtenerPagos;
            _obtenerPagoPorId = obtenerPagoPorId;
            _obtenerPagosMensuales = obtenerPagosMensuales;
            _obtenerUsuariosMayorMonto = obtenerUsuariosMayorMonto;
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a cero");
                }
                PagoDTO pago = _obtenerPagoPorId.ObtenerPagoPorId(id);
                return Ok(pago);
            }
            catch (PagoException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("{mes}/{anio}")]

        public IActionResult Get(int mes, int anio)
        {
            try
            {
                if (mes == 0 || anio == 0)
                {
                    return BadRequest("El mes y el año no deben ser vacios");
                }

                if (mes < 0 || mes > 12)
                {
                    return BadRequest("Mes invalido");
                }

                if (anio < 1900 || anio > 3000)
                {
                    return BadRequest("Año invalido");
                }

                IEnumerable<PagoDTO> pagos = _obtenerPagosMensuales.ObtenerPagosMensuales(mes, anio);
                return Ok(pagos);
            }
            catch (PagoException pe)
            {
                return NotFound( pe.Message );
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("usuario/{monto}")]

        public IActionResult Get(double monto)
        {
            try
            {
                if (monto <= 0)
                {
                    return BadRequest("El monto debe ser mayor a cero");
                }

                IEnumerable<UsuarioDTO> usuarios = _obtenerUsuariosMayorMonto.ObtenerUsuariosPagosMayoresMonto(monto);
                return Ok(usuarios);
            }
            catch (PagoException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
