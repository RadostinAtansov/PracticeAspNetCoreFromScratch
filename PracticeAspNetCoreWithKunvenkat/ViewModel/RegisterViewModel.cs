﻿namespace PracticeAspNetCoreWithKunvenkat.ViewModel
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;


    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

    }
}
