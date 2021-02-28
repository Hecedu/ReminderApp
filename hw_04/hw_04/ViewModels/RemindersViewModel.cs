using hw_04.Models;
using hw_04.Views;
using hw_04.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hw_04.ViewModels
{
    public class RemindersViewModel:BaseViewModel
    {
        private Reminder _selectedItem;

        public ObservableCollection<Reminder> Contacts { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Reminder> ItemTapped { get; }

        public RemindersViewModel(INavService navService, IDataStore<Reminder> dataStore) :base (navService,dataStore)
        {
            Contacts = new ObservableCollection<Reminder>();
        }

        public Command<Reminder> ViewCommand => new Command<Reminder>(async entry => await NavService.NavigateTo<ReminderDetailViewModel, Reminder>(entry));
        public Command AddCommand => new Command(async () => await NavService.NavigateTo<NewReminderViewModel>());
        async public override void Init()
        {
            await LoadItems();
        }
        async Task LoadItems()
        {
            IsBusy = true;

            try
            {
                Contacts.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Contacts.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewReminderPage));
        }

    }
}
