using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NovusConceptum.Data.Migrations
{
    public partial class Tournois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournois",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    FinInscriptions = table.Column<DateTime>(nullable: false),
                    Jeu = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    NombreEquipe = table.Column<int>(nullable: false),
                    NombreJoueursEquipe = table.Column<int>(nullable: false),
                    Serveur = table.Column<string>(nullable: true),
                    Spectateurs = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournois", x => x.ID);
                });

            migrationBuilder.AddColumn<int>(
                name: "TournoisID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TournoisID",
                table: "AspNetUsers",
                column: "TournoisID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tournois_TournoisID",
                table: "AspNetUsers",
                column: "TournoisID",
                principalTable: "Tournois",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tournois_TournoisID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TournoisID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TournoisID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tournois");
        }
    }
}
