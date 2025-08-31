using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHasaby
{
    public class Uesrs 
    {
        readonly SQLiteAsyncConnection _database;

        public Uesrs(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Users>().Wait(); //EgmalyDanMden
            _database.CreateTableAsync<EgmalyDanMden>().Wait(); //EgmalyDanMden  Acontact
            _database.CreateTableAsync<TradersClass>().Wait(); //TradersClass
            _database.CreateTableAsync<SubTraderClass>().Wait(); //subTraderClass
 }

        public Task<List<Users>> GetPeopleAsync()
        {
            return _database.Table<Users>().ToListAsync();
        }
        public Task<List<TradersClass>> GetTradersAsync()
        {
            return _database.Table<TradersClass>().ToListAsync();
        }

        public Task<List<SubTraderClass>> GetSubTradersAsync()
        {
            return _database.Table<SubTraderClass>().ToListAsync();
        }




        public Task<List<EgmalyDanMden>> GetEgmayAsync()
        {
            return _database.Table<EgmalyDanMden>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Users users)
        {
            
            return _database.InsertAsync(users); 
           
        }

        public Task<int> SaveTraderAsync(TradersClass trade)
        {
            if (trade.ID != 0)
            {
                return _database.UpdateAsync(trade);
            }

            return _database.InsertAsync(trade);

        }
        public Task<int> SaveSubTraderAsync(SubTraderClass trades)
        {
            if (trades.ID != 0)
            {
                return _database.UpdateAsync(trades);
            }

            return _database.InsertAsync(trades);

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

        public Task<TradersClass> GetItemtrederAsync(int personId1)
        {

            return _database.Table<TradersClass>().Where(i => i.ID == personId1).FirstOrDefaultAsync();
        }
        public Task<SubTraderClass> GetItemSubtrederAsync(int personId1)
        {

            return _database.Table<SubTraderClass>().Where(i => i.ID == personId1).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteItemAsync(Users users)
        {
            return await _database.DeleteAsync(users);
        }
        public async Task<int> DeleteItemAsync(EgmalyDanMden users)
        {
            return await _database.DeleteAsync(users);
        }

        public async Task<int> DeleteItemTradAsync(TradersClass users)
        {
            return await _database.DeleteAsync(users);
        }
        public async Task<int> DeleteItemSubTradAsync(SubTraderClass users)
        {
            return await _database.DeleteAsync(users);
        }
    }
}
