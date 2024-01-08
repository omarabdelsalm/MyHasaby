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
            
            CreateAt = DateTime.UtcNow;
            
        }
        
        //public int ID { get; set; }
        private int id;
        [PrimaryKey, AutoIncrement]
        public int ID { 
            get { return id; }
            set {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
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
