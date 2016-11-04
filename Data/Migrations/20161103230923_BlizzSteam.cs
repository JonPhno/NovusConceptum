using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class BlizzSteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Blizzard",
                table: "AspNetUserInfoSup",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Steam",
                table: "AspNetUserInfoSup",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blizzard",
                table: "AspNetUserInfoSup");

            migrationBuilder.DropColumn(
                name: "Steam",
                table: "AspNetUserInfoSup");
        }
    }
}
