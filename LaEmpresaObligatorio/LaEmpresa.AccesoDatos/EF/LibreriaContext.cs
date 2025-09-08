using LaEmpresa.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF
{
    public class LibreriaContext : DbContext
    {
        public DbSet<TipoDeGasto> TipoDeGastos { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"SERVER = (localdb)\MsSqlLocalDb;" +
                "DATABASE = LaEmpresaDB;" +
                "Integrated Security = true;"
            );
        } 
    }
}
