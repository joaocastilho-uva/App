using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class Inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritoProduto");

            migrationBuilder.CreateTable(
                name: "ItensFavorito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensFavorito");

            migrationBuilder.CreateTable(
                name: "FavoritoProduto",
                columns: table => new
                {
                    FavoritosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritoProduto", x => new { x.FavoritosId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_FavoritoProduto_Favoritos_FavoritosId",
                        column: x => x.FavoritosId,
                        principalTable: "Favoritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritoProduto_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritoProduto_ProdutosId",
                table: "FavoritoProduto",
                column: "ProdutosId");
        }
    }
}
