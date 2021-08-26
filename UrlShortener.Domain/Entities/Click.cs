using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Entities
{
    public class Click
    {
        public Guid Id { get; set; }
        public string Platform { get; set; }
        public string Browser { get; set; }
        public DateTime CreatedAt { get; set; }
        public Url Url { get; set; }
    }
}
