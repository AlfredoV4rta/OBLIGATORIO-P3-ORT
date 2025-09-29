using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.Entidades;
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
        private IAuditoriaRepositorio _auditoriaRepositorio;

        public BorrarTipoDeGastoCU(ITipoDeGastoRepositorio repositorio, IAuditoriaRepositorio auditoria)
        {
            _repositorio = repositorio;
            _auditoriaRepositorio = auditoria;
        }

        public void BorrarTipoDeGasto(int id, string email)
        {
            _repositorio.Remove(id);
            _auditoriaRepositorio.Add(new Auditoria(email, "Borrar"));
        }
    }
}
