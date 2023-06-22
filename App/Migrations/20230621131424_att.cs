using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensFavorito");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.RenameColumn(
                name: "ValorReserva",
                table: "ItensCarrinho",
                newName: "Valor");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorReserva",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "StandId",
                table: "ItensReserva",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Carrinhos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorReserva",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "StandId",
                table: "ItensReserva");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Carrinhos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "ItensCarrinho",
                newName: "ValorReserva");

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensFavorito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensFavorito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensFavorito_Favoritos_FavoritoId",
                        column: x => x.FavoritoId,
                        principalTable: "Favoritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensFavorito_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensFavorito_FavoritoId",
                table: "ItensFavorito",
                column: "FavoritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensFavorito_ProdutoId",
                table: "ItensFavorito",
                column: "ProdutoId");
        }
    }
}
