using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyHasaby
{
   public class Users
    {
       
        [Indexed]
        public int PersonId { get; set; }
        public int Dane { get; set; }
        public int Mdan { get; set; }
       
    }
}
