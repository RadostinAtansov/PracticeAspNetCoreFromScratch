namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public Dept Department { get; set; }

        [Required]
        [Display(Name = "Office Email")]
        [RegularExpression("asd")]
        public string Email { get; set; }
    }
}
