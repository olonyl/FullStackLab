using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Repositories
{
    public interface IClickRepository
    {
        void AddClick(Click click);
    }
}
