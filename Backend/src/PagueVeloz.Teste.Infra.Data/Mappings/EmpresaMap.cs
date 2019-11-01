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
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Uf)
                .HasColumnName("Uf")
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(2)
                .IsRequired();

            builder.OwnsOne(e => e.Cnpj, cnpj =>
            {
                cnpj.Property(e => e.Value)
                    .HasColumnType(SqlDbType.VarChar.ToString())
                    .HasMaxLength(14)
                    .HasColumnName("Cnpj")
                    .IsRequired();
            });


            builder.HasMany(e => e.Fornecedores)
                .WithOne()
                .HasForeignKey(f => f.IdEmpresa)
                .IsRequired(false);
        }
    }
}