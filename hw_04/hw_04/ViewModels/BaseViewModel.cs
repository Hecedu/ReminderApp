﻿using hw_04.Models;
using hw_04.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace hw_04.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        bool isBusy = false;
        protected INavService NavService { get; private set; }
        protected IDataStore<Reminder> DataStore { get; private set; }
        protected BaseViewModel(INavService navService, IDataStore<Reminder> dataStore)
        {
            NavService = navService;
            DataStore = dataStore;
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public virtual void Init()
        {
        }
    }
    //
    public class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel(INavService navService, IDataStore<Reminder> dataStore)
           : base(navService, dataStore)
        {
        }


        public override void Init()
        {
            Init(default(TParameter));
        }

        public virtual void Init(TParameter parameter)
        {
        }
    }
}
