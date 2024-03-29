﻿using System;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Countr2.Core.ViewModels;
namespace Countr2.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //RegisterCustomAppStart<AppStart>();
            RegisterAppStart<CountersViewModel>();
        }
    }

}
