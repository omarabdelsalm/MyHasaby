using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyHasaby
{
   public class AcountUes
    {

        readonly SQLiteAsyncConnection _database;

        public AcountUes(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Acontact>().Wait();
        }

        public Task<List<Acontact>> GetPeopleAsync()
        {
            return _database.Table<Acontact>().ToListAsync();
        }
        public Task<Acontact> GetItemAsync(int personId1)
        {

            return _database.Table<Acontact>().Where(i => i.ID == personId1).FirstOrDefaultAsync();
        }
        public Task<int> SavePersonAsync(Acontact person)
        {
            if (person.ID != 0)
            {
                return _database.UpdateAsync(person);
            }
            else
            {
                return _database.InsertAsync(person);
            }
        }
        

        //readonly SQLiteAsyncConnection database;
        //SQLiteAsyncConnection db;
        //public AcountUes(string dbPath)
        //{

        //        db = new SQLiteAsyncConnection(dbPath);
        //        db.CreateTableAsync<Acontact>().Wait();


        //}

        //public Task<int> SaveAcontactAsync(Acontact acontact)
        //{


        //        return db.InsertAsync(acontact);

        //}

    }
}
