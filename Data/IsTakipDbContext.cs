using System.Data.Entity;
using IsTakipSistemi.Models;

namespace IsTakipSistemi.Data
{
    public class IsTakipDbContext : DbContext
    {
        public IsTakipDbContext() : base("name=IsTakipDB")
        {
            Database.SetInitializer<IsTakipDbContext>(null);
        }

        public DbSet<Birimler> Birimler { get; set; }
        public DbSet<Durumlar> Durumlar { get; set; }
        public DbSet<Personeller> Personeller { get; set; }
        public DbSet<YetkiTurler> YetkiTurler { get; set; }
        public DbSet<Isler> Isler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Birimler
            modelBuilder.Entity<Birimler>()
                .HasKey(e => e.BirimId);

            // YetkiTurler
            modelBuilder.Entity<YetkiTurler>()
                .HasKey(e => e.YetkiTurId);

            // Durumlar
            modelBuilder.Entity<Durumlar>()
                .HasKey(e => e.DurumId);

            // Personeller
            modelBuilder.Entity<Personeller>()
                .HasKey(e => e.PersonelId);

            modelBuilder.Entity<Personeller>()
                .HasOptional(e => e.Birim)
                .WithMany(e => e.Personeller)
                .HasForeignKey(e => e.PersonelBirimId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personeller>()
                .HasOptional(e => e.YetkiTur)
                .WithMany(e => e.Personeller)
                .HasForeignKey(e => e.PersonelYetkiTurId)
                .WillCascadeOnDelete(false);

            // Isler
            modelBuilder.Entity<Isler>()
                .HasKey(e => e.IsId);

            modelBuilder.Entity<Isler>()
                .HasOptional(e => e.Personel)
                .WithMany(e => e.Isler)
                .HasForeignKey(e => e.IsPersonelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Isler>()
                .HasOptional(e => e.Durum)
                .WithMany(e => e.Isler)
                .HasForeignKey(e => e.IsDurumId)
                .WillCascadeOnDelete(false);
        }
    }
}
