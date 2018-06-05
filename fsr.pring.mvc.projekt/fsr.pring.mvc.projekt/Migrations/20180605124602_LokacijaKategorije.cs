using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Migrations
{
    public partial class LokacijaKategorije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokacije_Kategorija_KategorijaId",
                table: "Lokacije");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropIndex(
                name: "IX_Lokacije_KategorijaId",
                table: "Lokacije");

            migrationBuilder.RenameColumn(
                name: "KategorijaId",
                table: "Lokacije",
                newName: "LokacijaKategorijaId");

            migrationBuilder.CreateTable(
                name: "LokacijaKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kategorizacija = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokacijaKategorija", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacije_LokacijaKategorija",
                table: "Lokacije",
                column: "LokacijaTipId",
                principalTable: "LokacijaKategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokacije_LokacijaKategorija",
                table: "Lokacije");

            migrationBuilder.DropTable(
                name: "LokacijaKategorija");

            migrationBuilder.RenameColumn(
                name: "LokacijaKategorijaId",
                table: "Lokacije",
                newName: "KategorijaId");

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KategorijaId = table.Column<int>(nullable: true),
                    Kategorizacija = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategorija_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_KategorijaId",
                table: "Lokacije",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorija_KategorijaId",
                table: "Kategorija",
                column: "KategorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacije_Kategorija_KategorijaId",
                table: "Lokacije",
                column: "KategorijaId",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
