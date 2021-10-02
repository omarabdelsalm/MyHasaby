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
            Device.BeginInvokeOnMainThread(() =>

           {


               var result1 = db.Table<Person>().ToList();
               
               var anass2 = App.User.GetPeopleAsync();
               var all2 = anass2.Result.Count();
               var all = (from emp in result1.AsEnumerable() select emp.ID).Count();
               var ally = App.acountUes.GetAcontactAsync().Result;
               var alhmed = ally.Count();

               if (all2 <= 25)
               { MainPage = new ShellPage(); }
               else if (alhmed!=0) {
                   
                   App.Current.MainPage = new ShellPage();


                 
               }
               else {

                   MainPage = new AcontactPage();
               }
           });

                
                    
                
                


            


           

            Device.StartTimer(new TimeSpan(0, 0, 60*60*2), () =>
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
            Device.StartTimer(new TimeSpan(0, 0, 60 * 60 * 6), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // interact with UI elements

                    try
                    {
                        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                        var db = new SQLiteConnection(_dbpath);
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



                        //await Application.Current.MainPage.DisplayAlert("حفط نسخة احتياطية", "مسار الحفظ Android/datacom.alshobky.myhasaby/files/logs/temp.db3", "OK");
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

        protected override void OnResume()
        {
            Device.StartTimer(new TimeSpan(0, 0, 60 * 60 * 6), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // interact with UI elements

                    try
                    {
                        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                        var db = new SQLiteConnection(_dbpath);
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



                        //await Application.Current.MainPage.DisplayAlert("حفط نسخة احتياطية", "مسار الحفظ Android/datacom.alshobky.myhasaby/files/logs/temp.db3", "OK");
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
    }
}
