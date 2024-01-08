using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MyHasaby.Categories.Data
{

    public class Categories1
    {
        readonly SQLiteAsyncConnection _database;

        public Categories1(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Categor>().Wait(); 
            _database.CreateTableAsync<TafselCategory>().Wait(); 
        }
        public Task<List<Categor>> GetPeopleAsync()
        {
            return _database.Table<Categor>().ToListAsync();
        }
        public Task<List<TafselCategory>> GetTafselCategoryAsync()
        {
            return _database.Table<TafselCategory>().ToListAsync();
        }
        public Task<int> SaveCategorAsync(Categor users)
        {
            
            return _database.InsertAsync(users);

        }
        public Task<int> UpdateCategorAsync(Categor users)
        {
            
                return _database.UpdateAsync(users);
             }
        public Task<int> UpdateTafselCategoryAsync(TafselCategory use)
        {

            return _database.UpdateAsync(use);
       }
          public Task<int> SaveTafselCategoryAsync(TafselCategory use)
        {
            if (use.ID != 0) { return _database.UpdateAsync(use); }
            else { return _database.InsertAsync(use); }

        }
        public Task<Categor> GetItemAsync(int personId1)
        {

            return _database.Table<Categor>().Where(i => i.ID == personId1).FirstOrDefaultAsync();
        }
        public Task<TafselCategory> GetItem1Async(int personId)
        {

            return _database.Table<TafselCategory>().Where(i => i.ID == personId).FirstOrDefaultAsync();
        }
        public async Task<int> DeleteItemCatAsync(Categor users)
        {
            return await _database.DeleteAsync(users);
        }
        public async Task<int> DeleteItemtafAsync(TafselCategory users)
        {
            return await _database.DeleteAsync(users);
        }
    }
}
