﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class Order : Transport
    {
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public long? ImageId { get; set; }
        public long? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
    }
}
