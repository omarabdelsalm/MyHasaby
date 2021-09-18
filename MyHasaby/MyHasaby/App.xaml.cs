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
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        public App(string path)
        {
            InitializeComponent();
            DataBasePath = path;
            var db = new SQLiteConnection(_dbpath);

            //var result1 = db.Table<Person>();
            Acontact acontact = new Acontact();
              App.User.SavePersonAsync(new Person
              {
                   ID=1,
                  Name = "omar",
                  Phone = "012048750"
              });
            var result1 = db.Table<Person>().ToList();
            if (result1!= null) {
                 
                if ((from emp in result1 select emp.ID).Count() < 5)// || acontact.ActivSumble==acontact.Regest)
                {
                    MainPage = new ShellPage();

                }
                else if (acontact.ActivSumble == acontact.Regest)
                {
                    App.Current.MainPage= new ShellPage(); ;

                }
                else

                {

                    App.Current.MainPage = new AcontactPage();
                }



            }

            Device.StartTimer(new TimeSpan(0, 0, 60*60*24), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(async() =>
                {
                    // interact with UI elements
                    
                    try
                    {
                        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

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
