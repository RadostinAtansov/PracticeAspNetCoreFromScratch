using Microsoft.EntityFrameworkCore;

namespace PracticeAspNetCoreWithKunvenkat.Models
{



    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
