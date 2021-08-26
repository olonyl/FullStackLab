using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Models;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interface
{
    public interface IUrlService
    {
        Url GenerateShortUrl(string longUrl);
        Click GenerateVisit(string shortUrl, string platform, string browser);
        Url GetUrl(string shortUrl);
        IEnumerable<Url> GetUrlList();
        DashBoardModel GetDashboard(string shortUrl);
    }
}
