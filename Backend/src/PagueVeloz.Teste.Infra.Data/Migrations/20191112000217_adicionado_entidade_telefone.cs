using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    public partial class adicionado_entidade_telefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Fornecedor",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdFornecedor = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_IdFornecedor",
                table: "Telefone",
                column: "IdFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Fornecedor",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
