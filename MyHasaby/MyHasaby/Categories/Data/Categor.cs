using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyHasaby.Categories.Data
{
   
   public class Categor : ViewModelBase
    {
        int id;
        string name;
        //private int id;
        [PrimaryKey, AutoIncrement]

        public int ID
        {
            get
            {
                return id;
            }
            set
            {

                id = value;
                OnPropertyChanged("ID");

            }


        }

        //private string name;
        public string Name
        {
            get
            {
                return name;

            }
            set
            {

                name = value;
                OnPropertyChanged("Name");

            }


        }
    }
}
