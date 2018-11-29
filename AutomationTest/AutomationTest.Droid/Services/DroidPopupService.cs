using System;
using Android.App;
using Android.OS;
using Android.Widget;
using AutomationTest.Core.PlatformServices;
using MvvmCross;
using MvvmCross.Platforms.Android;

namespace AutomationTest.Droid.Services
{
    public class DroidPopupService : IPopupService
    {

        public void ShowMessage(string message)
        {
            var context = Application.Context;
            Toast.MakeText(context,message,ToastLength.Long).Show();
        }

        public void Show(string title, string message, string firstButtonText, Action firstButtonAction, string secondButtonText,
            Action secondButtonAction)
        {
            AlertDialog alert;

            var activity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                alert = new AlertDialog.Builder(activity,Resource.Style.AppCompatAlertDialogStyle).Create();
            }

            else
            {
                alert = new AlertDialog.Builder(activity).Create();
            }
           
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetButton(firstButtonText, delegate { firstButtonAction(); });
            alert.SetButton2(secondButtonText, delegate { secondButtonAction(); });
            alert.Show();
        }
    }
}