using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Countr2.Core.Models;
using SQLite;

namespace Countr2.Core.Repositories
{
    public class CounterSQLiteRepository: CounterRepository
    {

        readonly SQLiteAsyncConnection connection;
        readonly string databaseFileName = "counters.db3";

        public CounterSQLiteRepository()
        {

            var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var databaseFilePath = Path.Combine(localFolder, databaseFileName);
            connection = new SQLiteAsyncConnection(databaseFilePath);
            connection.GetConnection().CreateTable<Counter>();
        }

        public Task Save(Counter counter)
        {
            return connection.InsertOrReplaceAsync(counter);
        }

        public Task<List<Counter>> GetAll()
        {
            return connection.Table<Counter>().ToListAsync();
        }

        public Task Delete(Counter counter)
        {
            return connection.DeleteAsync(counter);
        }
    }
}
