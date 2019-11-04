using System;

namespace RequestLimiter.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Path { get; set; }
        public DateTime RequestTime { get; set; }
    }
}