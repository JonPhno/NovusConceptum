using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class modifAuteur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auteur",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "Dernier",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "Auteur",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Sujets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DernierId",
                table: "Sujets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sujets_AuteurId",
                table: "Sujets",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Sujets_DernierId",
                table: "Sujets",
                column: "DernierId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuteurId",
                table: "Posts",
                column: "AuteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuteurId",
                table: "Posts",
                column: "AuteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sujets_AspNetUsers_AuteurId",
                table: "Sujets",
                column: "AuteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sujets_AspNetUsers_DernierId",
                table: "Sujets",
                column: "DernierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuteurId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sujets_AspNetUsers_AuteurId",
                table: "Sujets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sujets_AspNetUsers_DernierId",
                table: "Sujets");

            migrationBuilder.DropIndex(
                name: "IX_Sujets_AuteurId",
                table: "Sujets");

            migrationBuilder.DropIndex(
                name: "IX_Sujets_DernierId",
                table: "Sujets");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuteurId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "DernierId",
                table: "Sujets");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Auteur",
                table: "Sujets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dernier",
                table: "Sujets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Auteur",
                table: "Posts",
                nullable: true);
        }
    }
}
