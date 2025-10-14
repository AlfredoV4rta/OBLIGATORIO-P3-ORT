using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using LaEmpresa.LogicaNegocio.ValueObjects;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.UsuarioCU
{
    public class AltaUsuarioCU : IAltaUsuario
    {
        private IUsuarioRepositorio _repositorio;

        public AltaUsuarioCU(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void AltaUsuario(UsuarioDTO usuario)
        {
            Usuario nuevoUsuario = UsuarioMapper.FromDTO(usuario);

            string emailUnico = GenerarEmailUnico(nuevoUsuario.NombreCompleto);

            nuevoUsuario.Email = new EmailCompleto { Email = emailUnico }; 
            _repositorio.Add(nuevoUsuario);
        }
        private string GenerarEmailUnico(NombreCompleto nombreCompleto)
        {
            string prefijo = nombreCompleto.ObtenerPartes();
            string emailBase = $"{prefijo}@laEmpresa.com";

           
            if (!ExisteEmail(emailBase))
            {
                return emailBase;
            }

            
            return GenerarEmailConNumero(prefijo);
        }

        private string GenerarEmailConNumero(string prefijo)
        {
            Random random = new Random();
            int maxIntentos = 1000;

            for (int i = 0; i < maxIntentos; i++)
            {
                int numero = random.Next(1, 500);
                string emailCandidato = $"{prefijo}{numero}@laEmpresa.com";

                if (!ExisteEmail(emailCandidato))
                {
                    return emailCandidato;
                }
            }

            throw new UsuarioException("No se pudo generar un email único después de varios intentos");
        }

        private bool ExisteEmail(string email)
        {
            Usuario usuario = _repositorio.FindbyEmail(email);

            return usuario != null;
        }
    }
}
