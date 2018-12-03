﻿using System;
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
    public class SwipeToEditTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {
        public SwipeToEditTouchHelperCallback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public SwipeToEditTouchHelperCallback() : base(0, ItemTouchHelper.Right)
        {
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder)viewHolder;
            var vm = (PackageListItemPO)holder.DataContext;
            vm.Edit();
        }

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState,
            bool isCurrentlyActive)
        {
            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
            var itemView = viewHolder.ItemView;
            var itemHeight = itemView.Bottom - itemView.Top;

            // Draw the green edit background
            var background = new ColorDrawable { Color = Color.ParseColor("#4CAF50") };
            background.SetBounds(itemView.Left, itemView.Top, itemView.Left+(int)dX, itemView.Bottom);
            background.Draw(c);

            var context = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var editIcon = ContextCompat.GetDrawable(context, Resource.Drawable.baseline_edit_white_24);

            // Calculate position of edit icon
            var iconTop = itemView.Top + (itemHeight - editIcon.IntrinsicHeight) / 2;
            var iconMargin = (itemHeight + editIcon.IntrinsicHeight) / 2;
            var iconLeft = itemView.Left + iconMargin - editIcon.IntrinsicWidth;
            var iconRight = itemView.Left + iconMargin;
            var iconBottom = iconTop + editIcon.IntrinsicHeight;

            // Draw the edit icon
            editIcon.SetBounds(iconLeft, iconTop, iconRight, iconBottom);
            editIcon.Draw(c);
        }
    }
}
