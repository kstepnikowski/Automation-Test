using Android.App;
using Android.Content.PM;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace AutomationTest.Droid.Resources.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class DimmPackagesView : MvxAppCompatActivity<DimmPackagesViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.dimm_packages);
        }
    }
}