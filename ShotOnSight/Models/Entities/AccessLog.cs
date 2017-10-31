﻿namespace ShotOnSight.Models.Entities
{
    public class AccessLog : Transport
    {
        public long AccessLogId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public long? TenancyId { get; set; }
        public long? AppUserId { get; set; }
    }
}
