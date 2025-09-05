using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EnMemoria
{
    public class RepositorioPago : IPagoRepositorio
    {
        public void Add(Pago obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pago> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pago FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Pago FindByUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pago obj)
        {
            throw new NotImplementedException();
        }
    }
}
