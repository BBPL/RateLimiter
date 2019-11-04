using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RateLimiter.Models
{
    public class TransactionLog
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ReceivedAt { get; set; }
        public Receiver Receiver { get; set; }
        public Services ServiceName { get; set; }
        public HttpStatusCode Result { get; set; }
        public string RequestData { get; set; }
        public string AnswerData { get; set; }
    }
}
