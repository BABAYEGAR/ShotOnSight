namespace ShotOnSight.Models.Entities
{
    public class Invoice: Transport
    {
        public long InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public long? Amount { get; set; }
    }
}
