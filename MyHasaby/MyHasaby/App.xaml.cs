using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using System.Linq;

using MyHasaby.Categories.Data;
using System.Threading.Tasks;
using MyHasaby.Views;

namespace MyHasaby
{
    //new test to solove it
    public partial class App : Application
    {
       
        static Database database;
        static Uesrs database1;
        static AcountUes useAcount;
        static Categories1 categories;

        public static Categories1 User22
        {
            get
            {
                if (categories == null)
                {
                    categories = new Categories1(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return categories;
            }
        }
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

            try
            {

                if (Settings.FirstRun)
                {
                    TestClass person1 = new TestClass();
                    person1.ID = 1;
                    person1.dateTime = DateTime.Now.AddMonths(5);
                    App.acountUes.SaveAcontactAsync1(person1);
                    
                    App.Current.MainPage = new ShellPage();
                    
                }
           
                else
                {
                    DateTime mr = DateTime.Now;

                   
                    var wr = db.Table<TestClass>().OrderBy(c => c.dateTime).FirstOrDefault();
                    DateTime or1 = wr.dateTime;
                    var ally = App.acountUes.GetAcontactAsync().Result;
                    var alhmed = ally.Count();
                    if (mr <= or1)
                    {

                        App.Current.MainPage = new ShellPage();

                    }
                    else if (alhmed != 0)
                    {

                        App.Current.MainPage = new ShellPage();

                    }
                    else
                    {
                        App.Current.MainPage = new CreativePage();

                    }

                }
                
               

            }
            catch (Exception ) {

                App.Current.MainPage = new ShellPage();
            }
                

         






            //try {
            //    if (Settings.FirstRun)
            //    {
            //        TestClass person1 = new TestClass();
            //        person1.ID = 1;
            //        person1.dateTime = DateTime.Now.AddMinutes(5);
            //        App.acountUes.SaveAcontactAsync1(person1);
            //        App.Current.MainPage = new ShellPage();
            //    }
            //    else
            //    {
            //        App.Current.MainPage = new ShellPage();
            //    }
            //}catch (Exception) { return; }


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
