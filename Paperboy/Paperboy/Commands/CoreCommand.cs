using Paperboy.Helpers;
using Paperboy.Models.NewsInfo;
using Paperboy.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Paperboy.Commands
{
    public class SpeakCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            GeneralHelper.Speak((string)parameter);
        }
    }
    public class NavigateToDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            NavigateToDetailAsync(parameter as NewsInformation);
        }

        private async void NavigateToDetailAsync(NewsInformation article)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewsDetailPage(article), true);
        }
    }

    public class NavigateToSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }

        private async void NavigateAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage(), true);
        }
    }
}
