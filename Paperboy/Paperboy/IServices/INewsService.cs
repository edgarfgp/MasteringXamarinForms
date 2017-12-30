using Paperboy.Models.NewsInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.Services
{
    public interface INewsService
    {
        Task<List<NewsInformation>> GetByCategoryAsync(NewsCategoryType category);
        Task<List<NewsInformation>> GetAsync(string searchQuery);
        Task<List<NewsInformation>> GetTrendingAsync();
    }
}
