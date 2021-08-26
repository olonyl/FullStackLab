using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        ApplicationDbContext context;
        public UrlRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Url url)
        {
            this.context.Entry<Url>(url).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.context.SaveChanges();
        }

        public IEnumerable<Url> GetAll()
        {
            return this.context.Urls.Include(x=> x.Clicks).ToList();
        }

        public Url GetByShortUrl(string shortUrl)
        {
            return this.context.Urls.Include(x=> x.Clicks).FirstOrDefault(f => f.ShortUrl == shortUrl);
        }

        public void Update(Url url)
        {
            this.context.Entry<Url>(url).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
