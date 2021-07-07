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
        public string Name { get; set; }
        public int Phone { get; set; }

    }
}
