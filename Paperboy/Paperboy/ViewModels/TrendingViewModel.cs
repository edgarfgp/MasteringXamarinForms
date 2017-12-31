using Paperboy.Extensions;
using Paperboy.IServices;
using Paperboy.Models.NewsInfo;
using Paperboy.Services;
using Paperboy.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Paperboy.ViewModels
{
    public class TrendingViewModel : BaseViewModel
    {
        private INewsService _newsService;
        private IPageService _pageService;

        public TrendingViewModel(INewsService newsService, IPageService pageService)
        {
            _newsService = newsService;
            _pageService = pageService;
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

        
        public ICommand NavigateToDetailCommand => (new Command<NewsInformation>(async (vm) =>
        {
            if (vm == null)
                return;
            await _pageService.PushAsync(new NewsDetailPage(vm));

        }));

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsRefreshing = true;
                        await LoadNewsAsync();
                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Excepcion " + ex.Message);
                    }
                    finally
                    {
                        IsRefreshing = false;
                    }

                });
            }
        }
    }
}
