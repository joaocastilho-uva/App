using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class att1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StandId",
                table: "Reservas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_StandId",
                table: "Reservas",
                column: "StandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Stands_StandId",
                table: "Reservas",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Stands_StandId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_StandId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "StandId",
                table: "Reservas");
        }
    }
}
