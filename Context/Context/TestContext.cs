using Microsoft.EntityFrameworkCore;
using RateLimiter.Models;
using RequestLimiter.Models;

namespace Context.Context
{
    public class TestContext : DbContext
    {
        public DbSet<TransactionLog> TransactionLogs { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=testing.db");

        //public void Seed()
        //{
        //    var transactions = Builder<TransactionLog>.CreateListOfSize(400)
        //        .All()
        //        .With(t => t.CreatedAt = Faker.DateTimeFaker.DateTime())
        //        .With(t => t.ReceivedAt = Faker.DateTimeFaker.DateTime())
        //        .With(t => t.Receiver = Faker.EnumFaker.SelectFrom<Receiver>())
        //        .With(t => t.ServiceName = Faker.EnumFaker.SelectFrom<Models.Services>())
        //        .With(t => t.Result = HttpStatusCode.Accepted)
        //        .With(t => t.RequestData = Faker.TextFaker.Sentences(3))
        //        .With(t => t.AnswerData = Faker.TextFaker.Sentences(3))
        //        .Build();

        //    this.TransactionLogs.AddRange(transactions);
        //    this.SaveChanges();
        //}
    }
}