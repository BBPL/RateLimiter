using System;
using System.Linq;
using Context.Context;
using Microsoft.Extensions.Options;
using RequestLimiter.Models;
using DateTime = System.DateTime;

namespace RequestLimiter.Services
{
    public class RequestLimiter
    {
        private readonly TestContext _context;
        //private readonly IMemoryCache _cache;
        private readonly RequestOptions _options;

        public RequestLimiter(IOptions<RequestOptions> options)
        {
            _context = new TestContext();
            //_cache = cache;
            _options = options.Value;

        }

        public bool Check(Guid userId, string path)
        {

            //if (CheckDuplicateCall(userId, path)) return false; //Check for duplicate calls

            var requestLimit = GetLimit(path);
            var timeDiff = GetDiff(path);
            var requests = _context.Requests.Where(r => r.UserId == userId && r.RequestTime > timeDiff).Select(r => r).ToList();

            if (requests.Count <= requestLimit)
            {
                var request = new Request()
                {
                    UserId = userId,
                    Path = path,
                    RequestTime = DateTime.Now
                };
                _context.Add(request);
                _context.SaveChanges();
                _context.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool CheckDuplicateCall(Guid userId, string path)
        {
            var diff = DateTime.Now - Constants.AllowDiffForDoubles;
            var request = _context.Requests.Where(r => r.UserId == userId && r.RequestTime > diff && r.Path == path).Select(r => r).ToList();

            return request.Count > 0;
        }

        private DateTime GetDiff(string path)
        {
            foreach (var rule in _options.Rules)
            {
                if (path == rule.Endpoint) continue;

                if (!TimeSpan.TryParse(rule.Period, out var ts)) throw new ApplicationException("Wrong time format");
                
                var diff = DateTime.Now - ts;
                return diff;
            }

            return DateTime.Now - new TimeSpan(1,0,0);
        }

        public int GetLimit(string path)
        {
            foreach (var rule in _options.Rules)
            {
                if (path == rule.Endpoint) return rule.Limit;
            }
            return Int32.MaxValue;

        }


    }
}