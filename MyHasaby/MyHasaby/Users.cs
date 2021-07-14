using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace MyHasaby
{
   public class Users
    {
       
        [Indexed]
        public int PersonId { get; set; }
        public int Dane { get; set; }
        public int Mdan { get; set; }
        
        //public int Egmaly()
        //{
        //    string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        //    var db = new SQLiteConnection(_dbpath);
        //    var ent = db.ExecuteScalar<int>("SELECT SUM(Dane) FROM Users WHERE Dane > 0");
        //    var entModan = db.ExecuteScalar<int>("SELECT SUM(Mdan) FROM Users WHERE Mdan > 0");
        //    var egmaly = ent - entModan;
        //    return egmaly;
        //}

    }
}
