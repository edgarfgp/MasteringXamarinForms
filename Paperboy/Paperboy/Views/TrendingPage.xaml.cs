using Paperboy.Services;
using Paperboy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paperboy.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrendingPage : ContentPage
	{
		public TrendingPage ()
		{
            BindingContext = new TrendingViewModel(new NewsService());
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
          // await ViewModel.LoadNewsAsync();

            base.OnAppearing();
        }

        private TrendingViewModel ViewModel
        {
            get => BindingContext as TrendingViewModel;

            set => BindingContext = value;
        }

    }
}