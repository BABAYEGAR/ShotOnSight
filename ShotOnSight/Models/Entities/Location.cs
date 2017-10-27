using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShotOnSight.Models.Entities
{
    public class Location : Transport
    {
        public long LocationId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
