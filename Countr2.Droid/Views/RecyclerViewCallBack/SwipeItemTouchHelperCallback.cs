using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Countr2.Core.ViewModels;

namespace Countr2.Droid.Views.RecyclerViewCallBack
{
    public class SwipeItemTouchHelperCallback: ItemTouchHelper.SimpleCallback
    {
        readonly CountersViewModel viewModels;

        public SwipeItemTouchHelperCallback(CountersViewModel viewModel) : base(0, ItemTouchHelper.Start)
        {
            viewModels = viewModel;
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return true;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            viewModels.Counters[viewHolder.AdapterPosition].DeleteCommand.Execute();
        }
    }
}
