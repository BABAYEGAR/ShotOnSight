﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class ImageComment  : Transport
    {
        public long ImageCommentId { get; set; }
        public string Comment { get; set; }
        public long? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
        public long? AppUserId { get; set; }
    }
}
