﻿using Paperboy.Models.NewsInfo;
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
	public partial class TechnologyPage : ContentPage
	{
		public TechnologyPage ()
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

            var news = await Helpers.NewsHelper.GetByCategoryAsync(NewsCategoryType.ScienceAndTechnology);

            this.BindingContext = news;

            newsListView.IsRefreshing = false;
        }
    }
}