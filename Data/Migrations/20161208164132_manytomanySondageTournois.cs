using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NovusConceptum.Data.Migrations
{
    public partial class manytomanySondageTournois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sondages_SondageID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tournois_TournoisID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SondageID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TournoisID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SondageID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TournoisID",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AspNetUsersSondages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SondageId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsersSondages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsersSondages_Sondages_SondageId",
                        column: x => x.SondageId,
                        principalTable: "Sondages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsersSondages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsersTournois",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TournoisId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsersTournois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsersTournois_Tournois_TournoisId",
                        column: x => x.TournoisId,
                        principalTable: "Tournois",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsersTournois_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tournois",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sondages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournois_ApplicationUserId",
                table: "Tournois",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sondages_ApplicationUserId",
                table: "Sondages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsersSondages_SondageId",
                table: "AspNetUsersSondages",
                column: "SondageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsersSondages_UserId",
                table: "AspNetUsersSondages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsersTournois_TournoisId",
                table: "AspNetUsersTournois",
                column: "TournoisId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsersTournois_UserId",
                table: "AspNetUsersTournois",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sondages_AspNetUsers_ApplicationUserId",
                table: "Sondages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournois_AspNetUsers_ApplicationUserId",
                table: "Tournois",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sondages_AspNetUsers_ApplicationUserId",
                table: "Sondages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournois_AspNetUsers_ApplicationUserId",
                table: "Tournois");

            migrationBuilder.DropIndex(
                name: "IX_Tournois_ApplicationUserId",
                table: "Tournois");

            migrationBuilder.DropIndex(
                name: "IX_Sondages_ApplicationUserId",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tournois");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sondages");

            migrationBuilder.DropTable(
                name: "AspNetUsersSondages");

            migrationBuilder.DropTable(
                name: "AspNetUsersTournois");

            migrationBuilder.AddColumn<int>(
                name: "SondageID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournoisID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SondageID",
                table: "AspNetUsers",
                column: "SondageID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TournoisID",
                table: "AspNetUsers",
                column: "TournoisID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sondages_SondageID",
                table: "AspNetUsers",
                column: "SondageID",
                principalTable: "Sondages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tournois_TournoisID",
                table: "AspNetUsers",
                column: "TournoisID",
                principalTable: "Tournois",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
