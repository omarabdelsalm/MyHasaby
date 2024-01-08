using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyHasaby
{
   
    public class EgmalyDanMden
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int EgDane { get; set; }
        public int EgMdan { get; set; }
        public override string ToString()
        {
            return  this.Name + " " + "     |    "+ this.EgMdan +" " + "    |    " + this.EgDane;
        }
    }
}
