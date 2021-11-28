namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System.Linq;

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

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
