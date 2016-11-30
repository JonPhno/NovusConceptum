using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NovusConceptum.Data.Migrations
{
    public partial class Sondages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sondages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Choix = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Options = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sondages", x => x.ID);
                });

            migrationBuilder.AddColumn<int>(
                name: "SondageID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SondageID",
                table: "AspNetUsers",
                column: "SondageID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sondages_SondageID",
                table: "AspNetUsers",
                column: "SondageID",
                principalTable: "Sondages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sondages_SondageID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SondageID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SondageID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sondages");
        }
    }
}
