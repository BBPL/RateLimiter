namespace RequestLimiter.Models
{
    public class RequestOption
    {
        public string Endpoint { get; set; }
        public string Period { get; set; }
        public int Limit { get; set; }
    }
}