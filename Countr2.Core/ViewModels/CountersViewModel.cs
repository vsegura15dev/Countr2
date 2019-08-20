using System;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
namespace Countr2.Core.ViewModels
{
    public class CountersViewModel: MvxViewModel
    {
        string hello = "Hello MvvmCross";

        public String Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

    }
}
