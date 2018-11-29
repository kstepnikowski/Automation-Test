using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using AutomationTest.Core.Models.PO;
using MvvmCross;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android;

namespace AutomationTest.Droid.Behaviors
{
    public class SwipeToDeleteTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {
        public SwipeToDeleteTouchHelperCallback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference,
            transfer)
        {
        }

        public SwipeToDeleteTouchHelperCallback() : base(0,ItemTouchHelper.Left)
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

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState,
            bool isCurrentlyActive)
        {
            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
            var itemView = viewHolder.ItemView;
            var itemHeight = itemView.Bottom - itemView.Top;

            // Draw the red delete background
            var background = new ColorDrawable {Color = Color.ParseColor("#f44336")};
            background.SetBounds(itemView.Right+(int)dX,itemView.Top,itemView.Right,itemView.Bottom);
            background.Draw(c);

            var context = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var deleteIcon = ContextCompat.GetDrawable(context, Resource.Drawable.baseline_delete_white_24);

            // Calculate position of delete icon
            var iconTop = itemView.Top + (itemHeight-deleteIcon.IntrinsicHeight)/2;
            var iconMargin = (itemHeight - deleteIcon.IntrinsicHeight) / 2;
            var iconLeft = itemView.Right - iconMargin - deleteIcon.IntrinsicWidth;
            var iconRight = itemView.Right - iconMargin;
            var iconBottom = iconTop + deleteIcon.IntrinsicHeight;

            // Draw the delete icon
            deleteIcon.SetBounds(iconLeft,iconTop,iconRight,iconBottom);
            deleteIcon.Draw(c);
        }
    }
}