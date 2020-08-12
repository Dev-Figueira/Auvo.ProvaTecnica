using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auvo.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ponto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PontoId = table.Column<Guid>(nullable: false),
                    NomeDoColaborador = table.Column<string>(type: "varchar(50)", nullable: false),
                    Horario = table.Column<string>(type: "varchar(10)", nullable: false),
                    TipoDoRegistro = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registro_Ponto_PontoId",
                        column: x => x.PontoId,
                        principalTable: "Ponto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_PontoId",
                table: "Registro",
                column: "PontoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "Ponto");
        }
    }
}
