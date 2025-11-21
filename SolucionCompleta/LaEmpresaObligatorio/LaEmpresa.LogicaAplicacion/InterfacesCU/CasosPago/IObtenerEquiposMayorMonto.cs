using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago
{
    public interface IObtenerEquiposMayorMonto
    {
        public IEnumerable<Equipo> ObtenerEquiposMayorMonto(double monto);
    }
}
