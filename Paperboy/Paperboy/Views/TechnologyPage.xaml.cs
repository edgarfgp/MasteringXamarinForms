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
    public partial class TechnologyPage : ContentPage
    {
        public TechnologyPage()
        {
            BindingContext = new TechnologyViewModel(new NewsService());
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
           // await ViewModel.LoadNewsAsync();

            base.OnAppearing();
        }

        private TechnologyViewModel ViewModel
        {
            get => BindingContext as TechnologyViewModel;

            set => BindingContext = value;
        }



    }
}