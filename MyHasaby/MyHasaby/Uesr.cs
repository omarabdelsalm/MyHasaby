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
            _database.CreateTableAsync<Users>().Wait(); //EgmalyDanMden
            _database.CreateTableAsync<EgmalyDanMden>().Wait(); //EgmalyDanMden  Acontact

           

        }

        

        public Task<List<Users>> GetPeopleAsync()
        {
            return _database.Table<Users>().ToListAsync();
        }
        public Task<List<EgmalyDanMden>> GetEgmayAsync()
        {
            return _database.Table<EgmalyDanMden>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Users users)
        {
            
            return _database.InsertAsync(users);
			
        }

        public Task<int> SaveEgmalyAsync(EgmalyDanMden use)
        {

            
            return _database.InsertAsync(use);


        }
        public Task<Users> GetItemAsync(int personId1)
        {
            
            return _database.Table<Users>().Where(i => i.PersonId == personId1).FirstOrDefaultAsync();
        }
        public Task<EgmalyDanMden> GetAsync(int personId)
        {

            return _database.Table<EgmalyDanMden>().Where(i => i.ID == personId).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteItemAsync(Users users)
        {
            return await _database.DeleteAsync(users);
        }
        public async Task<int> DeleteItemAsync(EgmalyDanMden users)
        {
            return await _database.DeleteAsync(users);
        }
    }
}
