namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class AppDbContex : IdentityDbContext<ApplicationUser>
    {
        public AppDbContex(DbContextOptions<AppDbContex> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
