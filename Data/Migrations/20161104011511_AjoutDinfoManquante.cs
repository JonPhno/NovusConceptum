using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class AjoutDinfoManquante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspNetUserInfoSupID",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AspNetUserInfoSupID",
                table: "AspNetRoles",
                column: "AspNetUserInfoSupID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUserInfoSup_AspNetUserInfoSupID",
                table: "AspNetRoles",
                column: "AspNetUserInfoSupID",
                principalTable: "AspNetUserInfoSup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUserInfoSup_AspNetUserInfoSupID",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AspNetUserInfoSupID",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AspNetUserInfoSupID",
                table: "AspNetRoles");
        }
    }
}
