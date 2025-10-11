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
    public class ObtenerPagosMensualesCU : IObtenerPagosMensuales
    {
        private IPagoRepositorio _repositorioPago;

        public ObtenerPagosMensualesCU(IPagoRepositorio repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }

        public IEnumerable<PagoDTO> ObtenerPagosMensuales(int mes, int anio)
        {
            
        }
    }
}
