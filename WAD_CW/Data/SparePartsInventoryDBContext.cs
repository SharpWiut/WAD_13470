using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SPI.Models;

namespace SPI.Data
{
    public class SparePartsInventoryDBContext : DbContext
    {
        public SparePartsInventoryDBContext(DbContextOptions options) : base(options)
        {
        }

        protected SparePartsInventoryDBContext()
        {}

        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }




        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
