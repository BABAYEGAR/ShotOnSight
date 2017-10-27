using System.ComponentModel.DataAnnotations;

namespace ShotOnSight.Models.Entities
{
    public class CompetitionUpload : Transport
    {
        public long CompetitionUploadId { get; set; }
        public long? AppUserId { get; set; }
        public long CompetitionId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Inspiration { get; set; }
        public string Description { get; set; }
        [Display(Name = "Camera")]
        public long? CameraId { get; set; }
        [Display(Name = "Location")]
        public long? LocationId { get; set; }
        public long? Like { get; set; }
        public long? DisLike { get; set; }

    }
}
