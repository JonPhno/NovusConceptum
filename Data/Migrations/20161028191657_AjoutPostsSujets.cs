using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NovusConceptum.Data.Migrations
{
    public partial class AjoutPostsSujets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Sujets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auteur = table.Column<string>(nullable: true),
                    DateCréation = table.Column<DateTime>(nullable: false),
                    DateModifier = table.Column<DateTime>(nullable: false),
                    Dernier = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NombreMessages = table.Column<string>(nullable: true),
                    Titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sujets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auteur = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    SujetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Sujets_SujetID",
                        column: x => x.SujetID,
                        principalTable: "Sujets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SujetID",
                table: "Posts",
                column: "SujetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Sujets");

            migrationBuilder.CreateTable(
                name: "Dicussions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auteur = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicussions", x => x.ID);
                });
        }
    }
}
