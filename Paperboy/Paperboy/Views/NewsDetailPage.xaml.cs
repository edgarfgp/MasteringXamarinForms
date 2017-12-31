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
    public partial class NewsDetailPage : ContentPage
    {
        public NewsInformation CurrentArticle { get; set; }

        public NewsDetailPage()
        {
            InitializeComponent();
        }
        public NewsDetailPage(NewsInformation currentArticle)
        {
            this.CurrentArticle = currentArticle;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            this.BindingContext = this.CurrentArticle;

            base.OnAppearing();
        }
    }
}