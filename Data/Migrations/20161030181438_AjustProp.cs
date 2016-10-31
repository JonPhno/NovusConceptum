using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class AjustProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auteur",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "DateCréation",
                table: "Sujets");

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Sujets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Sujets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "NombreMessages",
                table: "Sujets",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Sujets_AuteurId",
                table: "Sujets",
                column: "AuteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sujets_AspNetUsers_AuteurId",
                table: "Sujets",
                column: "AuteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sujets_AspNetUsers_AuteurId",
                table: "Sujets");

            migrationBuilder.DropIndex(
                name: "IX_Sujets_AuteurId",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Sujets");

            migrationBuilder.AddColumn<string>(
                name: "Auteur",
                table: "Sujets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCréation",
                table: "Sujets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "NombreMessages",
                table: "Sujets",
                nullable: true);
        }
    }
}
