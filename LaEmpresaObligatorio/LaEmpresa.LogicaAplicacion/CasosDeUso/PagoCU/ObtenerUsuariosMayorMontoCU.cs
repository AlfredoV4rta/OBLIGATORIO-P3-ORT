using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU
{
    public class ObtenerUsuariosMayorMontoCU : IObtenerUsuariosMayorMonto
    {
        private IPagoRepositorio _repositorioPago;

        public ObtenerUsuariosMayorMontoCU(IPagoRepositorio repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }
        public IEnumerable<UsuarioDTO> ObtenerUsuariosPagosMayoresMonto(double monto)
        {
            IEnumerable<Usuario> toReturn = _repositorioPago.UsuarioMayorMonto(monto);

            return toReturn.Select(usuario => UsuarioMapper.ToDTO(usuario));
        }

    }
}
