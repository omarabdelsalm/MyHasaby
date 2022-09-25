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

       private readonly SQLiteAsyncConnection _database;

        public AcountUes(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Acontact>();
<<<<<<< HEAD
            _database.CreateTableAsync<TestClass>();
        }
        public Task<List<TestClass>> GetAcontactAsync1()
        {
            return _database.Table<TestClass>().ToListAsync();
        }
        
        public Task<TestClass> GetItemAsync1(int personId1)
        {

            return _database.Table<TestClass>().Where(i => i.ID == personId1).FirstOrDefaultAsync();
        }


        public Task<int> SaveAcontactAsync1(TestClass person)
        {

            return _database.InsertAsync(person);

=======
           
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
        }

        public Task<List<Acontact>> GetAcontactAsync()
        {
            return _database.Table<Acontact>().ToListAsync();
        }
        
        public Task<Acontact> GetItemAsync(int personId1)
        {

            return _database.Table<Acontact>().Where(i => i.ID == personId1).FirstOrDefaultAsync();
        }
        
        
        public Task<int> SaveAcontactAsync(Acontact person)
        {
            
                return _database.InsertAsync(person);
           
        }
        

    }
}
