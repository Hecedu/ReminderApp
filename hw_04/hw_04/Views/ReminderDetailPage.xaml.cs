using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hw_04.ViewModels;
using hw_04.Services;
using System.Diagnostics;

namespace hw_04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderDetailPage : ContentPage
    {
        ReminderDetailViewModel ViewModel => BindingContext as ReminderDetailViewModel;
        public ReminderDetailPage()
        {
            InitializeComponent();
            
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await DeleteButton.RelRotateTo(360, 500);
            await DisplayAlert("Warning", "You deleted the reminder.", "OK");
        
        }

    }
}