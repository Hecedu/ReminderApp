using hw_04.Models;
using hw_04.ViewModels;
using hw_04.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hw_04.Views
{
  
    public partial class NewReminderPage : ContentPage
    {
        NewReminderViewModel ViewModel => BindingContext as NewReminderViewModel;
        public Reminder Reminder { get; set; }

        public NewReminderPage()
        {
            InitializeComponent();
        }
    }
}