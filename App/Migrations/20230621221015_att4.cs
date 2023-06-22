using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class att4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Reservas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Carrinhos",
                newName: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Reservas",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Carrinhos",
                newName: "Usuario");
        }
    }
}
