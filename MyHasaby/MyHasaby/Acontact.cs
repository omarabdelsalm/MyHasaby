using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyHasaby
{
    public class Acontact:ViewModelBase
    {
        
        private int id;
        [PrimaryKey]
        public int ID { get; set; }
        //                get
        //                {
        //                    return id;
        //                }
        //                  set
        //                    {
        //                        if (id != value)
        //                        {
        //                            id = value;
        //                            OnpropertyChanged("ID");
        //                         }
        //                  }
                

        //}


        //="omar" ;//"omar 1975 moha 1977 ali 1984 bkr 1987";
        private string regest;
        public string Regest
        {
            get
            {
                return regest;
            }
            set
            {
                if (regest != value)
                {
                    regest = value;
                    OnPropertyChanged("Regest");
                }
            }
            
        }

    }
}
