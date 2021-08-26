using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrlShortener.Application.Helpers
{
    public class UrlHelper
    {
        const string pattern = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})";
        const string urlChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const int shortStringLength = 5;

        public static bool IsValidUrl(string url)
        {
            return Regex.Match(url, pattern).Success;
        }

        public static string GenerateRandomString()
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(urlChars, shortStringLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
