using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Models
{
    public class DashBoardModel
    {
      public Url Url { get; set; }
      public Dictionary<string, int> DailyClicks { get; set; } = new Dictionary<string, int>();
      public Dictionary<string, int> BrowserClicks { get; set; } = new Dictionary<string, int>();
      public Dictionary<string, int> PlatfomClicks { get; set; } = new Dictionary<string, int>();
    }
}
