using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizza.Models
{
    public partial class s16800Context : DbContext
    {
        public s16800Context()
        {
        }

        public s16800Context(DbContextOptions<s16800Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CiastoPizza> CiastoPizza { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<DodatekZamówienie> DodatekZamówienie { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Napój> Napój { get; set; }
        public virtual DbSet<NapójZamówienie> NapójZamówienie { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaBaza> PizzaBaza { get; set; }
        public virtual DbSet<PizzaZamówienie> PizzaZamówienie { get; set; }
        public virtual DbSet<Salgrade> Salgrade { get; set; }
        public virtual DbSet<SkładikNaPizzy> SkładikNaPizzy { get; set; }
        public virtual DbSet<Składnik> Składnik { get; set; }
        public virtual DbSet<Zamówienie> Zamówienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16800;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CiastoPizza>(entity =>
            {
                entity.HasKey(e => e.IdCiasto)
                    .HasName("Ciasto_Pizza_pk");

                entity.ToTable("Ciasto_Pizza");

                entity.Property(e => e.IdCiasto)
                    .HasColumnName("Id_ciasto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.HasKey(e => e.IdDodatek)
                    .HasName("Dodatek_pk");

                entity.Property(e => e.IdDodatek)
                    .HasColumnName("Id_dodatek")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DodatekZamówienie>(entity =>
            {
                entity.HasKey(e => new { e.DodatekIdDodatek, e.ZamówienieIdZamówienie })
                    .HasName("Dodatek_zamówienie_pk");

                entity.ToTable("Dodatek_zamówienie");

                entity.Property(e => e.DodatekIdDodatek).HasColumnName("Dodatek_Id_dodatek");

                entity.Property(e => e.ZamówienieIdZamówienie).HasColumnName("Zamówienie_Id_zamówienie");

                entity.HasOne(d => d.DodatekIdDodatekNavigation)
                    .WithMany(p => p.DodatekZamówienie)
                    .HasForeignKey(d => d.DodatekIdDodatek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_zamówienie_Dodatek");

                entity.HasOne(d => d.ZamówienieIdZamówienieNavigation)
                    .WithMany(p => p.DodatekZamówienie)
                    .HasForeignKey(d => d.ZamówienieIdZamówienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_zamówienie_Zamówienie");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE087C2C4E");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient)
                    .HasColumnName("Id_klient")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresDostawy)
                    .IsRequired()
                    .HasColumnName("Adres_dostawy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Napój>(entity =>
            {
                entity.HasKey(e => e.IdNapój)
                    .HasName("Napój_pk");

                entity.Property(e => e.IdNapój)
                    .HasColumnName("Id_napój")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NapójZamówienie>(entity =>
            {
                entity.HasKey(e => new { e.NapójIdNapój, e.ZamówienieIdZamówienie })
                    .HasName("Napój_zamówienie_pk");

                entity.ToTable("Napój_zamówienie");

                entity.Property(e => e.NapójIdNapój).HasColumnName("Napój_Id_napój");

                entity.Property(e => e.ZamówienieIdZamówienie).HasColumnName("Zamówienie_Id_zamówienie");

                entity.HasOne(d => d.NapójIdNapójNavigation)
                    .WithMany(p => p.NapójZamówienie)
                    .HasForeignKey(d => d.NapójIdNapój)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Napój_zamówienie_Napój");

                entity.HasOne(d => d.ZamówienieIdZamówienieNavigation)
                    .WithMany(p => p.NapójZamówienie)
                    .HasForeignKey(d => d.ZamówienieIdZamówienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Napój_zamówienie_Zamówienie");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("Id_pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.CiastoPizzaIdCiasto).HasColumnName("Ciasto_Pizza_Id_ciasto");

                entity.Property(e => e.PizzaBazaIdPizza).HasColumnName("Pizza_baza_Id_pizza");

                entity.HasOne(d => d.CiastoPizzaIdCiastoNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CiastoPizzaIdCiasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ciasto_Pizza");

                entity.HasOne(d => d.PizzaBazaIdPizzaNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.PizzaBazaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Pizza_baza");
            });

            modelBuilder.Entity<PizzaBaza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_baza_pk");

                entity.ToTable("Pizza_baza");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("Id_pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaZamówienie>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.ZamówienieIdZamówienie })
                    .HasName("Pizza_zamówienie_pk");

                entity.ToTable("Pizza_zamówienie");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_pizza");

                entity.Property(e => e.ZamówienieIdZamówienie).HasColumnName("Zamówienie_Id_zamówienie");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaZamówienie)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_zamówienie_Pizza");

                entity.HasOne(d => d.ZamówienieIdZamówienieNavigation)
                    .WithMany(p => p.PizzaZamówienie)
                    .HasForeignKey(d => d.ZamówienieIdZamówienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_zamówienie_Zamówienie");
            });

            modelBuilder.Entity<Salgrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALGRADE");

                entity.Property(e => e.Grade).HasColumnName("GRADE");

                entity.Property(e => e.Hisal).HasColumnName("HISAL");

                entity.Property(e => e.Losal).HasColumnName("LOSAL");
            });

            modelBuilder.Entity<SkładikNaPizzy>(entity =>
            {
                entity.HasKey(e => new { e.SkładnikIdSkładnik, e.PizzaIdPizza })
                    .HasName("Składik_na_pizzy_pk");

                entity.ToTable("Składik_na_pizzy");

                entity.Property(e => e.SkładnikIdSkładnik).HasColumnName("Składnik_Id_składnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_pizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.SkładikNaPizzy)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Składik_na_pizzy_Pizza");

                entity.HasOne(d => d.SkładnikIdSkładnikNavigation)
                    .WithMany(p => p.SkładikNaPizzy)
                    .HasForeignKey(d => d.SkładnikIdSkładnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Składik_na_pizzy_Składnik");
            });

            modelBuilder.Entity<Składnik>(entity =>
            {
                entity.HasKey(e => e.IdSkładnik)
                    .HasName("Składnik_pk");

                entity.Property(e => e.IdSkładnik)
                    .HasColumnName("Id_składnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamówienie>(entity =>
            {
                entity.HasKey(e => e.IdZamówienie)
                    .HasName("Zamówienie_pk");

                entity.Property(e => e.IdZamówienie)
                    .HasColumnName("Id_zamówienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.KlientIdKlient).HasColumnName("Klient_Id_klient");

                entity.HasOne(d => d.KlientIdKlientNavigation)
                    .WithMany(p => p.Zamówienie)
                    .HasForeignKey(d => d.KlientIdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamówienie_Klient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
