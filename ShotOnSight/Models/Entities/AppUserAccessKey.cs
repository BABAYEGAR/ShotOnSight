using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class AppUserAccessKey : Transport
    {
        public long AppUserAccessKeyId { get; set; }
        public long AppUserId { get;set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
        public string PasswordAccessCode { get; set; }
        public string AccountActivationAccessCode { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
