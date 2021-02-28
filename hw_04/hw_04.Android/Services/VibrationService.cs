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
using Xamarin.Essentials;
using hw_04.Services;

namespace hw_04.Droid.Services
{
    class VibrationService : IVibrationService
    {
        public void Vibrate()
        {
            Xamarin.Essentials.Vibration.Vibrate();
        }
    }
}