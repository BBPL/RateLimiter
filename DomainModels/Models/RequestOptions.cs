using System.Collections;
using System.Net;

namespace RequestLimiter.Models
{
    public class RequestOptions : IEnumerable
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public RequestOption[] Rules { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}