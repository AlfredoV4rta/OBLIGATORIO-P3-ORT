using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EnMemoria
{
    public class RepositorioTipoDeGasto : ITipoDeGastoRepositorio
    {
        public List<TipoDeGasto> TiposGasto = new List<TipoDeGasto>();

        public RepositorioTipoDeGasto()
        {
            TiposGasto.Add(new TipoDeGasto { Id = 1, Nombre = "Alquiler", Descripcion = "Alquiler de ofiinas" });
            TiposGasto.Add(new TipoDeGasto { Id = 2, Nombre = "Servicios Públicos", Descripcion = "Pago de electricidad, agua, gas y saneamiento." });
            TiposGasto.Add(new TipoDeGasto { Id = 3, Nombre = "Internet y Telefonía", Descripcion = "Facturas de telefonía fija, móvil y conexión a internet." });
            TiposGasto.Add(new TipoDeGasto { Id = 4, Nombre = "Sueldos y Salarios", Descripcion = "Pago de remuneraciones al personal y cargas sociales." });
            TiposGasto.Add(new TipoDeGasto { Id = 5, Nombre = "Papelería y Oficina", Descripcion = "Compra de insumos de oficina como papel, tinta, lapiceras, carpetas, etc." });
        }
        public void Add(TipoDeGasto obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoDeGasto> FindAll()
        {
            return new List<TipoDeGasto> (TiposGasto);
        }

        public TipoDeGasto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoDeGasto obj)
        {
            throw new NotImplementedException();
        }
    }
}
