using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
namespace MyHasaby
{
    public partial class App : Application
    {
       
        static Database database;
        static Uesrs database1;
        static AcountUes useAcount;

        public static AcountUes acountUes
        {
            get
            {
                if (useAcount == null)
                {
                    useAcount = new AcountUes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return useAcount;
            }
        }
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
        public static Uesrs User1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new Uesrs(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database1;
            }
        }
        public static string DataBasePath;
       
        public App(string path)
        {
            InitializeComponent();
            DataBasePath = path;
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

            var db = new SQLiteConnection(_dbpath);
           
            if (Settings.FirstRun)
            {
                  Person person = new Person();
                if (person.ID == 0) { Settings.FirstRun = true; }
                    App.Current.MainPage = new ShellPage();
                Settings.FirstRun = false;
            }
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>

           {


               var result1 = db.Table<Person>().ToList();
               
               var anass2 = App.User.GetPeopleAsync();
               var all2 = anass2.Result.Count();
               var all = (from emp in result1.AsEnumerable() select emp.ID).Count();
               var ally = App.acountUes.GetAcontactAsync().Result;
               var alhmed = ally.Count();

               if (all2 <= 3)
               { MainPage = new ShellPage(); }
               else if (alhmed!=0) {
                   
                   App.Current.MainPage = new ShellPage();


                 
               }
               else {

                   MainPage = new AcontactPage();
               }
           });


        }


        protected override void OnStart()
        {
            AppCenter.Start("android=da69d854-852d-4015-ab4b-05708425857a;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics),
                   typeof(Crashes));
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {

        }
    }
}
