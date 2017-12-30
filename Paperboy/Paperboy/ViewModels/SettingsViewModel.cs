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
