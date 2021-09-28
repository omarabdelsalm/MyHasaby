using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyHasaby
{
    public class Acontact
    {
        
        
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        


        //="omar" ;//"omar 1975 moha 1977 ali 1984 bkr 1987";
      
        public string Regest { get; set; }
        

    }
}
