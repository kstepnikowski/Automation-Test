using Android.App;
using Android.Widget;
using AutomationTest.Core.Services;

namespace AutomationTest.Droid.Services
{
    public class DroidPopupService : IPopupService
    {
        public void ShowMessage(string message)
        {
            var context = Application.Context;
            Toast.MakeText(context,message,ToastLength.Long).Show();
        }
    }
}