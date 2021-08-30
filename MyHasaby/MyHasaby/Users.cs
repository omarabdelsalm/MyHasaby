using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace MyHasaby
{
    public class Users
    {
        public Users(){
             CreateAt = DateTime.Now;
            }
        [Indexed]
        public int PersonId { get; set; }
        public int Dane { get; set; }
        public int Mdan { get; set; }
        public DateTime CreateAt { get; set; }

        public string Nots { get; set; }
    }
}
