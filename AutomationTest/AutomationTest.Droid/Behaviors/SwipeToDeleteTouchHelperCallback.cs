using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using AutomationTest.Core.Models.PO;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace AutomationTest.Droid.Behaviors
{
    public class SwipeToDeleteTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {
        public SwipeToDeleteTouchHelperCallback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference,
            transfer)
        {
        }

        public SwipeToDeleteTouchHelperCallback() : base(0,
            ItemTouchHelper.Left | ItemTouchHelper.AnimationTypeSwipeCancel)
        {
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder,
            RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder) viewHolder;
            var vm = (PackageListItemPO) holder.DataContext;
            vm.Delete();
        }
    }
}