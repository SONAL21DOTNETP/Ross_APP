using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
