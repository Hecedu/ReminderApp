using hw_04.Models;
using hw_04.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace hw_04.ViewModels
{
    public class NewReminderViewModel : BaseViewModel
    {
        private string title;
        private string date;
        private string content;

        readonly IVibrationService _vibrationService;
        readonly IHapticsService _hapticsService;
        readonly IBatteryService _batteryService;

        public Reminder contact { get; set; }


        public override void Init()
        {
        }

        public NewReminderViewModel(INavService navService, IDataStore<Reminder> dataStore, IVibrationService vibrationService, IHapticsService hapticsService, IBatteryService batteryService) : base (navService,dataStore)
        {
            _vibrationService = vibrationService;
            _hapticsService = hapticsService;
            _batteryService = batteryService;

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }




        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(date)
                && !String.IsNullOrWhiteSpace(content);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }

      

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            _vibrationService.Vibrate();
            // This will pop the current page off the navigation stack
            await NavService.GoBack();
        }


        private async void OnSave()
        {
            if (_batteryService.getBatteryLevel() > 0.03)
            {
                _hapticsService.performHapticFeedback();
                Reminder newItem = new Reminder()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = Title,
                    Date = Date,
                    Content = Content,
                };

                await DataStore.AddItemAsync(newItem);


                // This will pop the current page off the navigation stack

                await NavService.GoBack();

            }

        }
    }
}
