using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class SystemNotification : Transport
    {
        public long SystemNotificationId { get; set; }
        public string Message { get; set; }
        public long? ControllerId { get; set; }
        public long? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
        public bool? Read { get; set; }
    }
}
