using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisblayAllPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        //public ObservableCollection<EgmalyDanMden> List { get; set; } = new ObservableCollection<EgmalyDanMden>();

        public DisblayAllPage()
        {
            InitializeComponent();


            var db = new SQLiteConnection(_dbpath);
            _listView.ItemsSource = db.Table<EgmalyDanMden>().OrderBy(x => x.PersonId).ToList();
            
           

        }
        

    }
}