using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioTipoDeGastoEF : ITipoDeGastoRepositorio
    {
        private LaEmpresaContext _context;

        public RepositorioTipoDeGastoEF(LaEmpresaContext context)
        {
            _context = context;
        }
        
        public void Add(TipoDeGasto obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TipoDeGasto> FindAll()
        {
            return _context.TipoDeGastos;
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
