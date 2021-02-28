using System;
using System.Collections.Generic;
using System.Text;
using hw_04.ViewModels;
using hw_04.Models;
using hw_04.Services;

namespace hw_04.Modules
{
    class hw04CoreModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            // ViewModels 
            Bind<ReminderDetailViewModel>().ToSelf();
            Bind<RemindersViewModel>().ToSelf();
            Bind<NewReminderViewModel>().ToSelf();
            Bind<IDataStore<Reminder>>().To<DataStore>().InSingletonScope();
        }
    }
}
