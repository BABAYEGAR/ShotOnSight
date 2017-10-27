﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class ImageSubCategory : Transport
    {
        public long ImageSubCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public long? ImageCategoryId { get; set; }
    }
}
