using Newtonsoft.Json;
using Paperboy.Contants;
using Paperboy.Models;
using Paperboy.Models.NewsInfo;
using Paperboy.Models.TrendingNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Paperboy.Contants.CoreConstants;

namespace Paperboy.Services
{
    public class NewsService : INewsService
    {
        public async Task<IEnumerable<NewsInformation>> GetByCategoryAsync(NewsCategoryType category)
        {
            var results = new List<NewsInformation>();

            string searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/news/?Category={category}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NewsSearchApiKey);

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

            results = (from item in newsResult.Value
                       select new NewsInformation()
                       {
                           Title = item.Name,
                           Description = item.Description,
                           CreatedDate = item.DatePublished,
                           ImageUrl = item.Image?.Thumbnail?.ContentUrl,

                       }).ToList();

            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }

        public async Task<IEnumerable<NewsInformation>> GetAsync(string searchQuery)
        {
            var results = new List<NewsInformation>();

            string searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/news/search?q={searchQuery}&count=10&offset=0&mkt=en-us&safeSearch=Moderate";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NewsSearchApiKey);

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

            results = (from item in newsResult.Value
                       select new NewsInformation()
                       {
                           Title = item.Name,
                           Description = item.Description,
                           CreatedDate = item.DatePublished,
                           ImageUrl = item.Image?.Thumbnail?.ContentUrl,

                       }).ToList();

            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }

        public async Task<IEnumerable<NewsInformation>> GetTrendingAsync()
        {
            var results = new List<NewsInformation>();

            string searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/news/trendingtopics";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", NewsSearchApiKey);

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<TrendingNewsResult>(result);

            results = (from item in newsResult.Value
                       select new NewsInformation()
                       {
                           Title = item.Name,
                           Description = item.Query.Text,
                           CreatedDate = DateTime.Now,
                           ImageUrl = item.Image.Url,

                       }).ToList();

            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();

        }
    }
}
