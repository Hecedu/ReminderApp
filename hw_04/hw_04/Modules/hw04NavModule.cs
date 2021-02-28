using System;
using System.Collections.Generic;
using System.Text;
using hw_04.Services;
using hw_04.ViewModels;
using hw_04.Views;

namespace hw_04.Modules
{
    class hw04NavModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            var navService = new XamarinFormsNavService();

            navService.RegisterViewMapping(typeof(RemindersViewModel), typeof(RemindersPage));
            navService.RegisterViewMapping(typeof(ReminderDetailViewModel), typeof(ReminderDetailPage));
            navService.RegisterViewMapping(typeof(NewReminderViewModel), typeof(NewReminderPage));

            Bind<INavService>()
            .ToMethod(x => navService)
            .InSingletonScope();
        }
    }
}
