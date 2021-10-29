namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }


        public Dept Department { get; set; }

        [Required]
        [Display(Name = "Office Email")]
        //[RegularExpression("", ErrorMessage = "Blq blq blq")]
        public string Email { get; set; }

        public string PhotoPat { get; set; }
    }
}
