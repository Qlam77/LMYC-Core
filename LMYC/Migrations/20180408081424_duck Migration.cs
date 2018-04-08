using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LMYC.Migrations
{
    public partial class duckMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_CreatedBy",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Boats_ReservedBoat",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedBoat",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Boats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_ReservationId",
                table: "Boats",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_Reservations_ReservationId",
                table: "Boats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_Reservations_ReservationId",
                table: "Boats");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Boats_ReservationId",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Boats");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedBoat",
                table: "Reservations",
                column: "ReservedBoat");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_CreatedBy",
                table: "Reservations",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Boats_ReservedBoat",
                table: "Reservations",
                column: "ReservedBoat",
                principalTable: "Boats",
                principalColumn: "BoatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
