using Countr2.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;

namespace Countr2.iOS.Views
{

    [MvxFromStoryboard]
    public partial class CountersView : MvxViewController
    {
        public CountersView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<CountersView, CountersViewModel>();
            //set.Bind(Label).To(vm => vm.Hello);
            //set.Bind(TextField).To(vm => vm.Hello);
            set.Apply();
        }
    }
}