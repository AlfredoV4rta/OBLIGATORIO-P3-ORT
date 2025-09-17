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
    public class AltaTipoDeGastoCU : IAltaTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorio;

        public AltaTipoDeGastoCU(ITipoDeGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void AgregarTipoDeGasto(TipoDeGastoDTO nuevoTipoGasto)
        {
            _repositorio.Add(TipoDeGastoMapper.FromDTO(nuevoTipoGasto));
        }
    }
}
