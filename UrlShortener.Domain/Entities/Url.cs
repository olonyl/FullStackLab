using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Entities
{
    public class Url
    {
        public Guid Id { get; set; }
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Click> Clicks { get; set; } = new List<Click>();
    }
}
