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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            BindingContext = new SettingsViewModel(new UserService(), new PageService());
            InitializeComponent();
            articleCountSlider.Value = 10;
            categoryPicker.SelectedIndex = 1;
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
        }

    }
}