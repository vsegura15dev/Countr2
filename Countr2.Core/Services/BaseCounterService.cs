using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Countr2.Core.Models;
using Countr2.Core.Repositories;
using MvvmCross.Plugin.Messenger;

namespace Countr2.Core.Services
{
    public class BaseCounterService: CounterService
    {
        readonly CounterRepository repository;
        readonly IMvxMessenger messenger;

        public BaseCounterService(CounterRepository repository, IMvxMessenger messenger)
        {
            this.repository = repository;
            this.messenger = messenger;
        }

        public async Task<Counter> AddNewCounter(string name)
        {
            var counter = new Counter { Name = name };

            /* ConfigureAwait es para que el código posterior,
             * se ejecute en el mismo background thread.
             * Task<*> o Task, ya se ejecuta en un hilo background pero
             * en caso dentro de un método, lo último ó único que se ejecuta
             * es Task, es más practico que devuelva es Task (cómo en el caso de DeleteCounter o GetAllCounter)
             * */
            await repository.Save(counter).ConfigureAwait(false);
            messenger.Publish(new CountersChangedMessage(this));
            return counter;
        }

        public async Task DeleteCounter(Counter counter)
        {
            await repository.Delete(counter).ConfigureAwait(false);
            messenger.Publish(new CountersChangedMessage(this));
        }

        public Task<List<Counter>> GetAllCounter()
        {
            return repository.GetAll();
        }

        public Task IncrementCounter(Counter counter)
        {
            counter.Count += 1;
            return repository.Save(counter);
        }
    }
}
