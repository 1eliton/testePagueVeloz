using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PagueVeloz.Teste.Infra.Data.Mappings;

namespace PagueVeloz.Teste.Infra.Data
{
    public class PagueVelozContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            //(@"Data Source=DESKTOP-5SL3KKS;Initial Catalog=PagueVelozTeste");
            (@"Server=localhost;Database=PagueVelozTeste;Integrated Security=True");

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