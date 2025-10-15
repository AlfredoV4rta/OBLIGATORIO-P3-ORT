using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU
{
    public class ObtenerPagoPorIdCU : IObtenerPagoPorId
    {
        private IPagoRepositorio _repositorio;

        public ObtenerPagoPorIdCU(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public PagoDTO ObtenerPagoPorId(int id)
        {
            return PagoMapper.ToDTO(_repositorio.FindById(id));
        }
    }
}
