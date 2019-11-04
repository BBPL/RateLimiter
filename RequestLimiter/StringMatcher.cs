using System;
using System.Text.RegularExpressions;

namespace RequestLimiter
{
    public static class StringMatcher
    {
        private static readonly char ASTERIX = '*';

        public static bool MatchEndpoints(this string endpoint, string compare)
        {
            // /api/*
            //var asterixPattern = new Regex(@"(?<asterix>\/\*)");
            //var segmentPattern = new Regex(@"(?<group>\/\w*)");
            var matchedAsterix = false;
            var endpointIndex = 0;
            var matching = true;

            for (int i = 0; i < compare.Length; i++)
            {


                if (compare[i] == endpoint[endpointIndex])
                {
                    endpointIndex++;
                }
                else if (endpoint[endpointIndex] == ASTERIX)
                {
                    continue;
                }
                else
                {
                    matching = false;
                }

            }

            return matching;
        }
    }
}