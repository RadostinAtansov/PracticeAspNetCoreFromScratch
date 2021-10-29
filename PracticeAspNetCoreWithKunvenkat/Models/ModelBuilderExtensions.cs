
namespace PracticeAspNetCoreWithKunvenkat.Models
{
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Tedu",
                Email = "Tedu@abv.bg",
                Department = Dept.Mechanic
            },
            new Employee
            {
                Id = 2,
                Name = "Radu",
                Email = "Radu@abv.bg",
                Department = Dept.It
            },
            new Employee
            {
                Id = 3,
                Name = "Boju",
                Email = "Boju@abv.bg",
                Department = Dept.Phisics
            }
        );
        }
    }
}
