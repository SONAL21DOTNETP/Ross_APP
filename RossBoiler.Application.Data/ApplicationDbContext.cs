using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<HSN> HSNs { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Packing> Packings { get; set; }

        public DbSet<Boiler> Boilers { get; set; }
        public DbSet<BoilerSeries> BoilerSeries { get; set; }
        public DbSet<BoilerSeriesPartsMapping> BoilerSeriesPartsMappings { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        
        public DbSet<CustomerPricing> CustomerPricings { get; set; }
        public DbSet<GST> GSTs { get; set; }
        public DbSet<Parts> Parts { get; set; }
    }
}
