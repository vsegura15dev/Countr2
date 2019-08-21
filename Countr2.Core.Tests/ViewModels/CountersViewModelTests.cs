using System;
using Countr2.Core.Services;
using Countr2.Core.ViewModels;
using Moq;
using NUnit.Framework;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using System.Threading.Tasks;
using System.Collections.Generic;
using Countr2.Core.Models;

namespace Countr2.Core.Tests.ViewModels
{
    public class CountersViewModelTests
    {

        Mock<CounterService> counterService;
        Mock<IMvxMessenger> messenger;
        Mock<IMvxNavigationService> navigationService;
        CountersViewModel viewModel;
        Action<CountersChangedMessage> publishAction;


        [SetUp]
        public void SetUp()
        {
            counterService = new Mock<CounterService>();
            messenger = new Mock<IMvxMessenger>();
            navigationService = new Mock<IMvxNavigationService>();
            messenger.Setup(m => m.SubscribeOnMainThread(
             It.IsAny<Action<CountersChangedMessage>>(),
             It.IsAny<MvxReference>(), It.IsAny<string>()))
             .Callback<Action<CountersChangedMessage>, MvxReference, string>(
             (action, reference, value) => publishAction = action);
            viewModel = new CountersViewModel(counterService.Object, messenger.Object, navigationService.Object);

        }

        [Test]
        public async Task LoadCounters()
        {

            var counters = new List<Counter>
            {
                new Counter { Name = "Counter 1" , Count = 0},
                new Counter { Name = "Counter 2" , Count = 4}
            };

            counterService.Setup(s => s.GetAllCounter()).ReturnsAsync(counters);

            await viewModel.LoadCounters();

            Assert.AreEqual(2, viewModel.Counters.Count);
            Assert.AreEqual("Counter 1", viewModel.Counters[0].Name);
            Assert.AreEqual("Counter 2", viewModel.Counters[1].Name);
            Assert.AreEqual(0, viewModel.Counters[0].Count);
            Assert.AreEqual(4, viewModel.Counters[1].Count);
        }

        [Test]
        public void LoadMessageReceivedMessage()
        {
            counterService.Setup(s => s.GetAllCounter()).ReturnsAsync(new List<Counter>());

            publishAction.Invoke(new CountersChangedMessage(this));

            counterService.Verify(s => s.GetAllCounter());
        }

        [Test]
        public async Task GoToNewCounter()
        {
            await viewModel.GoToNewCounter.ExecuteAsync();

            navigationService.Verify(n => n.Navigate(typeof(CounterViewModel),
                It.IsAny<Counter>(), null, It.IsAny<System.Threading.CancellationToken>()));
        }
    }
}
