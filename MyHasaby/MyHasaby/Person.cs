using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyHasaby
{
    public class Person :ViewModelBase
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        
        public int ID
        {
            set
            {
                if (id != value)
                {
                    id = value;
                    OnpropertyChanged("ID");
                }
            }
            get
            {
                return id;
            }
        
        }
      
        private string name;
        public string Name
        {
            set
            {
                if (name != value)
                {
                    name = value;
                    OnpropertyChanged("Name");

                }


            }
            get
            {
                return name;

            }

        }
        public string Phone { get; set; }

    }
}
