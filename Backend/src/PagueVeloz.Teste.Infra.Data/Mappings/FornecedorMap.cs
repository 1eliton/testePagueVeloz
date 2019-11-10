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
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(f => f.Rg, rg =>
            {
                rg.Property(r => r.Value)
                    .HasColumnName("Rg")
                    .HasColumnType("varchar(10)")
                    .HasMaxLength(10)
                    .IsRequired(false);
            });

            builder.Property(f => f.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("varchar(20)")
                .IsRequired(false);

            //builder.OwnsOne(f => f.DataNascimento, dataNasc =>
            //{
            //    dataNasc.Property(r => r.Value)
            //        .HasColumnName("DataNascimento")
            //        .HasColumnType(SqlDbType.DateTime.ToString());
            //});w

            builder.OwnsOne(f => f.Documento, doc =>
            {
                doc.Property(r => r.Value)
                    .HasColumnName("Documento")
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(15)
                    .IsRequired();
            });

            builder.Property(f => f.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired();

            //builder.OwnsMany(f => f.Telefones, tel =>
            //{
            //    tel.Property(t => t.Value)
            //        .HasColumnName("Telefone")
            //        .HasColumnType(SqlDbType.VarChar.ToString())
            //        .HasMaxLength(15)
            //        .IsRequired();
            //});


            builder.HasOne(f => f.Empresa)
                .WithMany(wh => wh.Fornecedores)
                .HasForeignKey(hf => hf.IdEmpresa)
                .IsRequired();

        }
    }
}