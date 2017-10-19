﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class BillingAddress : Transport
    {
        public long BillingAddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string LandMark { get; set; }
        public long? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
    }
}
