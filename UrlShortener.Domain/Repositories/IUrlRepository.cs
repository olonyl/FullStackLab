using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Repositories
{
    public interface IUrlRepository
    {
        void Create(Url url);
        void Update(Url url);
        IEnumerable<Url> GetAll();
        Url GetByShortUrl(string shortUrl);
    }
}
