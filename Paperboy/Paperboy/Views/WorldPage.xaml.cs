using Paperboy.Commands;
using Paperboy.Models.NewsInfo;
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
    public partial class WorldPage : ContentPage
    {
        public WorldPage()
        {
            BindingContext = new WorldViewModel(new NewsService(), new PageService());
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            //  await ViewModel.LoadNewsAsync();
            base.OnAppearing();
        }
        private WorldViewModel ViewModel
        {
            get => BindingContext as WorldViewModel;

            set => BindingContext = value;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.NavigateToDetailCommand.Execute(e.Item as NewsInformation);
        }
    }
}