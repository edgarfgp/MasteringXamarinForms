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
    public class WorldViewModel : BaseViewModel
    {
        private INewsService _newsService;

        public WorldViewModel(INewsService newsService)
        {
            _newsService = newsService;
            LoadNewsAsync().ToTaskRun();

        }
        public async Task LoadNewsAsync()
        {
            IsBusy = true;
            var news = await _newsService.GetByCategoryAsync(NewsCategoryType.ScienceAndTechnology);

            Set(news);
            IsBusy = false;
        }

        private void Set(IEnumerable<NewsInformation> news)
        {
            WorldNews = news.ToList();

        }
    }
}
