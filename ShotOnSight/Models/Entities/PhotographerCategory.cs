﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShotOnSight.Models.Entities
{
    public class PhotographerCategory : Transport
    {
        public long PhotographerCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PhotographerCategoryMapping> PhotographerCategoryMappings { get; set; }
    }
}
