using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Migrations
{
    public partial class Partneri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Partner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobitel",
                table: "Partner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Partner",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Partner");

            migrationBuilder.DropColumn(
                name: "Mobitel",
                table: "Partner");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Partner");
        }
    }
}
