using Paperboy.IServices;
using Paperboy.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Paperboy.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IPageService _pageService;

        public MainViewModel(IPageService pageService)
        {
            _pageService = pageService;
        }

        public ICommand OnSettingsCommand => (new Command(
           async () =>
        {
            await _pageService.PushAsync(new SettingsPage());
        }));
        public ICommand OnStyleTestCommand => (new Command(
          async () =>
          {
              await _pageService.PushAsync(new TestingPage());
          }));
    }
}
