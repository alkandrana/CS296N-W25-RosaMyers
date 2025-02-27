using OnTolkien.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace OnTolkien.Data

{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Topic> Topics { get; set; }


    }
}
