using System;
using System.Threading.Tasks;
using Countr2.Core.Models;
using Countr2.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Countr2.Core.ViewModels
{
    public class CounterViewModel : MvxViewModel<Counter>
    {
        Counter counter;
        CounterService service;
        IMvxNavigationService navigationService;

        public CounterViewModel(CounterService service, IMvxNavigationService navigationService)
        {
            this.service = service;
            this.navigationService = navigationService;
            IncrementCommand = new MvxAsyncCommand(IncrementCounter);
            DeleteCommand = new MvxAsyncCommand(DeleteCounter);

            CreateCommand = new MvxAsyncCommand(CreateCounter);
            CloseCommand = new MvxAsyncCommand(CloseCounter);

        }


        public override void Prepare(Counter counter)
        {
            this.counter = counter;
        }

        public String Name
        {
            get { return counter.Name; }
            set
            {
                if (Name == value) return;
                counter.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Count => counter.Count;

        public IMvxAsyncCommand IncrementCommand { get; }


        async Task IncrementCounter()
        {

            await service.IncrementCounter(counter);
            RaisePropertyChanged(() => Count);
        }

        public IMvxAsyncCommand DeleteCommand { get; }

        async Task DeleteCounter()
        {
            await service.DeleteCounter(counter);
        }

        public IMvxAsyncCommand CreateCommand { get; }

        public IMvxAsyncCommand CloseCommand { get; }


        async Task CreateCounter()
        {
            await service.AddNewCounter(Name).ConfigureAwait(false);
            await navigationService.Close(this);
        }

        async Task CloseCounter()
        {
            await navigationService.Close(this);
        }
    }
}