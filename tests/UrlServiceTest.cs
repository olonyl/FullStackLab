using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Services;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;

namespace tests
{
    [TestFixture]
    public class UrlServiceTests
    {
        UrlService service;
        Mock<IUrlRepository> urlRepository;

        [SetUp]
        public void Setup()
        {
            urlRepository = new Mock<IUrlRepository>();
            service = new UrlService(urlRepository.Object, null);
        }

        [Test]
        public void CreateShortenUrl_WhenIsNullOrEmptyString_ThrowsException()
        {
            Assert.That(() => service.GenerateShortUrl(""), Throws.Exception);
        }

        [Test]
        public void CreateShortenUrl_WhenIsCalled()
        {
            service.GenerateShortUrl("https://stackoverflow.com/questions/16186083/making-a-simple-ajax-call-to-controller-in-asp-net-mvc");

            urlRepository.Verify(x => x.Create(It.IsAny<Url>()), Times.Once);
        }

    }
}
