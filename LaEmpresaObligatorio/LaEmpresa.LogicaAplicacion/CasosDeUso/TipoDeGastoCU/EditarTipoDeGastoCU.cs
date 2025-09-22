using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU
{
    public class EditarTipoDeGastoCU : IEditarTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorio;
        
        public EditarTipoDeGastoCU(ITipoDeGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        
        public void EditarTipoDeGasto(TipoDeGastoDTO tipoDeGastoDTO)
        {
           _repositorio.Update(TipoDeGastoMapper.FromDTO(tipoDeGastoDTO));
        }
    }
}
