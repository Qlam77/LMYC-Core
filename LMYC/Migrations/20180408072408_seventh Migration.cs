using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LMYC.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_AspNetUsers_UserId",
                table: "Boats");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Boats",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Boats_UserId",
                table: "Boats",
                newName: "IX_Boats_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_AspNetUsers_CreatorId",
                table: "Boats",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_AspNetUsers_CreatorId",
                table: "Boats");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Boats",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Boats_CreatorId",
                table: "Boats",
                newName: "IX_Boats_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_AspNetUsers_UserId",
                table: "Boats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
