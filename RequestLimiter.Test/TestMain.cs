using System;
using Xunit;

namespace RequestLimiter.Test
{
    public class TestMain
    {
        [Fact]
        public void TwoPlusTwoIsFour()
        {
            var res = 2 + 2;
            Assert.Equal(4, res);
        }
    }

    public class StringMatcher
    {
        [Theory]
        [InlineData("/api", "/api")]
        [InlineData("/*", "/api")]
        [InlineData("/*", "/api/transaction")]
        [InlineData("/api/*", "/api/transaction")]
        [InlineData("/*/transaction", "/api/transaction")]
        [InlineData("/*/transaction/*", "/api/transaction/test")]
        public void StringMatches(string val1, string val2)
        {
            Assert.True(val1.MatchEndpoints(val2));
        }

        [Theory]
        [InlineData("/*", "/*")]
        public void StringDoesNotMatchOnEndpoint(string val1, string val2)
        {
            Assert.False(val1.MatchEndpoints(val2));
        }
    }
}
