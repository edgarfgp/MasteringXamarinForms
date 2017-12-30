using Paperboy.Services;
using Paperboy.ViewModels;
using Xamarin.Forms;

namespace Paperboy.Views
{
    public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
            BindingContext = new MainViewModel(new PageService());
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            base.OnAppearing();
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            DisplayAlert("Connectivity", "The Status Connectivity has Changed", "Ok");
        }
    }
}
