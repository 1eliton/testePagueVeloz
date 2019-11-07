using Microsoft.EntityFrameworkCore.Migrations;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    public partial class correcao_mapeanto_hasmaxlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Fornecedor_FornecedorId",
                table: "Telefone");

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "Empresa",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Empresa",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresa",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Fornecedor_FornecedorId",
                table: "Telefone",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Fornecedor_FornecedorId",
                table: "Telefone");

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "Empresa",
                type: "VarChar",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Empresa",
                type: "VarChar",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresa",
                type: "VarChar",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Fornecedor_FornecedorId",
                table: "Telefone",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
