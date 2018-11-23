using Android.Content;
using AutomationTest.Core;
using AutomationTest.Core.PlatformServices;
using AutomationTest.Droid.FragmentLookup;
using AutomationTest.Droid.Resources.Views.Presenters;
using AutomationTest.Droid.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace AutomationTest.Droid
{
    public class Setup : MvxAppCompatSetup
    {

        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<IPopupService,DroidPopupService>();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = Mvx.IocConstruct<DroidPresenter>();

            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(presenter);

            return presenter;
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.ConstructAndRegisterSingleton<IFragmentTypeLookup,FragmentTypeLookup>();
        }
    }
}