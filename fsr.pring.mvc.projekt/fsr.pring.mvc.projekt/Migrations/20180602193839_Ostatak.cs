using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Migrations
{
    public partial class Ostatak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GPS",
                table: "LokacijaTip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kategorizacija",
                table: "LokacijaTip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Koordinate",
                table: "LokacijaTip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "LokacijaTip",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "JediniceMjere",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "ArtikliTip",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPS",
                table: "LokacijaTip");

            migrationBuilder.DropColumn(
                name: "Kategorizacija",
                table: "LokacijaTip");

            migrationBuilder.DropColumn(
                name: "Koordinate",
                table: "LokacijaTip");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "LokacijaTip");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "JediniceMjere");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "ArtikliTip");
        }
    }
}
