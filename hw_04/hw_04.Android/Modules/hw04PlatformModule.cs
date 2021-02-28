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
using hw_04.Droid.Services;


namespace hw_04.Droid.Modules
{
    class hw04PlatformModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IVibrationService>()
                .To<VibrationService>()
                .InSingletonScope();
            Bind<IHapticsService>()
                .To<HapticsService>()
                .InSingletonScope();
            Bind<IBatteryService>()
                .To<BatteryService>()
                .InSingletonScope();
        }
    }
}