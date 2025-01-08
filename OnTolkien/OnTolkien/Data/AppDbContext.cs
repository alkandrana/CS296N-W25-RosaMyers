using OnTolkien.Models;
using Microsoft.EntityFrameworkCore;
namespace OnTolkien.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Story> Stories { get; set; }

        public DbSet<AppUser> Users { get; set; }


    }
}
