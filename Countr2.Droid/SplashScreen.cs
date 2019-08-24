using System;
using Countr2.Core;
using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

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
    }
}
