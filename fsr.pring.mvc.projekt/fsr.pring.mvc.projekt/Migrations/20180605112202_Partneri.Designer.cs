﻿// <auto-generated />
using fsr.pring.mvc.projekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace fsr.pring.mvc.projekt.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180605112202_Partneri")]
    partial class Partneri
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Artikli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtikliGrupaId");

                    b.Property<int?>("ArtikliTipId");

                    b.Property<decimal?>("Cijena")
                        .HasColumnType("money");

                    b.Property<int?>("JedinicaMjereId");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50);

                    b.Property<string>("Oznaka")
                        .HasMaxLength(50);

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ArtikliGrupaId");

                    b.HasIndex("ArtikliTipId");

                    b.HasIndex("JedinicaMjereId");

                    b.ToTable("Artikli");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.ArtikliGrupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtikliTipId");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ArtikliTipId");

                    b.ToTable("ArtikliGrupe");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.ArtikliTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("ArtikliTip");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Dokumeti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojDokumenta")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int?>("DobavljacId");

                    b.Property<int?>("DokumentTipId");

                    b.Property<int?>("KupacId");

                    b.Property<int?>("LoakcijaId");

                    b.HasKey("Id");

                    b.HasIndex("DobavljacId");

                    b.HasIndex("DokumentTipId");

                    b.HasIndex("KupacId");

                    b.HasIndex("LoakcijaId");

                    b.ToTable("Dokumeti");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.DukumentTipovi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("DukumentTipovi");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.JediniceMjere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("JediniceMjere");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.LokacijaTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GPS");

                    b.Property<string>("Kategorizacija");

                    b.Property<int>("Koordinate");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("LokacijaTip");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Lokacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LokacijaTipId");

                    b.Property<int?>("PartnerId");

                    b.HasKey("Id");

                    b.HasIndex("LokacijaTipId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Lokacije");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Mobitel");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50);

                    b.Property<int?>("PartnerTipoviId");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("PartnerTipoviId");

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.PartnerTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("TipPartera");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Stavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtiklId");

                    b.Property<decimal?>("Cijena")
                        .HasColumnType("money");

                    b.Property<int?>("DokumentId");

                    b.Property<double?>("Kolicina");

                    b.Property<int?>("ZivotinjaId");

                    b.HasKey("Id");

                    b.HasIndex("ArtiklId");

                    b.HasIndex("DokumentId");

                    b.HasIndex("ZivotinjaId");

                    b.ToTable("Stavke");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.StavkeSastavnice", b =>
                {
                    b.Property<int>("SastavnicaId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtiklId");

                    b.Property<double?>("Kolicina");

                    b.HasKey("SastavnicaId");

                    b.HasIndex("ArtiklId");

                    b.ToTable("StavkeSastavnice");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Artikli", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.ArtikliGrupe", "ArtikliGrupa")
                        .WithMany("Artikli")
                        .HasForeignKey("ArtikliGrupaId")
                        .HasConstraintName("FK_Artikli_ArtikliGrupe");

                    b.HasOne("fsr.pring.mvc.projekt.Models.ArtikliTip", "ArtikliTip")
                        .WithMany("Artikli")
                        .HasForeignKey("ArtikliTipId")
                        .HasConstraintName("FK_Artikli_ArtikliTip");

                    b.HasOne("fsr.pring.mvc.projekt.Models.JediniceMjere", "JedinicaMjere")
                        .WithMany("Artikli")
                        .HasForeignKey("JedinicaMjereId")
                        .HasConstraintName("FK_Artikli_JediniceMjere");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.ArtikliGrupe", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.ArtikliTip", "ArtikliTip")
                        .WithMany("ArtikliGrupe")
                        .HasForeignKey("ArtikliTipId")
                        .HasConstraintName("FK_ArtikliGrupe_ArtikliTip");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Dokumeti", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.Partner", "Dobavljac")
                        .WithMany("DokumetiDobavljac")
                        .HasForeignKey("DobavljacId")
                        .HasConstraintName("FK_Dokumeti_Partner1");

                    b.HasOne("fsr.pring.mvc.projekt.Models.DukumentTipovi", "DokumentTip")
                        .WithMany("Dokumeti")
                        .HasForeignKey("DokumentTipId")
                        .HasConstraintName("FK_Dokumeti_DukumentTipovi");

                    b.HasOne("fsr.pring.mvc.projekt.Models.Partner", "Kupac")
                        .WithMany("DokumetiKupac")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_Dokumeti_Partner");

                    b.HasOne("fsr.pring.mvc.projekt.Models.Lokacije", "Loakcija")
                        .WithMany("Dokumeti")
                        .HasForeignKey("LoakcijaId")
                        .HasConstraintName("FK_Dokumeti_Lokacije");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Lokacije", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.LokacijaTip", "LokacijaTip")
                        .WithMany("Lokacije")
                        .HasForeignKey("LokacijaTipId")
                        .HasConstraintName("FK_Lokacije_LokacijaTip");

                    b.HasOne("fsr.pring.mvc.projekt.Models.Partner", "Partner")
                        .WithMany("Lokacije")
                        .HasForeignKey("PartnerId")
                        .HasConstraintName("FK_Lokacije_Partner");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Partner", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.PartnerTip", "PartnerTipovi")
                        .WithMany("Partner")
                        .HasForeignKey("PartnerTipoviId")
                        .HasConstraintName("FK_Partner_TipPartera");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.Stavke", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.Artikli", "Artikl")
                        .WithMany("StavkeArtikl")
                        .HasForeignKey("ArtiklId")
                        .HasConstraintName("FK_Stavke_Artikli");

                    b.HasOne("fsr.pring.mvc.projekt.Models.Dokumeti", "Dokument")
                        .WithMany("Stavke")
                        .HasForeignKey("DokumentId")
                        .HasConstraintName("FK_Stavke_Dokumeti");

                    b.HasOne("fsr.pring.mvc.projekt.Models.Artikli", "Zivotinja")
                        .WithMany("StavkeZivotinja")
                        .HasForeignKey("ZivotinjaId")
                        .HasConstraintName("FK_Stavke_Artikli1");
                });

            modelBuilder.Entity("fsr.pring.mvc.projekt.Models.StavkeSastavnice", b =>
                {
                    b.HasOne("fsr.pring.mvc.projekt.Models.Artikli", "Artikl")
                        .WithMany("StavkeSastavniceArtikl")
                        .HasForeignKey("ArtiklId")
                        .HasConstraintName("FK_StavkeSastavnice_Artikli");

                    b.HasOne("fsr.pring.mvc.projekt.Models.Artikli", "Sastavnica")
                        .WithOne("StavkeSastavniceSastavnica")
                        .HasForeignKey("fsr.pring.mvc.projekt.Models.StavkeSastavnice", "SastavnicaId")
                        .HasConstraintName("FK_StavkeSastavnice_Artikli1");
                });
#pragma warning restore 612, 618
        }
    }
}
