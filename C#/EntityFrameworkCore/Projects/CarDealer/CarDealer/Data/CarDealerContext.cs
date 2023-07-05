using Microsoft.EntityFrameworkCore;
using CarDealer.Models;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }
      
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartsCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>(e =>
            {
                e.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Supplier>(e =>
            {
                e.HasMany(s => s.Parts)
                 .WithOne(sup => sup.Supplier)
                 .HasForeignKey(sup => sup.SupplierId);
            });

            modelBuilder.Entity<PartCar>(e =>
            {
                e.HasKey(k => new { k.CarId, k.PartId });

                e.HasOne(e => e.Car)
                 .WithMany(c => c.PartsCars)
                 .HasForeignKey(e => e.CarId);

                e.HasOne(e => e.Part)
                 .WithMany(p => p.PartsCars)
                 .HasForeignKey(e => e.PartId);
            });
        }
    }
}
