using System;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using Countr2.Core.Services;
using MvvmCross.Plugin.Messenger;
using MvvmCross.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Countr2.Core.Models;

namespace Countr2.Core.ViewModels
{
    public class CountersViewModel: MvxViewModel
    {
        readonly CounterService service;
        readonly MvxSubscriptionToken token;
        readonly IMvxNavigationService navigationService;

        public CountersViewModel(CounterService service, IMvxMessenger messenger,
            IMvxNavigationService navigationService)
        {
            this.service = service;
            Counters = new ObservableCollection<CounterViewModel>();
            token = messenger.SubscribeOnMainThread<CountersChangedMessage>
                (async m => await LoadCounters());
            this.navigationService = navigationService;
            GoToNewCounter = new MvxAsyncCommand(ToNewCounterViewModel);

        }

        public ObservableCollection<CounterViewModel> Counters
        {
            get;
        }

        public override async Task Initialize()
        {
            await LoadCounters();
        }

        public async Task LoadCounters()
        {

            Counters.Clear();

            var counters = await service.GetAllCounter();

            counters.ForEach(it =>
            {

                var viewModel = new CounterViewModel(service, navigationService);
                viewModel.Prepare(it);
                Counters.Add(viewModel);
            });
        }


        public IMvxAsyncCommand GoToNewCounter { get; }


        async Task ToNewCounterViewModel()
        {
            await navigationService.Navigate(typeof(CounterViewModel), new Counter());
        }


    }
}
