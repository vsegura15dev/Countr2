
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Countr2.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Countr2.Droid.Views
{
    [Activity(Label = "CountersView")]
    public class CountersView : MvxAppCompatActivity<CountersViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.counters_view);

        }
    }
}
