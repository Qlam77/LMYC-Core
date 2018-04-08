using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LMYC.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_AspNetUsers_CreatedBy",
                table: "Boats");

            migrationBuilder.DropIndex(
                name: "IX_Boats_CreatedBy",
                table: "Boats");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Boats",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Boats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boats_UserId",
                table: "Boats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_AspNetUsers_UserId",
                table: "Boats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_AspNetUsers_UserId",
                table: "Boats");

            migrationBuilder.DropIndex(
                name: "IX_Boats_UserId",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Boats");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Boats",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boats_CreatedBy",
                table: "Boats",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_AspNetUsers_CreatedBy",
                table: "Boats",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
