using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin _loginCU;

        public LoginController(ILogin loginCU)
        {
            _loginCU = loginCU;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]

        public IActionResult Login([FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                UsuarioDTO logueado = _loginCU.Login(usuarioDto.Email, usuarioDto.Contrasenia);
                var token = ManejadorJWT.GenerarToken(logueado);
                logueado.Token = token.ToString();

                return Ok(logueado);
            }
            catch (UsuarioException uex)
            {
                return Unauthorized(uex.Message);
            }
        }
    }
}
