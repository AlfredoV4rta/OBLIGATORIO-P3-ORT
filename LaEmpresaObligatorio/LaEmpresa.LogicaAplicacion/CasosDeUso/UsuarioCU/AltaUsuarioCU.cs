using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

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
            _repositorio.Add(UsuarioMapper.FromDTO(usuario));
        }
    }
}
