using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class valoratual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exclusivo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PermiteReserva",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "ValorReserva",
                table: "Produtos",
                newName: "ValorAtual");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorAtual",
                table: "Produtos",
                newName: "ValorReserva");

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
        }
    }
}
