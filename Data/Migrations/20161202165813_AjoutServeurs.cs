using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NovusConceptum.Data.Migrations
{
    public partial class AjoutServeurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serveurs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Joueurs = table.Column<int>(nullable: false),
                    JoueursMax = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Ouvert = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serveurs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serveurs_AspNetUserInfoSup_AdminID",
                        column: x => x.AdminID,
                        principalTable: "AspNetUserInfoSup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serveurs_AdminID",
                table: "Serveurs",
                column: "AdminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serveurs");
        }
    }
}
