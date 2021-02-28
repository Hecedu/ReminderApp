using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using hw_04.Views;

namespace hw_04
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ReminderDetailPage), typeof(ReminderDetailPage));
            Routing.RegisterRoute(nameof(NewReminderPage), typeof(NewReminderPage));
        }
    }
}
