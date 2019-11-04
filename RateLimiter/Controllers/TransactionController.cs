using System;
using System.Linq;
using Context.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RateLimiter.Models;
using RequestLimiter.Models;

namespace RateLimiter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TestContext _testContext;
        private readonly RequestLimiter.Services.RequestLimiter _requestLimiter;

        public TransactionController(IOptions<RequestOptions> option)
        {
            _testContext = new TestContext();
            _requestLimiter = new RequestLimiter.Services.RequestLimiter(option);
        }

        [HttpGet]
        public string Index()
        {
            if (_requestLimiter.Check(Guid.Empty, Request.Path)) return "Too many requests";
            var randomTransaction = _testContext.TransactionLogs.FirstOrDefault();
            return randomTransaction.AnswerData;
        }

        public string Test()
        {
            var urlPath = HttpContext.Request.Path;
            var r = _requestLimiter.Check(Guid.Empty, urlPath);
            return r.ToString();
        }


        //[HttpGet]
        //public string Seed()
        //{
        //    _testContext.Seed();
        //    return "DB is now seeded!";
        //}
    }
}