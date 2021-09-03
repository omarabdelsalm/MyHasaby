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


          
            
           

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<Person>();

            List<EgmalyDanMden> egmalyDanMdens = new List<EgmalyDanMden>();
            var result = db.Table<Users>().ToList();

            foreach (var item in result.GroupBy(x => x.PersonId).ToList())
            {
                var Dane = result.Where(x => x.PersonId == item.Key).Select(x => x.Dane).Sum();
                var mdane = result.Where(x => x.PersonId == item.Key).Select(x => x.Mdan).Sum();
                var personnaleid = item.Key;
                var name = db.Table<Person>().ToList().FirstOrDefault(x => x.ID == item.Key).Name;
                egmalyDanMdens.Add(new EgmalyDanMden
                {
                    EgDane = Dane,
                    EgMdan = mdane,
                    PersonId = personnaleid,
                    Name = name
                });
            }


            _listView.ItemsSource = egmalyDanMdens;
        }

    }
}