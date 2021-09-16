using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHasaby
{
   public class AcountUes
    {

        readonly SQLiteAsyncConnection _database;

        public AcountUes(string dbPath)
        {
            

            _database.CreateTableAsync<Acontact>().Wait();

        }

        public Task<int> SaveAcontactAsync(Acontact acontact)
        {

            return _database.InsertAsync(acontact);

        }
    }
}
