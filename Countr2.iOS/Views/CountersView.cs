using Countr2.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using System;
using UIKit;

namespace Countr2.iOS.Views
{

    [MvxFromStoryboard]
    public partial class CountersView : MvxTableViewController
    {
        public CountersView (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var button = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            NavigationItem.SetRightBarButtonItem(button, false);
            button.AccessibilityIdentifier = "add_counter_button";

            var setBindings = this.CreateBindingSet<CountersView, CountersViewModel>();

            var source = new CountersTableViewSource(TableView);
            TableView.Source = source;

            setBindings.Bind(source).To(vm => vm.Counters);
            setBindings.Bind(button).To(vm => vm.GoToNewCounter);
            setBindings.Apply();
        }
    }
}