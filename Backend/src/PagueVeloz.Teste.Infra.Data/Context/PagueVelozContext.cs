using Microsoft.EntityFrameworkCore;
using PagueVeloz.Teste.Infra.Data.Mappings;

namespace PagueVeloz.Teste.Infra.Data
{
    public class PagueVelozContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            (@"Server=localhost;Database=PagueVelozTeste;Integrated Security=True");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}