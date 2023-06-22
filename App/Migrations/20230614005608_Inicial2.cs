using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Stands_StandId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_StandId",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "ProdutoStand",
                columns: table => new
                {
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoStand", x => new { x.ProdutosId, x.StandsId });
                    table.ForeignKey(
                        name: "FK_ProdutoStand_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoStand_Stands_StandsId",
                        column: x => x.StandsId,
                        principalTable: "Stands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoStand_StandsId",
                table: "ProdutoStand",
                column: "StandsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoStand");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_StandId",
                table: "Produtos",
                column: "StandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Stands_StandId",
                table: "Produtos",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
