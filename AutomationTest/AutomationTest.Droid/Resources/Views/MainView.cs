using Android.App;
using Android.Content.PM;
using Android.OS;
using AutomationTest.Core.ViewModels;
using AutomationTest.Droid.Resources.Views.Fragments;
using AutomationTest.Droid.Resources.Views.Presenters;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace AutomationTest.Droid.Resources.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxCachingFragmentCompatActivity<HomeViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var presenter = (DroidPresenter) Mvx.Resolve<IMvxAndroidViewPresenter>();
            var initialFragment = new HomeFragment {ViewModel = ViewModel};

            presenter.RegisterFragmentManager(SupportFragmentManager, initialFragment);
        }
    }
}