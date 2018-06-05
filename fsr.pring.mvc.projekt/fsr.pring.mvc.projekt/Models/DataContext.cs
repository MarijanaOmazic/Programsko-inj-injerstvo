using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class DataContext : DbContext
    {
       
        

        public virtual DbSet<Artikli> Artikli { get; set; }
        public virtual DbSet<ArtikliGrupe> ArtikliGrupe { get; set; }
        public virtual DbSet<ArtikliTip> ArtikliTip { get; set; }
        public virtual DbSet<Dokumeti> Dokumeti { get; set; }
        public virtual DbSet<DukumentTipovi> DukumentTipovi { get; set; }
        public virtual DbSet<JediniceMjere> JediniceMjere { get; set; }
        public virtual DbSet<LokacijaTip> LokacijaTip { get; set; }
        public virtual DbSet<LokacijaKategorija> LokacijaKategorija { get; set; }
        public virtual DbSet<Lokacije> Lokacije { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Stavke> Stavke { get; set; }
        public virtual DbSet<StavkeSastavnice> StavkeSastavnice { get; set; }
        public virtual DbSet<PartnerTip> TipPartera { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikli>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();

                entity.Property(e => e.Cijena).HasColumnType("money");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Oznaka).HasMaxLength(50);

                entity.HasOne(d => d.ArtikliGrupa)
                    .WithMany(p => p.Artikli)
                    .HasForeignKey(d => d.ArtikliGrupaId)
                    .HasConstraintName("FK_Artikli_ArtikliGrupe");

                entity.HasOne(d => d.ArtikliTip)
                    .WithMany(p => p.Artikli)
                    .HasForeignKey(d => d.ArtikliTipId)
                    .HasConstraintName("FK_Artikli_ArtikliTip");

                entity.HasOne(d => d.JedinicaMjere)
                    .WithMany(p => p.Artikli)
                    .HasForeignKey(d => d.JedinicaMjereId)
                    .HasConstraintName("FK_Artikli_JediniceMjere");
            });

            modelBuilder.Entity<ArtikliGrupe>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.HasOne(d => d.ArtikliTip)
                    .WithMany(p => p.ArtikliGrupe)
                    .HasForeignKey(d => d.ArtikliTipId)
                    .HasConstraintName("FK_ArtikliGrupe_ArtikliTip");
            });

            modelBuilder.Entity<ArtikliTip>(entity =>
            {
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();
            });

            modelBuilder.Entity<Dokumeti>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();

                entity.Property(e => e.BrojDokumenta).HasMaxLength(50);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.DokumetiDobavljac)
                    .HasForeignKey(d => d.DobavljacId)
                    .HasConstraintName("FK_Dokumeti_Partner1");

                entity.HasOne(d => d.DokumentTip)
                    .WithMany(p => p.Dokumeti)
                    .HasForeignKey(d => d.DokumentTipId)
                    .HasConstraintName("FK_Dokumeti_DukumentTipovi");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.DokumetiKupac)
                    .HasForeignKey(d => d.KupacId)
                    .HasConstraintName("FK_Dokumeti_Partner");

                entity.HasOne(d => d.Loakcija)
                    .WithMany(p => p.Dokumeti)
                    .HasForeignKey(d => d.LoakcijaId)
                    .HasConstraintName("FK_Dokumeti_Lokacije");
            });

            modelBuilder.Entity<DukumentTipovi>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();
            });

            modelBuilder.Entity<JediniceMjere>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();
            });

            modelBuilder.Entity<LokacijaTip>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();
            });
            modelBuilder.Entity<LokacijaKategorija>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();
            });

            modelBuilder.Entity<Lokacije>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();

                entity.HasOne(d => d.LokacijaTip)
                    .WithMany(p => p.Lokacije)
                    .HasForeignKey(d => d.LokacijaTipId)
                    .HasConstraintName("FK_Lokacije_LokacijaTip");

                entity.HasOne(d => d.LokacijaKategorija)
                    .WithMany(p => p.Lokacije)
                    .HasForeignKey(d => d.LokacijaTipId)
                    .HasConstraintName("FK_Lokacije_LokacijaKategorija");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Lokacije)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_Lokacije_Partner");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.HasOne(d => d.PartnerTipovi)
                    .WithMany(p => p.Partner)
                    .HasForeignKey(d => d.PartnerTipoviId)
                    .HasConstraintName("FK_Partner_TipPartera");
            });

            modelBuilder.Entity<Stavke>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();

                entity.Property(e => e.Cijena).HasColumnType("money");

                entity.HasOne(d => d.Artikl)
                    .WithMany(p => p.StavkeArtikl)
                    .HasForeignKey(d => d.ArtiklId)
                    .HasConstraintName("FK_Stavke_Artikli");

                entity.HasOne(d => d.Dokument)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.DokumentId)
                    .HasConstraintName("FK_Stavke_Dokumeti");

                entity.HasOne(d => d.Zivotinja)
                    .WithMany(p => p.StavkeZivotinja)
                    .HasForeignKey(d => d.ZivotinjaId)
                    .HasConstraintName("FK_Stavke_Artikli1");
            });

            modelBuilder.Entity<StavkeSastavnice>(entity =>
            {
                entity.HasKey(e => e.SastavnicaId);

                entity.Property(e => e.SastavnicaId).UseSqlServerIdentityColumn();

                entity.HasOne(d => d.Artikl)
                    .WithMany(p => p.StavkeSastavniceArtikl)
                    .HasForeignKey(d => d.ArtiklId)
                    .HasConstraintName("FK_StavkeSastavnice_Artikli");

                entity.HasOne(d => d.Sastavnica)
                    .WithOne(p => p.StavkeSastavniceSastavnica)
                    .HasForeignKey<StavkeSastavnice>(d => d.SastavnicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StavkeSastavnice_Artikli1");
            });

            modelBuilder.Entity<PartnerTip>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseSqlServerIdentityColumn();
            });
        }

        
    }
}
