using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyHasaby
{
   public class Acontact: ViewModelBase
    {
        [PrimaryKey, AutoIncrement]
        private int id { get; set; } = 1;
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
        private string activSumble { get; set; }
        public string ActivSumble
        {
            set
            {
                if (activSumble != value)
                {
                    activSumble = value;
                    OnpropertyChanged("ActivSumble");
                }
            }
            get
            {
                return activSumble;
            }


        }
        //="omar" ;//"omar 1975 moha 1977 ali 1984 bkr 1987";
        private string regest { get; set; } 
        public string Regest {
            set
            {
                if (regest != value)
                {
                    regest = value;
                    OnpropertyChanged("Regest");
                }
            }
            get
            {
                return regest;
            }
        }
    }
}
