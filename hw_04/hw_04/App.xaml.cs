using hw_04.Services;
using hw_04.Views;
using hw_04.ViewModels;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hw_04.Modules;
using hw_04.Views;
using Ninject.Modules;
using Ninject;

namespace hw_04
{
    public partial class App : Application
    {
        public IKernel Kernel { get; set; }
        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();
            //register core services
            Kernel = new StandardKernel(
            new hw04CoreModule(),
            new hw04NavModule());
            //register platform services
            Kernel.Load(platformModules);

            SetMainPage();
        }

        void SetMainPage()
        {
            var mainPage = new NavigationPage(new RemindersPage())
            {
                BindingContext = Kernel.Get<RemindersViewModel>()
            };

            var navService = Kernel.Get<INavService>() as XamarinFormsNavService;

            navService.XamarinFormsNav = mainPage.Navigation;

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
