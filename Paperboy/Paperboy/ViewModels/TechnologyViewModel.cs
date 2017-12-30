using Paperboy.Extensions;
using Paperboy.Models.NewsInfo;
using Paperboy.Services;
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
            IsBusy = true;
            var news = await _newsService.GetByCategoryAsync(NewsCategoryType.ScienceAndTechnology);

            Set(news);
            IsBusy = false;
        }

        private void Set(IEnumerable<NewsInformation> news)
        {
            WorldNews = news.ToList();

        }

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
