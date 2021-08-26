using System;
using System.Collections.Generic;
using hey_url_challenge_code_dotnet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;
using UrlShortener.Application.Interface;
using UrlShortener.Domain.Entities;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;
        private readonly IBrowserDetector browserDetector;
        private readonly IUrlService urlService;

        public UrlsController(ILogger<UrlsController> logger, IBrowserDetector browserDetector, IUrlService urlService)
        {
            this.browserDetector = browserDetector;
            _logger = logger;
            this.urlService = urlService;
        }

        public IActionResult Index()
        {
            HomeViewModel model =new HomeViewModel();
            model.NewUrl = new();
            model.Urls = urlService.GetUrlList();
            return View(model);
        }

        [HttpPost]
        public IActionResult GenerateShortUrl(Url url)
        {
            try
            {
                this.urlService.GenerateShortUrl(url.OriginalUrl);
                return PartialView();
            }
            catch (Exception ex) {
                ModelState.AddModelError("OriginalUrl", ex.Message);
                return PartialView(url);
            }
        }

        [HttpGet]
        [Route("ShowUrls")]
        public IActionResult ShowUrls() {
            var urls = this.urlService.GetUrlList();
            return PartialView(urls);
        }

        [Route("/{url}")]
        public IActionResult Visit(string url)
        {
            try
            {
                var newUrl = this.urlService.GenerateVisit(url, this.browserDetector.Browser.OS, this.browserDetector.Browser.Name);
                return Redirect(newUrl.Url.OriginalUrl);
            }
            catch (Exception ex) {
                return NotFound();
            }
        }

        [Route("urls/{url}")]
        public IActionResult Show(string url)
        {
            try
            {
                var dashboard = this.urlService.GetDashboard(url);
                return View(dashboard);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}