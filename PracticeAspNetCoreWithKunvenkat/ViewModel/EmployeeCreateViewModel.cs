
namespace PracticeAspNetCoreWithKunvenkat.ViewModel
{
    using Microsoft.AspNetCore.Http;
    using PracticeAspNetCoreWithKunvenkat.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class EmployeeCreateViewModel
    {

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public Dept Department { get; set; }

        [Required]
        [Display(Name = "Office Email")]
        //[RegularExpression("", ErrorMessage = "Blq blq blq")]
        public string Email { get; set; }

        public List<IFormFile> Photos { get; set; }

    }
}
