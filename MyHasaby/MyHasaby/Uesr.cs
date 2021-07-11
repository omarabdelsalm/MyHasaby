using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHasaby
{
    public class User
    {
        readonly SQLiteAsyncConnection _database;

        public User(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Users>().Wait();
        }

        public Task<List<Users>> GetPeopleAsync()
        {
            return _database.Table<Users>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Users person)
        {
            return _database.InsertAsync(person);
        }
    }
}
