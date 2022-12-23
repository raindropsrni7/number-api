using Microsoft.EntityFrameworkCore;
using NumberApp.Models;

namespace NumberApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NumItem> Numbers => Set<NumItem>();
    }
}