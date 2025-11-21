using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU
{
    public class ObtenerEquiposMayorMontoCU : IObtenerEquiposMayorMonto
    {

        private IPagoRepositorio _repositorioPago;

        public ObtenerEquiposMayorMontoCU(IPagoRepositorio repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }
        public IEnumerable<Equipo> ObtenerEquiposMayorMonto(double monto)
        {
            if (monto == null || monto < 0)
            {
                throw new PagoException("Monto inváido");
            }

            IEnumerable<Equipo> toReturn = _repositorioPago.EquiposMayorMonto(monto);

            return (IEnumerable<Equipo>) toReturn.Select(equipo => EquipoMapper.toDTO(equipo));
        }

    }
}
