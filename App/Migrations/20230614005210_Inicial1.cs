using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class Inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Favoritos_FavoritoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "ItensStand");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FavoritoId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "FavoritoId",
                table: "Produtos",
                newName: "UsuarioAlteracao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produtos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInclusao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Exclusivo",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PermiteReserva",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StandId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioInclusao",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorReserva",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                name: "IX_Produtos_StandId",
                table: "Produtos",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_ProdutoId",
                table: "ItensReserva",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinho_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritoProduto_ProdutosId",
                table: "FavoritoProduto",
                column: "ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCarrinho_Produtos_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensReserva_Produtos_ProdutoId",
                table: "ItensReserva",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Stands_StandId",
                table: "Produtos",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCarrinho_Produtos_ProdutoId",
                table: "ItensCarrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensReserva_Produtos_ProdutoId",
                table: "ItensReserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Stands_StandId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "FavoritoProduto");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_StandId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_ItensReserva_ProdutoId",
                table: "ItensReserva");

            migrationBuilder.DropIndex(
                name: "IX_ItensCarrinho_ProdutoId",
                table: "ItensCarrinho");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataInclusao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Exclusivo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PermiteReserva",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "StandId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ValorReserva",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "UsuarioAlteracao",
                table: "Produtos",
                newName: "FavoritoId");

            migrationBuilder.CreateTable(
                name: "ItensStand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exclusivo = table.Column<bool>(type: "bit", nullable: false),
                    PermiteReserva = table.Column<bool>(type: "bit", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    StandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioInclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensStand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensStand_Stands_StandId",
                        column: x => x.StandId,
                        principalTable: "Stands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FavoritoId",
                table: "Produtos",
                column: "FavoritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensStand_StandId",
                table: "ItensStand",
                column: "StandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Favoritos_FavoritoId",
                table: "Produtos",
                column: "FavoritoId",
                principalTable: "Favoritos",
                principalColumn: "Id");
        }
    }
}
