using System;
using System.Threading.Tasks;
using Countr2.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Countr2.Core
{
    public class AppStart : MvxAppStart
    {

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService)
            : base(application, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<CountersViewModel>();
        }
    }
}
