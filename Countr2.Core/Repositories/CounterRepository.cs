using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Countr2.Core.Models;

namespace Countr2.Core.Repositories
{
    public interface CounterRepository
    {
        Task Save(Counter counter);
        Task<List<Counter>> GetAll();
        Task Delete(Counter counter);
    }
}
