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
using Xamarin.Essentials;

namespace hw_04.Droid.Services
{
    class HapticsService : IHapticsService
    {
        public void performHapticFeedback()
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
    }
}