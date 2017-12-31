﻿using Paperboy.Models.NewsInfo;
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

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set { if (SetProperty(ref _isBusy, value)) OnPropertyChanged(nameof(_isBusy)); }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }


        private List<NewsInformation> _worldNews;

        public List<NewsInformation> WorldNews
        {
            get => _worldNews;
            set { if (SetProperty(ref _worldNews, value)) OnPropertyChanged(nameof(_worldNews)); }
        }

        private NewsInformation _seletectedInfo;

        public NewsInformation SeletectedInfo
        {
            get => _seletectedInfo;
            set
            {
                _seletectedInfo = value;
                if (value != null)
                {
                    SetProperty(ref _seletectedInfo, null);
                }
            }
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
