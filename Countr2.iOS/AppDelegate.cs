using Countr2.Core;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace Countr2.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
             
            #if DEBUG
            Xamarin.Calabash.Start();
            #endif

            UINavigationBar.Appearance.BarTintColor = UIColor.Orange;
			UINavigationBar.Appearance.TintColor = UIColor.DarkGray;
			var attrs = new NSDictionary(UIStringAttributeKey.ForegroundColor,
										 UIColor.DarkGray);
			UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes(attrs);
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.MakeKeyAndVisible();


            AppCenter.Start("49201660-79e8-4afe-9bd4-f14622bebf83", typeof(Analytics), typeof(Crashes));

            return base.FinishedLaunching(application, launchOptions);
        }
    }
}