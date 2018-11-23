using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace AutomationTest.Droid.Resources.Views
{
    [Activity(MainLauncher = true,NoHistory = true,ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}