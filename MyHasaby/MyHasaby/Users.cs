using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace MyHasaby
{
    public class Users: ViewModelBase
    {
        public Users(){
            //string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
            //var db = new SQLiteConnection(_dbpath);
            //var ent = db.ExecuteScalar<int>("SELECT SUM(Dane) FROM Users WHERE PersonId=? ",1);
            //var ent1 = db.ExecuteScalar<int>("SELECT SUM(Mdan) FROM Users WHERE PersonId=?",1);

            CreateAt = DateTime.UtcNow;
            
        }
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [Indexed]
       
        public int PersonId { get; set; }
        private int dane;
        public int Dane {
            get { return dane; }

            set {
                if (dane != value) 
                { 
                    dane = value;
                    OnPropertyChanged("Dane");
                }
            } }
        private int mdan;

        public int Mdan {
            get { return mdan; }

            set
            {
                if (mdan != value)
                {
                    mdan = value;
                    OnPropertyChanged("Mdan");
                }
            }
        }
        public DateTime CreateAt { get; set; }
        
       
        public string Nots { get; set; }
  
}
}
