using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShotOnSight.Models.Entities
{
    public class Camera : Transport
    {
        public long CameraId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
