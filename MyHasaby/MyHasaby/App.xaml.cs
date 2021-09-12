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
        public  App(string path)
        {
            InitializeComponent();
            DataBasePath = path;

            //MainPage = new NavigationPage(new DisblayAllPage());
            List<Person> perlist = new List<Person>();
            int all = (from per in perlist.AsEnumerable() select per.ID).Count();
            if (all == 5) 
            { MainPage = new ShellPage(); }
            else
            {
                MainPage = new NavigationPage(new AcontactPage());
                // System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
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
