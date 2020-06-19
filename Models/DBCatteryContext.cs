using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cats
{
    public partial class DBCatteryContext : DbContext
    {
        public DBCatteryContext()
        {
        }

        public DBCatteryContext(DbContextOptions<DBCatteryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Breed> Breed { get; set; }
        public virtual DbSet<Cat> Cat { get; set; }
        public virtual DbSet<CatTemper> CatTemper { get; set; }
        public virtual DbSet<Cattery> Cattery { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Temper> Temper { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-T7TBBKL; Database=DBCattery; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>(entity =>
            {
                entity.Property(e => e.Info).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Breed)
                    .WithMany(p => p.Cat)
                    .HasForeignKey(d => d.BreedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_Breed");

                entity.HasOne(d => d.Cattery)
                    .WithMany(p => p.Cat)
                    .HasForeignKey(d => d.CatteryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_Cattery");
            });

            modelBuilder.Entity<CatTemper>(entity =>
            {
                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.CatTemper)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatTemper_Cat");

                entity.HasOne(d => d.Temper)
                    .WithMany(p => p.CatTemper)
                    .HasForeignKey(d => d.TemperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatTemper_Temper");
            });

            modelBuilder.Entity<Cattery>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Cattery)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cattery_City");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Temper>(entity =>
            {
                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
