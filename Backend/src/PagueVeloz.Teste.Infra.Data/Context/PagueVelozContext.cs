using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PagueVeloz.Teste.Infra.Data.Mappings;

namespace PagueVeloz.Teste.Infra.Data
{
    public class PagueVelozContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connString");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}