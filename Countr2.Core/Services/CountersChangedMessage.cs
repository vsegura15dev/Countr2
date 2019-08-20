using System;
using MvvmCross.Plugin.Messenger;

namespace Countr2.Core.Services
{
    public class CountersChangedMessage: MvxMessage
    {
        public CountersChangedMessage(object sender) : base(sender){ }
    }
}
