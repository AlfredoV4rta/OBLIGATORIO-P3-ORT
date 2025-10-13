using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
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

            IEnumerable<Pago> pagos = _context.Pagos.Include(pago => pago.TipoGasto)
                                             .Include(pago =>pago.Usuario).ToList();
            pagos = pagos.Where(p =>
                (p is Unico && ((Unico)p).FechaDePago.Month == month && ((Unico)p).FechaDePago.Year == year)
                ||
                (p is Recurrente && fechaBuscada >= ((Recurrente)p).FechaDesde
                    && fechaBuscada <= ((Recurrente)p).FechaHasta));

            return pagos;
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
