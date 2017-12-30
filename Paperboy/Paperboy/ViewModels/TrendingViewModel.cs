using Paperboy.Extensions;
using Paperboy.Models.NewsInfo;
using Paperboy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.ViewModels
{
    public class TrendingViewModel : BaseViewModel
    {
        private INewsService _newsService;

        public TrendingViewModel(INewsService newsService)
        {
            _newsService = newsService;
            LoadNewsAsync().ToTaskRun();

        }
        public async Task LoadNewsAsync()
        {
            IsBusy = true;
            var news = await _newsService.GetTrendingAsync();

            Set(news);
            IsBusy = false;
        }

        private void Set(IEnumerable<NewsInformation> news)
        {
            WorldNews = news.ToList();

        }
    }
}
