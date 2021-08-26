using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Helpers;
using UrlShortener.Application.Interface;
using UrlShortener.Application.Models;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;

namespace UrlShortener.Application.Services
{
    public class UrlService : IUrlService
    {
        IUrlRepository urlRepository;
        IClickRepository clickRepository;
        public UrlService(IUrlRepository urlRepository, IClickRepository clickRepository)
        {
            this.urlRepository = urlRepository;
            this.clickRepository = clickRepository;
        }
        public Url GenerateShortUrl(string longUrl)
        {
            if (UrlHelper.IsValidUrl(longUrl))
                return CreateNewUrl(longUrl);
            else throw new Exception("Please enter a valid URL");
        }

        public Click GenerateVisit(string shortUrl, string platform, string browser)
        {
            var url = urlRepository.GetByShortUrl(shortUrl);
            if (url == null) throw new Exception("URL Not Found");

            var click = new Click
            {
                Browser = browser,
                Platform = platform, 
                CreatedAt = DateTime.Now,
                Url = url
            };
            url.Clicks.Append(click);
            clickRepository.AddClick(click);
            urlRepository.Update(url);

            return click;
        }

        public DashBoardModel GetDashboard(string shortUrl)
        {
            var url = urlRepository.GetByShortUrl(shortUrl);
            if (url == null) throw new Exception("URL Not Found");

            DashBoardModel dashBoard = new DashBoardModel();

            dashBoard.Url = url;

            var groupByDate = url.Clicks.GroupBy(x => x.CreatedAt.Date).ToList();
            var groupByPlatForm = url.Clicks.GroupBy(x => x.Platform).ToList();
            var groupByBrowser = url.Clicks.GroupBy(x => x.Browser).ToList();


            groupByDate.ForEach(x => dashBoard.DailyClicks.Add(x.Key.Date.ToString("MM/dd/yyyy"), x.Count()));
            groupByPlatForm.ForEach(x => dashBoard.PlatfomClicks.Add(x.Key, x.Count()));
            groupByBrowser.ForEach(x => dashBoard.BrowserClicks.Add(x.Key, x.Count()));

            return dashBoard;

        }

        public Url GetUrl(string shortUrl)
        {
            return this.urlRepository.GetByShortUrl(shortUrl);
        }

        public IEnumerable<Url> GetUrlList()
        {
            return this.urlRepository.GetAll();
        }
        private Url CreateNewUrl(string originalUrl) 
        {
            Url url = new Url
            {
                CreatedAt = DateTime.Now,
                OriginalUrl = originalUrl,
                ShortUrl = GenerateShortUrl()
            };
            this.urlRepository.Create(url);
            return url;
        }
        private string GenerateShortUrl()
        {
            var newShortUrl = UrlHelper.GenerateRandomString();
            while(IsThisUrlTaken(newShortUrl))
                newShortUrl = UrlHelper.GenerateRandomString();
            return newShortUrl;
        }
        public bool IsThisUrlTaken(string shortUrl)
        {
            return urlRepository.GetByShortUrl(shortUrl) != null;
        }

    }
}
