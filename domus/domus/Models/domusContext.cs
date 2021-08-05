using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace domus.Models
{
    public partial class domusContext : DbContext
    {
        public domusContext()
        {
        }

        public domusContext(DbContextOptions<domusContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Dogadjaj> Dogadjaji { get; set; }
        public virtual DbSet<Dom> Domovi { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }
        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<Oglas> Oglasi { get; set; }
        public virtual DbSet<Sudionik> Sudionici { get; set; }
        public virtual DbSet<TipDogadjaja> TipoviDogadjaja { get; set; }
        public virtual DbSet<TipKorisnika> TipoviKorisnika { get; set; }
        public virtual DbSet<TipOglasa> TipoviOglasa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=domusDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Dogadjaj>(entity =>
            {
                entity.ToTable("dogadjaj");

                entity.Property(e => e.DogadjajId).HasColumnName("dogadjaj_id");

                entity.Property(e => e.BrojSudionika).HasColumnName("broj_sudionika");

                entity.Property(e => e.DomId).HasColumnName("dom_id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("naziv");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis");

                entity.Property(e => e.TipDogadjajaId).HasColumnName("tip_dogadjaja_id");

                entity.Property(e => e.VrijemePocetka)
                    .HasColumnType("datetime")
                    .HasColumnName("vrijeme_pocetka");

                entity.Property(e => e.VrijemeZavrsetka)
                    .HasColumnType("datetime")
                    .HasColumnName("vrijeme_zavrsetka");

                entity.HasOne(d => d.Dom)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.DomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dogadjaj_dom");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dogadjaj_korisnik");

                entity.HasOne(d => d.TipDogadjaja)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.TipDogadjajaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dogadjaj_tip_dogadjaja");
            });

            modelBuilder.Entity<Dom>(entity =>
            {
                entity.ToTable("dom");

                entity.Property(e => e.DomId).HasColumnName("dom_id");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("naziv");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Doms)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dom_grad");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("grad");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.DomId).HasColumnName("dom_id");

                entity.Property(e => e.EPosta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("e-posta");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.LozinkaSha256)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("lozinka_sha256")
                    .IsFixedLength(true);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prezime");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("salt")
                    .IsFixedLength(true);

                entity.Property(e => e.TipKorisnikaId).HasColumnName("tip_korisnika_id");

                entity.Property(e => e.Zakljucan).HasColumnName("zakljucan");

                entity.HasOne(d => d.Dom)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.DomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_korisnik_dom");

                entity.HasOne(d => d.TipKorisnika)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.TipKorisnikaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_korisnik_tip_korisnika");
            });

            modelBuilder.Entity<Oglas>(entity =>
            {
                entity.HasKey(e => e.OglasId);

                entity.ToTable("oglas");

                entity.Property(e => e.OglasId).HasColumnName("oglas_id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("naziv");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis");

                entity.Property(e => e.TipOglasaId).HasColumnName("tip_oglasa_id");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Oglas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_oglas_korisnik");

                entity.HasOne(d => d.TipOglasa)
                    .WithMany(p => p.Oglas)
                    .HasForeignKey(d => d.TipOglasaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_oglas_tip_oglasa");
            });

            modelBuilder.Entity<Sudionik>(entity =>
            {
                entity.HasKey(e => new { e.DogadjajId, e.KorisnikId });

                entity.ToTable("sudionik");

                entity.Property(e => e.DogadjajId).HasColumnName("dogadjaj_id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Obrazlozenje).HasColumnName("obrazlozenje");

                entity.Property(e => e.Odbijen).HasColumnName("odbijen");

                entity.Property(e => e.Potvrdjen).HasColumnName("potvrdjen");

                entity.HasOne(d => d.Dogadjaj)
                    .WithMany(p => p.Sudioniks)
                    .HasForeignKey(d => d.DogadjajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sudionik_dogadjaj");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Sudioniks)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sudionik_korisnik");
            });

            modelBuilder.Entity<TipDogadjaja>(entity =>
            {
                entity.ToTable("tip_dogadjaja");

                entity.Property(e => e.TipDogadjajaId).HasColumnName("tip_dogadjaja_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<TipKorisnika>(entity =>
            {
                entity.ToTable("tip_korisnika");

                entity.Property(e => e.TipKorisnikaId).HasColumnName("tip_korisnika_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("naziv");

                entity.Property(e => e.RazinaAutorizacije).HasColumnName("razina_autorizacije");
            });

            modelBuilder.Entity<TipOglasa>(entity =>
            {
                entity.ToTable("tip_oglasa");

                entity.Property(e => e.TipOglasaId).HasColumnName("tip_oglasa_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("naziv");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
