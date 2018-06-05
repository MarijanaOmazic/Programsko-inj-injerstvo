using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtikliTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikliTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DukumentTipovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DukumentTipovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JediniceMjere",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JediniceMjere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LokacijaTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokacijaTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipPartera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPartera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtikliGrupe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtikliTipId = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikliGrupe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtikliGrupe_ArtikliTip",
                        column: x => x.ArtikliTipId,
                        principalTable: "ArtikliTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true),
                    PartnerTipoviId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partner_TipPartera",
                        column: x => x.PartnerTipoviId,
                        principalTable: "TipPartera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artikli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtikliGrupaId = table.Column<int>(nullable: true),
                    ArtikliTipId = table.Column<int>(nullable: true),
                    Cijena = table.Column<decimal>(type: "money", nullable: true),
                    JedinicaMjereId = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true),
                    Oznaka = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artikli_ArtikliGrupe",
                        column: x => x.ArtikliGrupaId,
                        principalTable: "ArtikliGrupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artikli_ArtikliTip",
                        column: x => x.ArtikliTipId,
                        principalTable: "ArtikliTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artikli_JediniceMjere",
                        column: x => x.JedinicaMjereId,
                        principalTable: "JediniceMjere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LokacijaTipId = table.Column<int>(nullable: true),
                    PartnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lokacije_LokacijaTip",
                        column: x => x.LokacijaTipId,
                        principalTable: "LokacijaTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lokacije_Partner",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StavkeSastavnice",
                columns: table => new
                {
                    SastavnicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtiklId = table.Column<int>(nullable: true),
                    Kolicina = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeSastavnice", x => x.SastavnicaId);
                    table.ForeignKey(
                        name: "FK_StavkeSastavnice_Artikli",
                        column: x => x.ArtiklId,
                        principalTable: "Artikli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StavkeSastavnice_Artikli1",
                        column: x => x.SastavnicaId,
                        principalTable: "Artikli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dokumeti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojDokumenta = table.Column<string>(maxLength: 50, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    DobavljacId = table.Column<int>(nullable: true),
                    DokumentTipId = table.Column<int>(nullable: true),
                    KupacId = table.Column<int>(nullable: true),
                    LoakcijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumeti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dokumeti_Partner1",
                        column: x => x.DobavljacId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokumeti_DukumentTipovi",
                        column: x => x.DokumentTipId,
                        principalTable: "DukumentTipovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokumeti_Partner",
                        column: x => x.KupacId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokumeti_Lokacije",
                        column: x => x.LoakcijaId,
                        principalTable: "Lokacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtiklId = table.Column<int>(nullable: true),
                    Cijena = table.Column<decimal>(type: "money", nullable: true),
                    DokumentId = table.Column<int>(nullable: true),
                    Kolicina = table.Column<double>(nullable: true),
                    ZivotinjaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stavke_Artikli",
                        column: x => x.ArtiklId,
                        principalTable: "Artikli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stavke_Dokumeti",
                        column: x => x.DokumentId,
                        principalTable: "Dokumeti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stavke_Artikli1",
                        column: x => x.ZivotinjaId,
                        principalTable: "Artikli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikli_ArtikliGrupaId",
                table: "Artikli",
                column: "ArtikliGrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artikli_ArtikliTipId",
                table: "Artikli",
                column: "ArtikliTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Artikli_JedinicaMjereId",
                table: "Artikli",
                column: "JedinicaMjereId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtikliGrupe_ArtikliTipId",
                table: "ArtikliGrupe",
                column: "ArtikliTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumeti_DobavljacId",
                table: "Dokumeti",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumeti_DokumentTipId",
                table: "Dokumeti",
                column: "DokumentTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumeti_KupacId",
                table: "Dokumeti",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumeti_LoakcijaId",
                table: "Dokumeti",
                column: "LoakcijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_LokacijaTipId",
                table: "Lokacije",
                column: "LokacijaTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_PartnerId",
                table: "Lokacije",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_PartnerTipoviId",
                table: "Partner",
                column: "PartnerTipoviId");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_ArtiklId",
                table: "Stavke",
                column: "ArtiklId");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_DokumentId",
                table: "Stavke",
                column: "DokumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_ZivotinjaId",
                table: "Stavke",
                column: "ZivotinjaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeSastavnice_ArtiklId",
                table: "StavkeSastavnice",
                column: "ArtiklId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stavke");

            migrationBuilder.DropTable(
                name: "StavkeSastavnice");

            migrationBuilder.DropTable(
                name: "Dokumeti");

            migrationBuilder.DropTable(
                name: "Artikli");

            migrationBuilder.DropTable(
                name: "DukumentTipovi");

            migrationBuilder.DropTable(
                name: "Lokacije");

            migrationBuilder.DropTable(
                name: "ArtikliGrupe");

            migrationBuilder.DropTable(
                name: "JediniceMjere");

            migrationBuilder.DropTable(
                name: "LokacijaTip");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "ArtikliTip");

            migrationBuilder.DropTable(
                name: "TipPartera");
        }
    }
}
