using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget.Helper;
using AutomationTest.Core.ViewModels;
using AutomationTest.Droid.Behaviors;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace AutomationTest.Droid.Resources.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class PackagesListView : MvxAppCompatActivity<PackagesListViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.packages_list);
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.packagesRecyclerView);
            var itemTouchHelper = new ItemTouchHelper(new SwipeToDeleteTouchHelperCallback());
            var editItemTouchHelper = new ItemTouchHelper(new SwipeToEditTouchHelperCallback());
            itemTouchHelper.AttachToRecyclerView(recyclerView);
            editItemTouchHelper.AttachToRecyclerView(recyclerView);
        }
    }
}