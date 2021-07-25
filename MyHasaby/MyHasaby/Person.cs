using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyHasaby
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250),Unique]
        public string Name { get; set; }
        public long Phone { get; set; }

    }
}
