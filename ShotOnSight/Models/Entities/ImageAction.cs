﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class ImageAction 
    {
        public long ImageActionId { get; set; }
        public long? Like { get; set; }
        public long? Dislike { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
        public long? AppUserId { get; set; }
        public long? OwnerId { get; set; }
        public long ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }
}
