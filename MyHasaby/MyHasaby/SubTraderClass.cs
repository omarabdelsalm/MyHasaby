using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHasaby
{
   public class SubTraderClass: ViewModelBase
    {
       
        public SubTraderClass()
        {
            DateTime aDate = DateTime.Now;
            CreateAt = aDate.Date.ToString("dd,MM,yyy");

        }
        private int id;
        private int traderID;
        private int dafee;
        private int alih;
        private int egdafee;
        private int egalih;
       
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        [Indexed]
        public int TraderID {

            get { return traderID; }
            set
            {
                if (traderID != value)
                {
                    traderID = value;
                    OnPropertyChanged("TraderID");
                }
            }


        }


        public int Dafee
        {
            get { return dafee; }
            set
            {
                if (dafee != value)
                {
                    dafee = value;
                    OnPropertyChanged("Dafee");
                }
            }


        }
        public int Alih
        {

            get { return alih; }
            set
            {
                if (alih != value)
                {
                    alih = value;
                    OnPropertyChanged("Alih");
                }
            }


        }

        public int EgDafee
        {
            get { return egdafee; }
            set
            {
                if (egdafee != value)
                {
                    egdafee = value;
                    OnPropertyChanged("EgDafee");
                }
            }


        }
        public int EgAlih
        {

            get { return egalih; }
            set
            {
                if (egalih != value)
                {
                    egalih = value;
                    OnPropertyChanged("EgAlih");
                }
            }


        }

        public string CreateAt { get; set; }
    }
}
