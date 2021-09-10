using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyHasaby
{
    public class Person :ViewModelBase
    {
        [PrimaryKey, AutoIncrement]
        
        public int ID { get; set; }
      
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
