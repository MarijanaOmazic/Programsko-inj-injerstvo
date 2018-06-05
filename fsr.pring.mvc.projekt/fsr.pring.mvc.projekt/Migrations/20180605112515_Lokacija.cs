using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Migrations
{
    public partial class Lokacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "GPS",
                table: "Lokacije",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Koordinate",
                table: "Lokacije",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPS",
                table: "Lokacije");

            migrationBuilder.DropColumn(
                name: "Koordinate",
                table: "Lokacije");

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
        }
    }
}
