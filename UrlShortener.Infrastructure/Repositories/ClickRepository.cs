using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;

namespace UrlShortener.Infrastructure.Repositories
{
    public class ClickRepository : IClickRepository
    {
        ApplicationDbContext context;
        public ClickRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddClick(Click click)
        {
            this.context.Entry<Click>(click).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.context.SaveChanges();
        }
    }
}
