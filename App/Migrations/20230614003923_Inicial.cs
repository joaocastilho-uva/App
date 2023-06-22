using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                });

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
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proprietario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensCarrinho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarrinhoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigem = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Comprimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Largura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FavoritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Favoritos_FavoritoId",
                        column: x => x.FavoritoId,
                        principalTable: "Favoritos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensReserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensReserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensStand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PermiteReserva = table.Column<bool>(type: "bit", nullable: false),
                    Exclusivo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioInclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "IX_ItensCarrinho_CarrinhoId",
                table: "ItensCarrinho",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_ReservaId",
                table: "ItensReserva",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensStand_StandId",
                table: "ItensStand",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FavoritoId",
                table: "Produtos",
                column: "FavoritoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCarrinho");

            migrationBuilder.DropTable(
                name: "ItensReserva");

            migrationBuilder.DropTable(
                name: "ItensStand");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Stands");

            migrationBuilder.DropTable(
                name: "Favoritos");
        }
    }
}
