using System;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using Countr2.Core.ViewModels;

namespace Countr2.iOS.Views
{
    [MvxFromStoryboard]
    public partial class CounterView : MvxViewController
    {
        public CounterView(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var button = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            NavigationItem.SetRightBarButtonItem(button, false);
            button.AccessibilityIdentifier = "action_save_counter";
            CounterName.AccessibilityIdentifier = "new_counter_name";

            var bindingSet = this.CreateBindingSet<CounterView, CounterViewModel>();

            
            bindingSet.Bind(CounterName).To(vm => vm.Name);
            bindingSet.Bind(button).To(vm => vm.CreateCommand);

            bindingSet.Apply();
        }

      
    }
}

