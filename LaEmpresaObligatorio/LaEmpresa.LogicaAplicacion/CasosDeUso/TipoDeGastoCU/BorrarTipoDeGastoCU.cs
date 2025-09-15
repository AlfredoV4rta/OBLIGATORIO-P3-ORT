using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU
{
    public class BorrarTipoDeGastoCU : IBorrarTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorio;

        public BorrarTipoDeGastoCU(ITipoDeGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void BorrarTipoDeGasto(int id)
        {
            _repositorio.Remove(id);
        }
    }
}
