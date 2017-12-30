using Paperboy.Models.NewsInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Paperboy.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing; 
            set { if (SetProperty(ref _isRefreshing, value)) OnPropertyChanged(nameof(_isRefreshing)); }
        }



        private List<NewsInformation> _worldNews;

        public List<NewsInformation> WorldNews
        {
            get => _worldNews;
            set { if (SetProperty(ref _worldNews, value)) OnPropertyChanged(nameof(_worldNews)); }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;

            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
