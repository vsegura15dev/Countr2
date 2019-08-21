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

        [TestFixture]
        public class CounterViewModelTests
        {

            Mock<CounterService> counterService;
            CounterViewModel counterViewModel;
            Mock<IMvxNavigationService> navigationService;


            [SetUp]
            public void SetUp()
            {
                counterService = new Mock<CounterService>();
                navigationService = new Mock<IMvxNavigationService>();
                counterViewModel = new CounterViewModel(counterService.Object, navigationService.Object);
                counterViewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);

            }

            [Test]
            public void VerifyNameProperty()
            {
                var counter = new Counter { Name = "Counter 1" };

                counterViewModel.Prepare(counter);
                Assert.AreEqual(counter.Name, counterViewModel.Name);

            }

            [Test]
            public void VerifyTriggeredNameSettedEvent()
            {

                var counter = new Counter { Name = "Counter 1" };
                counterViewModel.Prepare(counter);

                var propertyChanged = false;

                counterViewModel.PropertyChanged +=
                   (s, e) => propertyChanged = (e.PropertyName == "Name");

                counterViewModel.Name = "Counter 1.1";

                Assert.IsTrue(propertyChanged);
            }

            [Test]
            public async Task IncrementCounter()
            {
                await counterViewModel.IncrementCommand.ExecuteAsync();

                counterService.Verify(s => s.IncrementCounter(It.IsAny<Counter>()));
            }


            [Test]
            public async Task IncrementCounterTriggerEvent()
            {

                var propertyChanged = false;

                counterViewModel.PropertyChanged +=
                   (s, e) => propertyChanged = (e.PropertyName == "Count");

                await counterViewModel.IncrementCommand.ExecuteAsync();

                Assert.IsTrue(propertyChanged);
            }


            [Test]
            public async Task DeleteCounter()
            {
                await counterViewModel.DeleteCommand.ExecuteAsync();

                counterService.Verify(s => s.DeleteCounter(It.IsAny<Counter>()));
            }



            [Test]
            public async Task CreateCounter()
            {

                var counter = new Counter { Name = "Counter 1" };
                counterViewModel.Prepare(counter);

                await counterViewModel.CreateCommand.ExecuteAsync();
                counterService.Verify(s => s.AddNewCounter(It.IsAny<String>()));
                navigationService.Verify(n => n.Close(counterViewModel, It.IsAny<System.Threading.CancellationToken>()));

            }

            [Test]
            public async Task CloseCounter()
            {

                var counter = new Counter { Name = "Counter 1" };
                counterViewModel.Prepare(counter);
                await counterViewModel.CloseCommand.ExecuteAsync();

                counterService.Verify(s => s.AddNewCounter(It.IsAny<String>()), Times.Never());
                navigationService.Verify(n => n.Close(counterViewModel, It.IsAny<System.Threading.CancellationToken>()));
            }
        }
}
