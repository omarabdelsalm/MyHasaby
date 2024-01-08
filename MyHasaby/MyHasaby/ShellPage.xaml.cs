
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;
using Org.BouncyCastle.Asn1;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellPage : Shell
    {


        public ShellPage()
        {
            InitializeComponent();

            BindingContext = this;



        }


        // code for backup database

        // code for backup database
        private ICommand backCommand = new Command(async () =>
        {
            Version version = DeviceInfo.Version;
            ShellPage shell = new ShellPage();
            if (version.Major <= 9)
            {

                await shell.Back9();

            }
            else if (version.Major <= 12)
            {
                await shell.Back10();

            }
            else
            {
                await shell.Back12();
            }
        });
        private ICommand reCommand = new Command(async () =>
          {
              ShellPage shell = new ShellPage();
              Version version = DeviceInfo.Version;
              if (version.Major <= 9)
              {
                  try { await shell.Restor1(); } catch {

                      await Application.Current.MainPage.DisplayAlert("Successe", "Restore Database ", "Ok");

                  }

              }
              else if (version.Major <= 12)
              {
                  await shell.Restor();

              }
              else
              {
                  await shell.Restor5();

              }
          });


        // new test to restore 
        public ICommand BackCommand { get => backCommand; set => backCommand = value; }


        public ICommand ReCommand { get => reCommand; set => reCommand = value; }

        private async Task Restor()
        {

            var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();

            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");



            var szRestorePath = Xamarin.Forms.DependencyService.Get<IAccessFileService>().copy();

            if (statusWrite == Xamarin.Essentials.PermissionStatus.Granted && statusRead == Xamarin.Essentials.PermissionStatus.Granted)
            {
                try
                {
                    SQLiteAsyncConnection toMerge;


                    var connection = new SQLiteConnection(_dbpath);


                    // Get our connection to the new database.
                    toMerge = new SQLiteAsyncConnection(szRestorePath);

                    // Save a location to the live database path.
                    string szLiveDBPath = connection.DatabasePath;

                    // Make an insanity check backup.
                    connection.Backup(connection.DatabasePath.Insert(connection.DatabasePath.Length, "OLD"));
                    // Close the existing DB.
                    connection.Close();

                    // Check to make sure we have the backup DB before deleting the active DB
                    if (File.Exists($"{szLiveDBPath}OLD"))
                    {
                        // Delete the active database.
                        File.Delete(szLiveDBPath);

                        // Close the handle to the new DB just to make sure it's not going to gripe about that.
                        await toMerge.CloseAsync().ConfigureAwait(true);

                        // Copy the new one to the location for the "Live" database.
                        File.Copy(toMerge.DatabasePath, szLiveDBPath);

                        // Attempt a connection using the new database file and see if this all worked.
                        connection = new SQLiteConnection(_dbpath);

                        // Enable write ahead (this will also make sure the DB is really connected and so on)
                        connection.EnableWriteAheadLogging();
                        connection.Close();

                        // File delete the temporary backup  file now.
                        File.Delete($"{szLiveDBPath}OLD");
                        await Application.Current.MainPage.DisplayAlert("OK", "Restore Database", "OK");

                        //Quit the application.
                        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Oops");

                }

            }

        }
        private async Task Restor1()
        {

            try
            {

                string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                SQLiteAsyncConnection toMerge;

                string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";

                string szRestorePath = Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreatFile2(filename);
                //string szRestorePath = Path.Combine(folder.ToString(), filename);
                //string szRestorePath = Path.Combine(destinationDatabasePath, filename);
                var connection = new SQLiteConnection(_dbpath);


                var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                if (statusWrite == Xamarin.Essentials.PermissionStatus.Granted && statusRead == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    try
                    {


                        // Get our connection to the new database.
                        toMerge = new SQLiteAsyncConnection(szRestorePath);

                        // Save a location to the live database path.
                        string szLiveDBPath = connection.DatabasePath;

                        // Make an insanity check backup.
                        connection.Backup(connection.DatabasePath.Insert(connection.DatabasePath.Length, "OLD"));
                        // Close the existing DB.
                        connection.Close();

                        // Check to make sure we have the backup DB before deleting the active DB
                        if (File.Exists($"{szLiveDBPath}OLD"))
                        {
                            // Delete the active database.
                            File.Delete(szLiveDBPath);

                            // Close the handle to the new DB just to make sure it's not going to gripe about that.
                            await toMerge.CloseAsync().ConfigureAwait(true);

                            // Copy the new one to the location for the "Live" database.
                            File.Copy(toMerge.DatabasePath, szLiveDBPath);

                            // Attempt a connection using the new database file and see if this all worked.
                            connection = new SQLiteConnection(_dbpath);

                            // Enable write ahead (this will also make sure the DB is really connected and so on)
                            connection.EnableWriteAheadLogging();
                            connection.Close();
                            // File delete the temporary backup  file now.
                            File.Delete($"{szLiveDBPath}OLD");
                            await Application.Current.MainPage.DisplayAlert("OK", "Restore Database", "OK");

                            //Quit the application.
                            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

                        }
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Oops");
                    }

                }
                else
                    throw new Exception("Give the Application the ability to access to storage");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Oops");
            }
        }

        private async Task Restor5()
        {

            var _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3");
            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            string szRestorePath = Path.Combine(_dbpath, dbPath);
            var connection = new SQLiteConnection(_dbpath);
            try
            {

                SQLiteAsyncConnection toMerge;
                // Get our connection to the new database.
                toMerge = new SQLiteAsyncConnection(szRestorePath);

                // Save a location to the live database path.
                string szLiveDBPath = connection.DatabasePath;

                // Make an insanity check backup.
                connection.Backup(connection.DatabasePath.Insert(connection.DatabasePath.Length, "OLD"));
                // Close the existing DB.
                connection.Close();

                // Check to make sure we have the backup DB before deleting the active DB
                if (File.Exists($"{szLiveDBPath}OLD"))
                {
                    // Delete the active database.
                    File.Delete(szLiveDBPath);

                    // Close the handle to the new DB just to make sure it's not going to gripe about that.
                    await toMerge.CloseAsync().ConfigureAwait(true);

                    // Copy the new one to the location for the "Live" database.
                    File.Copy(toMerge.DatabasePath, szLiveDBPath);

                    // Attempt a connection using the new database file and see if this all worked.
                    connection = new SQLiteConnection(_dbpath);
                    
                    // Enable write ahead (this will also make sure the DB is really connected and so on)
                    connection.EnableWriteAheadLogging();
                    connection.Close();
                    // File delete the temporary backup  file now.
                    File.Delete($"{szLiveDBPath}OLD");
                    await Application.Current.MainPage.DisplayAlert("OK", "Restore Database", "OK");

                    //Quit the application.
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Oops");
            }

         
  
        }
        private async Task Back9()
        {
            try {
                string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");
                var db = new SQLiteConnection(_dbpath);
                var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                if (statusWrite == Xamarin.Essentials.PermissionStatus.Granted && statusRead == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";

                    string szRestorePath = Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreatFile2(filename);
                    db.Backup(szRestorePath, "main");

                    await Application.Current.MainPage.DisplayAlert("Successe", "Backup Database" + szRestorePath, "Ok");

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Oops");
            }

            
        }
   
    
        private async Task Back10()
        {
            var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                        
                        // var folder = Xamarin.Forms.DependencyService.Get<IAccessFileService>().copy();


            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";

             Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreateFile(filename);
             await Application.Current.MainPage.DisplayAlert("Successe", "Backup Database", "Ok");
                        

        }

        private async Task Back12()
        {
            string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");
            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            var db = new SQLiteConnection(_dbpath);

            var backupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);

           // File.Copy(dbPath, backupPath);
             
            db.Backup(backupPath, "main");

            await Application.Current.MainPage.DisplayAlert("Successe", "Backup Database", "Ok");


        }

    }


}


    