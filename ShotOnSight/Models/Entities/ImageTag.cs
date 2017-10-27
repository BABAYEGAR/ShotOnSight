using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShotOnSight.Models.Entities
{
    public class ImageTag : Transport
    {
        public long ImageTagId { get; set; }
        [Required]
        public string Name { get; set; }
        public long ImageId { get; set; }

    }
}
