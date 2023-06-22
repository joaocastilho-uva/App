using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class att5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_StandId",
                table: "ItensReserva",
                column: "StandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensReserva_Stands_StandId",
                table: "ItensReserva",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensReserva_Stands_StandId",
                table: "ItensReserva");

            migrationBuilder.DropIndex(
                name: "IX_ItensReserva_StandId",
                table: "ItensReserva");

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
    }
}
