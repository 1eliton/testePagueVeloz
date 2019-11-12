using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueVeloz.Teste.Domain;

namespace PagueVeloz.Teste.Infra.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Uf)
                .HasColumnName("Uf")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.OwnsOne(e => e.Cnpj, cnpj =>
            {
                cnpj.Property(e => e.Value)
                    .HasColumnType("varchar(19)")
                    .HasMaxLength(19)
                    .HasColumnName("Cnpj")
                    .IsRequired();
            });


            builder.HasMany(e => e.Fornecedores)
                .WithOne()
                .HasForeignKey(f => f.IdEmpresa);
        }
    }
}