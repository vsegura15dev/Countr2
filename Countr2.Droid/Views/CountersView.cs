using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Countr2.Core.ViewModels;
using Countr2.Droid.Views.RecyclerViewCallBack;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace Countr2.Droid.Views
{
    [Activity(Label = "@string/ApplicationName")]
    public class CountersView : MvxAppCompatActivity<CountersViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.counters_view);

            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SetUpRecyclerView();

        }

        private void SetUpRecyclerView()
        {

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var callBack = new SwipeItemTouchHelperCallback(ViewModel);
            var itemTouchHeloer = new ItemTouchHelper(callBack);
            itemTouchHeloer.AttachToRecyclerView(recyclerView);

        }
    }
}
