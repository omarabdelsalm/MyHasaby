using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
    
namespace MyHasaby
{
    public class TradersClass : ViewModelBase
    {
        public TradersClass()
        {
            DateTime aDate = DateTime.Now;
            CreateAt = aDate.ToString("dd,MM,yyy");

        }
        private int id;
        private string name;
        private string cuntry;
        private int dafee;
        private int alih;
        private string phone;
        [PrimaryKey,AutoIncrement]
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
        public string Name {
            get { return name; }
            set {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            } }
        public string Cuntry {
            get { return cuntry; }
            set
            {
                if (cuntry != value)
                {
                    cuntry = value;
                    OnPropertyChanged("Cuntry");
                }
            }
        }
        public int Dafee {
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
        public int Alih {

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
        public string Phone {

            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged("Phone");
                }
            }

        }
        public string CreateAt { get; set; }
    }
}
