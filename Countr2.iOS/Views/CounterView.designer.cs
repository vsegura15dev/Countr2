﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Countr2.iOS.Views
{
    [Register ("CounterView")]
    partial class CounterView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CounterName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CounterName != null) {
                CounterName.Dispose ();
                CounterName = null;
            }
        }
    }
}