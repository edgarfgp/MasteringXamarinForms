﻿using Paperboy.Extensions;
using Paperboy.Models.NewsInfo;
using Paperboy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.ViewModels
{
    public class TechnologyViewModel : BaseViewModel
    {
        private INewsService _newsService;

        public TechnologyViewModel(INewsService newsService)
        {
            _newsService = newsService;
            LoadNewsAsync().ToTaskRun();
        }

        public async Task LoadNewsAsync()
        {
            IsRefreshing = true;
            var news = await _newsService.GetByCategoryAsync(NewsCategoryType.ScienceAndTechnology);

            Set(news);
            IsRefreshing = false;
        }

        private void Set(IEnumerable<NewsInformation> news)
        {
            WorldNews = news.ToList();

        }
    }
}
