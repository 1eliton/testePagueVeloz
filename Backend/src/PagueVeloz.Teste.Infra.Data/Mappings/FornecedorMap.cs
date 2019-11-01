using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueVeloz.Teste.Domain;

namespace PagueVeloz.Teste.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(f => f.Rg, rg =>
            {
                rg.Property(r => r.Value)
                    .HasColumnName("Rg")
                    .HasColumnType(SqlDbType.VarChar.ToString())
                    .HasMaxLength(10)
                    .IsRequired(false);
            });

            builder.OwnsOne(f => f.DataNascimento, dataNasc =>
            {
                dataNasc.Property(r => r.Value)
                    .HasColumnName("DataNascimento")
                    .HasColumnType(SqlDbType.DateTime.ToString())
                    .IsRequired(false);
            });

            builder.OwnsOne(f => f.Documento, dataNasc =>
            {
                dataNasc.Property(r => r.Value)
                    .HasColumnName("Documento")
                    .HasColumnType(SqlDbType.DateTime.ToString())
                    .HasMaxLength(15)
                    .IsRequired();
            });

            builder.Property(f => f.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired();

            builder.OwnsMany(f => f.Telefones, tel =>
            {
                tel.Property(t => t.Value)
                    .HasColumnName("Telefone")
                    .HasColumnType(SqlDbType.DateTime.ToString())
                    .HasMaxLength(15)
                    .IsRequired();
            });


            builder.HasOne(f => f.Empresa)
                .WithMany(wh => wh.Fornecedores)
                .HasForeignKey(hf => hf.IdEmpresa)
                .IsRequired();

        }
    }
}