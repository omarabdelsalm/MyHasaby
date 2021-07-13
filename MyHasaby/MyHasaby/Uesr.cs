using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHasaby
{
    public class Uesr
    {
        readonly SQLiteAsyncConnection _database;

        public Uesr(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Users>().Wait();
        }

        public Task<List<Users>> GetPeopleAsync()
        {
            return _database.Table<Users>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Users users)
        {
            return _database.InsertAsync(users);
        }
        
        public Task<Users> GetItemAsync(int personId1)
        {
            
            return _database.Table<Users>().Where(i => i.PersonId == personId1).FirstOrDefaultAsync();
        }


    }
}
