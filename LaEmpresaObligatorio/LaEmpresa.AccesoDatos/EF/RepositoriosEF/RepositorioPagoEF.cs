using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioPagoEF : IPagoRepositorio
    {
        private LaEmpresaContext _context;

        public RepositorioPagoEF(LaEmpresaContext context)
        {
            _context = context;
        }
        public void Add(Pago obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Pago> FindAll()
        {
            return _context.Pagos;
        }

        public Pago FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pago> GetByMonthYear(int month, int year)
        {
            DateTime fechaBuscada = new DateTime(year, month, 1);

            return _context.Unicos
                .Where(u => u.FechaDePago.Month == month && u.FechaDePago.Year == year)
                .Cast<Pago>()
                .Concat(
                    _context.Recurrentes
                        .Where(r => r.FechaDesde <= fechaBuscada && r.FechaHasta >= fechaBuscada)
                        .Cast<Pago>()
                )
                .ToList();
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
