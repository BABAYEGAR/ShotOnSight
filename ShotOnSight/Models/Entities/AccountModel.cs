﻿using System.ComponentModel.DataAnnotations;

namespace ShotOnSight.Models.Entities
{
    public class AccountModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Photographer Category")]
        public long? PhotographerCategoryId { get; set; }
    }
}
