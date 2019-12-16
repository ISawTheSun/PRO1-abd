using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restauracja.Models
{
    public partial class s17187Context : DbContext
    {
        public s17187Context()
        {
        }

        public s17187Context(DbContextOptions<s17187Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<ListaSkladnikow> ListaSkladnikow { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<ProduktZamowienie> ProduktZamowienie { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<PromocjaProdukt> PromocjaProdukt { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17187;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.HasKey(e => e.IdProduktu)
                    .HasName("Dodatek_pk");

                entity.Property(e => e.IdProduktu)
                    .HasColumnName("idProduktu")
                    .ValueGeneratedNever();

                entity.Property(e => e.RodzajDodatku)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithOne(p => p.Dodatek)
                    .HasForeignKey<Dodatek>(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_Produkt");
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.OsobaIdOsoba)
                    .HasName("Dostawca_pk");

                entity.Property(e => e.OsobaIdOsoba)
                    .HasColumnName("Osoba_idOsoba")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithOne(p => p.Dostawca)
                    .HasForeignKey<Dostawca>(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dostawca_Osoba");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.OsobaIdOsoba)
                    .HasName("Klient_pk");

                entity.Property(e => e.OsobaIdOsoba)
                    .HasColumnName("Osoba_idOsoba")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithOne(p => p.Klient)
                    .HasForeignKey<Klient>(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Klient_Osoba");
            });

            modelBuilder.Entity<ListaSkladnikow>(entity =>
            {
                entity.HasKey(e => e.IdListySkladniokow)
                    .HasName("Lista_Skladnikow_pk");

                entity.ToTable("Lista_Skladnikow");

                entity.Property(e => e.IdListySkladniokow)
                    .HasColumnName("idListySkladniokow")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdProduktu).HasColumnName("idProduktu");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_idSkladnik");

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.ListaSkladnikow)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lista_Skladnikow_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.ListaSkladnikow)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lista_Skladnikow_Skladnik");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Osoba_pk");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("idOsoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdProduktu)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdProduktu)
                    .HasColumnName("idProduktu")
                    .ValueGeneratedNever();

                entity.Property(e => e.RodzajPizzy)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithOne(p => p.Pizza)
                    .HasForeignKey<Pizza>(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Produkt");
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(e => e.IdProduktu)
                    .HasName("Produkt_pk");

                entity.Property(e => e.IdProduktu)
                    .HasColumnName("idProduktu")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProduktZamowienie>(entity =>
            {
                entity.HasKey(e => e.IdProduktZamowienie)
                    .HasName("Produkt_zamowienie_pk");

                entity.ToTable("Produkt_zamowienie");

                entity.Property(e => e.IdProduktZamowienie).ValueGeneratedNever();

                entity.Property(e => e.IdProduktu).HasColumnName("idProduktu");

                entity.Property(e => e.IdZamowienia).HasColumnName("idZamowienia");

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.ProduktZamowienie)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produkt_zamowienie_Produkt");

                entity.HasOne(d => d.IdZamowieniaNavigation)
                    .WithMany(p => p.ProduktZamowienie)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produkt_zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocji)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocji)
                    .HasColumnName("idPromocji")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PromocjaProdukt>(entity =>
            {
                entity.HasKey(e => e.IdPromocjaProdukt)
                    .HasName("Promocja_produkt_pk");

                entity.ToTable("Promocja_produkt");

                entity.Property(e => e.IdPromocjaProdukt)
                    .HasColumnName("idPromocjaProdukt")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.DataDo).HasColumnType("date");

                entity.Property(e => e.DataOd).HasColumnType("date");

                entity.Property(e => e.IdProduktu).HasColumnName("idProduktu");

                entity.Property(e => e.IdPromocji).HasColumnName("idPromocji");

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.PromocjaProdukt)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_produkt_Produkt");

                entity.HasOne(d => d.IdPromocjiNavigation)
                    .WithMany(p => p.PromocjaProdukt)
                    .HasForeignKey(d => d.IdPromocji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_produkt_Promocja");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("idSkladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia)
                    .HasColumnName("idZamowienia")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("dataZamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.StanZamowienia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.DostawcaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.Dostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dostawca");

                entity.HasOne(d => d.KlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.Klient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");
            });
        }
    }
}
