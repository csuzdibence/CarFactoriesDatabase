using CarFactories.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactories.Database
{
    public class CarFactoriesDbContext : DbContext
    {
        // Egy-egy táblát reprezentál
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Headquarter> Headquarters { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<CarPart> CarParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // N-N kapcsolat konfigurálása
            modelBuilder.Entity<CarPart>()
                .HasKey(cp => new { cp.CarModelId, cp.PartId });

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.CarModel)
                .WithMany(c => c.CarParts)
                .HasForeignKey(cp => cp.CarModelId);

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.Part)
                .WithMany(p => p.CarParts)
                .HasForeignKey(cp => cp.PartId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string beállítás
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarFactories");
        }
    }
}
