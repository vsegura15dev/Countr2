using System;
using Countr2.Core.ViewModels;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Countr2.iOS.Views
{
    public class CountersTableViewSource : MvxTableViewSource
    {
        public CountersTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return (CounterTableViewCell)tableView.DequeueReusableCell("CounterCell");
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle,
            NSIndexPath indexPath)
        {

            var counter = (CounterViewModel)GetItemAt(indexPath);
            counter.DeleteCommand.Execute();
        }
    }
}
