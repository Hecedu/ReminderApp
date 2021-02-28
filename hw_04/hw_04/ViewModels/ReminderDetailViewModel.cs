using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using hw_04.Models;
using hw_04.Services;

namespace hw_04.ViewModels
{
    public class ReminderDetailViewModel : BaseViewModel<Reminder>
    {
        Reminder _reminder;
        public Reminder Reminder
        {
            get => _reminder;
            set
            {
                _reminder = value;
                OnPropertyChanged();
            }
        }


        public ReminderDetailViewModel(INavService navService,IDataStore<Reminder>dataStore)
         : base(navService,dataStore)
        {
            DeleteCommand = new Command(OnDelete);
        }

        public override void Init(Reminder parameter)
        {
            Reminder = parameter;
        }

        public Command DeleteCommand { get; }
    
        private async void OnDelete()
        {
           
            await DataStore.DeleteItemAsync(Reminder.Id);
            // This will pop the current page off the navigation stack
            await NavService.GoBack();
        }
    }
}
