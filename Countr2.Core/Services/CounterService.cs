using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Countr2.Core.Models;

namespace Countr2.Core.Services
{
    public interface CounterService
    {
        Task<Counter> AddNewCounter(string name);
        Task<List<Counter>> GetAllCounter();
        Task DeleteCounter(Counter counter);
        Task IncrementCounter(Counter counter);
    }
}
