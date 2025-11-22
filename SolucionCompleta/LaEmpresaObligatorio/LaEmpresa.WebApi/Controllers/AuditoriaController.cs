using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosAuditoria;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController: ControllerBase
    {
        private IObtenerAuditoriasTipoDeGasto _obtenerAuditoriaTipoDeGasto;

        public AuditoriaController(IObtenerAuditoriasTipoDeGasto obtenerAuditoriaTipoDeGasto)
        {
            _obtenerAuditoriaTipoDeGasto = obtenerAuditoriaTipoDeGasto;
        }

        [HttpGet("tipoDeGasto/{idTipoDeGasto}")]
        [ProducesResponseType(typeof(AuditoriaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]

        public IActionResult ObtenerPorIdTipoDeGasto(int idTipoDeGasto)
        {
            try
            {
                if (idTipoDeGasto <= 0)
                {
                    return BadRequest("Id tiene que ser mayor a 0");
                }

                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                IEnumerable<AuditoriaDTO> auditorias = _obtenerAuditoriaTipoDeGasto.ObtenerAuditoriasIdTipoGasto(idTipoDeGasto);
                return Ok(auditorias);
            }
            catch (AuditoriaException pe)
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
