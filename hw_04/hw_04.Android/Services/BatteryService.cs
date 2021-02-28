using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hw_04.Services;

namespace hw_04.Droid.Services
{
    class BatteryService : IBatteryService
    {
        public double getBatteryLevel()
        {
            return Xamarin.Essentials.Battery.ChargeLevel;
        }
    }
}