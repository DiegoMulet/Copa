using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Copa.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Selecoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Eliminada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Selecao1Id = table.Column<int>(nullable: false),
                    Selecao2Id = table.Column<int>(nullable: false),
                    DataConfronto = table.Column<DateTime>(nullable: false),
                    QtdGols1 = table.Column<int>(nullable: true),
                    QtdGols2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chaves_Selecoes_Selecao1Id",
                        column: x => x.Selecao1Id,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chaves_Selecoes_Selecao2Id",
                        column: x => x.Selecao2Id,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chaves_Selecao1Id",
                table: "Chaves",
                column: "Selecao1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chaves_Selecao2Id",
                table: "Chaves",
                column: "Selecao2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chaves");

            migrationBuilder.DropTable(
                name: "Selecoes");
        }
    }
}
