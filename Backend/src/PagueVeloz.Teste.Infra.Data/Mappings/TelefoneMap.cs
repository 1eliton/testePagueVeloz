using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueVeloz.Teste.Domain;

namespace PagueVeloz.Teste.Infra.Data.Mappings
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar(12)")
                .HasMaxLength(12)
                .IsRequired();

            builder.HasOne(t => t.Fornecedor)
                .WithMany(wm => wm.Telefones)
                .HasForeignKey(t => t.IdFornecedor);
        }
    }
}