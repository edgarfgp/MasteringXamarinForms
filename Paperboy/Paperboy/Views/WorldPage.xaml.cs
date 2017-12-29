using Paperboy.Models.NewsInfo;
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
	public partial class WorldPage : ContentPage
	{
		public WorldPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            LoadNewsAsync();

            base.OnAppearing();
        }

        private async void LoadNewsAsync()
        {
            newsListView.IsRefreshing = true;

            var news = await Helpers.NewsHelper.GetByCategoryAsync(NewsCategoryType.World);

            this.BindingContext = news;

            newsListView.IsRefreshing = false;
        }

        //private void ListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    App.Current.Resources["ListTextColor"] = Color.Blue;
        //}
    }
}