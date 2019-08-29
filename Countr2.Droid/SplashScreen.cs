using System;
using Countr2.Core;
using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace Countr2.Droid
{

    [Activity(
       Label = "Countr2"
       , MainLauncher = true
       , Icon = "@mipmap/ic_launcher"
       , Theme = "@style/Theme.Splash"
       , NoHistory = true
       , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen: MvxSplashScreenAppCompatActivity<MvxAppCompatSetup<App>, App>
    {
        public SplashScreen(): base(Resource.Layout.splash_screen)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AppCenter.Start("7b5052ff-eb61-4b89-b44a-dde4e8701daa",
                   typeof(Analytics),
                   typeof(Crashes),
                   typeof(Distribute));
        }
    }
}
