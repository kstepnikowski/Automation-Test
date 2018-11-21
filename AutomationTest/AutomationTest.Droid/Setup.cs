using AutomationTest.Core;
using AutomationTest.Core.Services;
using AutomationTest.Droid.Services;
using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;

namespace AutomationTest.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.IoCProvider.RegisterType<IPopupService,DroidPopupService>();
        }
    }
}