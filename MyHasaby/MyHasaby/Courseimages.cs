using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyHasaby
{
    
    public class Image
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
       
        public byte[] Content { get; set; }
    }
}
