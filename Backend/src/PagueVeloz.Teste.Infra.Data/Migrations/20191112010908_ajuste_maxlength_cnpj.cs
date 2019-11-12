using Microsoft.EntityFrameworkCore.Migrations;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    public partial class ajuste_maxlength_cnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Documento_TipoPessoa",
                table: "Fornecedor",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresa",
                type: "varchar(19)",
                maxLength: 19,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento_TipoPessoa",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresa",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(19)",
                oldMaxLength: 19);
        }
    }
}
