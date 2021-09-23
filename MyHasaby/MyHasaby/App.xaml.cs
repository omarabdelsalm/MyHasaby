using MyHasaby.Views;
using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace MyHasaby
{
    public partial class App : Application
    {
       
        static Database database;
        static Uesr database1;
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

        public App(string path)
        {
            InitializeComponent();
            DataBasePath = path;
            // using (var db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"), true))
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

            var db = new SQLiteConnection(_dbpath);

            if (Settings.FirstRun)
            {
                // Perform an action such as a "Pop-Up".

                //App.Current.MainPage.DisplayAlert("رجاء", "كتابة عميل علي الاقل حتى يعمل التطبيق معك", "");
                Person person = new Person();
                if (person.ID == 0) { Settings.FirstRun = true; }
                    App.Current.MainPage = new ShellPage();
                Settings.FirstRun = false;
            }
            Device.BeginInvokeOnMainThread( () =>

            {
                Person person = new Person();
                if (person != null)
                {
                    //if (person.ID <= 0) { App.Current.MainPage = new ShellPage(); }
                    Acontact acontact = new Acontact();

                    var result1 = db.Table<Person>();//.ToList();


                    var all = (from emp in result1 select emp.ID).Count(); //(from emp in result1 select emp.ID).Count();
                    if (all <= 5)// || acontact.ActivSumble==acontact.Regest)
                    {

                        App.Current.MainPage = new ShellPage();

                    }
                    else if (acontact.Regest == "omar 1975 moha 1977 ali 1984 bkr 1987")//acontact.ActivSumble == acontact.Regest)
                    {
                        App.Current.MainPage = new ShellPage();

                    }
                    else

                    {

                        App.Current.MainPage = new AcontactPage();
                    }

                }
                
                

            });



            


           

            Device.StartTimer(new TimeSpan(0, 0, 60*60*12), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(async() =>
                {
                    // interact with UI elements
                    
                    try
                    {
                       // string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                       // var db=new SQLiteConnection();
                        var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                        var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                       // var db = new SQLiteConnection(_dbpath);
                        string docFolder = Path.Combine(System.Environment.GetFolderPath
                             (System.Environment.SpecialFolder.MyDocuments), "logs");
                        string szRestorePath = "/storage/emulated/0/Android/datacom.alshobky.myhasaby/files/logs/temp.db3";
                        string libFolder = Path.Combine(docFolder, szRestorePath);
                        if (!Directory.Exists(libFolder))
                        {
                            Directory.CreateDirectory(libFolder);
                        }


                        string destinationDatabasePath = Path.Combine(libFolder, $"temp{DateTime.Now.ToString("dd-yy-mm")}.db3");

                        db.Backup(destinationDatabasePath, "main");



                        await Application.Current.MainPage.DisplayAlert("حفط نسخة احتياطية", "مسار الحفظ Android/datacom.alshobky.myhasaby/files/logs/temp.db3", "OK");
                        return;
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("محاولة مرةاخرى", "no", "om");

                    }

                });
                return true; // runs again, or false to stop
            });


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
