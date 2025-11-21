using LaEmpresa.LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IObtenerPagos _obtenerPagos;
        private IObtenerPagoPorId _obtenerPagoPorId;
        private IObtenerPagosMensuales _obtenerPagosMensuales;
        private IObtenerUsuariosMayorMonto _obtenerUsuariosMayorMonto;
        private IObtenerPagosDeUsuario _obtenerPagosDeUsuario;

        public PagoController(
                IObtenerPagos obtenerPagos, 
                IObtenerPagoPorId obtenerPagoPorId, 
                IObtenerPagosMensuales obtenerPagosMensuales,
                IObtenerUsuariosMayorMonto obtenerUsuariosMayorMonto,
                IObtenerPagosDeUsuario obtenerPagosDeUsuario)
        {
            _obtenerPagos = obtenerPagos;
            _obtenerPagoPorId = obtenerPagoPorId;
            _obtenerPagosMensuales = obtenerPagosMensuales;
            _obtenerUsuariosMayorMonto = obtenerUsuariosMayorMonto;
            _obtenerPagosDeUsuario = obtenerPagosDeUsuario;
        }

        [HttpGet]
        public IActionResult ObtenerPagos()
        {
            try
            {
                IEnumerable<PagoDTO> pagos= _obtenerPagos.ObtenerPagos();
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }


        [HttpGet("{id}")]

        public IActionResult PagosPorID(int id)
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

        public IActionResult PagosMensuales(int mes, int anio)
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

        public IActionResult PagosMayorMonto(double monto)
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

        [HttpGet("pagos/usuario{idUsuario}")]
        [ProducesResponseType(typeof(PagoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult PagosDeUsuario(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                {
                    return BadRequest("Id no valido");
                }
               

                IEnumerable<PagoDTO> pagos = _obtenerPagosDeUsuario.ObtenerPagosDeUsuario(idUsuario);
                return Ok(pagos);
            }
            catch(PagoException pe)
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
