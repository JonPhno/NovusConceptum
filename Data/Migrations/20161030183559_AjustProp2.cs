using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class AjustProp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Auteur",
                table: "Sujets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auteur",
                table: "Sujets");

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Sujets",
                nullable: true);

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
    }
}
