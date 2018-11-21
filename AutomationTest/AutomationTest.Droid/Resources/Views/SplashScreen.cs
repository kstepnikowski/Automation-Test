using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace AutomationTest.Droid.Resources.Views
{
    [Activity(MainLauncher = true,NoHistory = true,ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}