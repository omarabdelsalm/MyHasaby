using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace MyHasaby
{
    public class Users
    {
        public Users(){
            //string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
            //var db = new SQLiteConnection(_dbpath);
            //var ent = db.ExecuteScalar<int>("SELECT SUM(Dane) FROM Users WHERE PersonId=? ",1);
            //var ent1 = db.ExecuteScalar<int>("SELECT SUM(Mdan) FROM Users WHERE PersonId=?",1);

            CreateAt = DateTime.UtcNow;
            
        }
        [Indexed]
        public int PersonId { get; set; }
        public int Dane { get; set; }
        public int Mdan { get; set; }
        public DateTime CreateAt { get; set; }
        
       
        public string Nots { get; set; }
  
}
}
