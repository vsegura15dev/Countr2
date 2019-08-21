using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Countr2.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Countr2.Droid.Views
{
    [Activity(Label = "@string/AddNewCounter", ParentActivity = typeof(CountersView))]
    public class CounterView : MvxAppCompatActivity<CounterViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.counter_view);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.action_save_counter:
                    ViewModel.CreateCommand.Execute();
                    return true;


                case Android.Resource.Id.Home:
                    ViewModel.CloseCommand.Execute();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);
            MenuInflater.Inflate(Resource.Menu.new_counter_menu, menu);
            return true;
        }
    }
}
