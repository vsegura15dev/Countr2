using System;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Countr2.Core.ViewModels;
namespace Countr2.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<CountersViewModel>();
        }
    }

}
