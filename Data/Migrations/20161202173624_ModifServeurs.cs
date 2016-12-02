using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class ModifServeurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdresseIp",
                table: "Serveurs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Serveurs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresseIp",
                table: "Serveurs");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Serveurs");
        }
    }
}
