using Paperboy.Helpers;
using Paperboy.IServices;
using Paperboy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Paperboy.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private IUserService _userService;
        private IPageService _pageService;
        private UserInformation _user;

        private string _extendedPlatformLabel;

        public string ExtendedPlatformLabel
        {
            get => _extendedPlatformLabel;
            set { if (SetProperty(ref _extendedPlatformLabel, value)) OnPropertyChanged(nameof(_extendedPlatformLabel)); }

        }


        public UserInformation User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ICommand OnSaveClickCommand => (new Command(
           () =>
          {
              _pageService.DisplayAlert("Info", "Saved Succesfully", "Ok", "Cancell");


          }));


        public SettingsViewModel(IUserService userService, IPageService pageService)
        {
            _userService = userService;
            _pageService = pageService;
            LoadUserAsync();
            var label = Helpers.GeneralHelper.GetLabel();
            _extendedPlatformLabel = Helpers.GeneralHelper.GetLabel("Running Paperboy on", true);
            _currentOrientation = Helpers.GeneralHelper.GetOrientation();
        }

        private DeviceOrientations _currentOrientation;

        public DeviceOrientations CurrentOrientation
        {
            get => _currentOrientation;
            set { if (SetProperty(ref _currentOrientation, value)) OnPropertyChanged(nameof(_currentOrientation)); }
        }

        public void LoadUserAsync()
        {
            var user = _userService.GetUserInformation();
            Set(user);


        }

        private void Set(UserInformation user)
        {
            User = user;

        }
    }
}
