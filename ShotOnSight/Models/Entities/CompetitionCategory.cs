namespace ShotOnSight.Models.Entities
{
    public class CompetitionCategory : Transport
    {
        public long CompetitionCategoryId { get; set; }
        public long CompetitionId { get;set; }
        public long PhotographerCategoryId { get; set; }
    }
}
