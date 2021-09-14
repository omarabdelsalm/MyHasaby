using MyHasaby.Views;
using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace MyHasaby
{
    public partial class App : Application
    {
       
        static Database database;
        static Uesr database1;
        public static Database User
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }
        public static Uesr User1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new Uesr(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database1;
            }
        }
        public static string DataBasePath;
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        public App(string path)
        {
            InitializeComponent();
            DataBasePath = path;
            var db = new SQLiteConnection(_dbpath);

            //var result = db.Table<Users>().ToList();

            //foreach (var item in result.GroupBy(x => x.PersonId).ToList())
            //{
            //    var Dane = result.Where(x => x.PersonId == item.Key).Select(x => x.PersonId).Count();
            var result1 = db.Table<Users>();

            var all = (from emp in result1.AsEnumerable() select emp.Dane).Count();

            if (all >= 5)

                {
                    //MainPage = new NavigationPage(new AcontactPage());
                    App.Current.MainPage = new AcontactPage();
                }//MainPage = new ShellPage(); 
                else
                {
                    MainPage = new ShellPage();
                    
                }
                //MainPage = new ShellPage();
            
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
