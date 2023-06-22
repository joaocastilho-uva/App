using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class qtddisp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "QuantidadeTotal");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDisponivel",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDisponivel",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "QuantidadeTotal",
                table: "Produtos",
                newName: "Quantidade");
        }
    }
}
