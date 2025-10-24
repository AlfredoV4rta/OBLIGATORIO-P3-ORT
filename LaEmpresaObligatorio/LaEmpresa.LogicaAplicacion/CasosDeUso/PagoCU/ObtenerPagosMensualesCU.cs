using Azure;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
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
            if (mes == 0 || anio == 0)
            {
                throw new PagoException ("El mes y el año no deben ser vacios");    
            }

            if (mes < 0 || mes > 12)
            {
                throw new PagoException ("Mes invalido");
            }

            if (anio < 1900 || anio > 3000)
            {
                 throw new PagoException ("Año invalido");
            }

            IEnumerable<Pago> toReturn = _repositorioPago.GetByMonthYear(mes, anio);


            if (toReturn == null || toReturn.Count() == 0)
            {
                throw new PagoException ("No hay pagos filtrados para esa fecha, ingrese otro mes y año para continuar");
            }

            return toReturn.Select(pago => PagoMapper.ToDTO(pago));
        }
    }
}
