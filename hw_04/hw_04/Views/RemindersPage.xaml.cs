using hw_04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hw_04.Services;

namespace hw_04.Views
{
    public partial class RemindersPage : ContentPage
    {
        RemindersViewModel ViewModel => BindingContext as RemindersViewModel;
        //ContactsViewModel _viewModel;
        public RemindersPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.Init();
        }

    }
}