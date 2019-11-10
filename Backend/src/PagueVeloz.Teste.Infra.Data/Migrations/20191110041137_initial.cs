using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdEmpresa = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VarChar", maxLength: 150, nullable: false),
                    Rg = table.Column<string>(type: "VarChar", maxLength: 10, nullable: true),
                    DataNascimento = table.Column<string>(type: "varchar(10)", nullable: true),
                    Documento = table.Column<string>(type: "VarChar", maxLength: 15, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_IdEmpresa",
                table: "Fornecedor",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
