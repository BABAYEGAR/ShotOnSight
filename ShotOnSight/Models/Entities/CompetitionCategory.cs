﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class CompetitionCategory : Transport
    {
        public long CompetitionCategoryId { get; set; }
        public long CompetitionId { get;set; }
        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }
        public long PhotographerCategoryId { get; set; }
        [ForeignKey("PhotographerCategoryId")]
        public PhotographerCategory PhotographerCategory { get; set; }
    }
}
