using Paperboy.Models.NewsInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.Services
{
    public interface INewsService
    {
        Task<IEnumerable<NewsInformation>> GetByCategoryAsync(NewsCategoryType category);
        Task<IEnumerable<NewsInformation>> GetAsync(string searchQuery);
        Task<IEnumerable<NewsInformation>> GetTrendingAsync();
    }
}
