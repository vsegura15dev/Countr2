using System;
using Countr2.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Countr2.iOS.Views
{
    public partial class CounterTableViewCell : MvxTableViewCell
    {

        protected CounterTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() => //It delays the binding until view or control was setted
           {
               var bindingSet = this.CreateBindingSet<CounterTableViewCell, CounterViewModel>();

               bindingSet.Bind(CounterName).To(vm => vm.Name);
               bindingSet.Bind(CounterCount).To(vm => vm.Count);
               bindingSet.Bind(IncrementButton).To(vm => vm.IncrementCommand);
               bindingSet.Apply();
           });
        }
    }
}
