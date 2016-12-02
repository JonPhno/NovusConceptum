using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovusConceptum.Data.Migrations
{
    public partial class ModifServeur2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serveurs_AspNetUserInfoSup_AdminID",
                table: "Serveurs");

            migrationBuilder.AlterColumn<string>(
                name: "AdminID",
                table: "Serveurs",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Serveurs_AspNetUsers_AdminId",
                table: "Serveurs",
                column: "AdminID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Serveurs",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Serveurs_AdminID",
                table: "Serveurs",
                newName: "IX_Serveurs_AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serveurs_AspNetUsers_AdminId",
                table: "Serveurs");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Serveurs",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Serveurs_AspNetUserInfoSup_AdminID",
                table: "Serveurs",
                column: "AdminId",
                principalTable: "AspNetUserInfoSup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Serveurs",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Serveurs_AdminId",
                table: "Serveurs",
                newName: "IX_Serveurs_AdminID");
        }
    }
}
