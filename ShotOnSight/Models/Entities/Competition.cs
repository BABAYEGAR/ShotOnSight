﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class Competition : Transport
    {
        public long CompetitionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Start Date & Time")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date & Time")]
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        //winner
        public long? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
    }
}
