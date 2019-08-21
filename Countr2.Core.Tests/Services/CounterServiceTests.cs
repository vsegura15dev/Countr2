using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Countr2.Core.Models;
using Countr2.Core.Repositories;
using Countr2.Core.Services;
using Moq;
using MvvmCross.Plugin.Messenger;
using NUnit.Framework;

namespace Countr2.Core.Tests.Services
{
    [TestFixture]
    public class CounterServiceTests
    {
        Mock<CounterRepository> mockRepository;
        Mock<IMvxMessenger> mockMessenger;
        CounterService service;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<CounterRepository>();
            mockMessenger = new Mock<IMvxMessenger>();
            service = new BaseCounterService(mockRepository.Object, mockMessenger.Object);
        }

        [Test]
        public async Task CounterWasIncremented()
        {
            var counter = new Counter();
            await service.IncrementCounter(counter);
            Assert.AreEqual(counter.Count, 1);
        }

        [Test]
        public async Task CounterIncrementedWasSaved()
        {
            var counter = new Counter();
            await service.IncrementCounter(counter);
            mockRepository.Verify(r => r.Save(It.Is<Counter>(c => c.Count == 1)), Times.Once());
        }

        [Test]
        public async Task VerifyCounterAreTheSameThatReturned()
        {
            var counters = new List<Counter>
            {
                new Counter {Name = "Running"},
                new Counter {Name = "Walking"},

            };

            mockRepository.Setup(r => r.GetAll()).ReturnsAsync(counters);
            var result = await service.GetAllCounter();
            CollectionAssert.AreEqual(result, counters);

        }


        [Test]
        public async Task PublishMessageOfDelete()
        {

            await service.DeleteCounter(new Counter());
            mockMessenger.Verify(m => m.Publish(It.IsAny<CountersChangedMessage>()));
        }
    }
}
