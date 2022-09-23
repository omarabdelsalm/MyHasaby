using Microsoft.AppCenter.Crashes;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        // string db = new SQLiteConnection(_dbpath);
       
        public ShellPage()
        {
            InitializeComponent();
            
            BindingContext = this;
            
        }


        // code for backup database

        // code for backup database
        private ICommand backCommand = new Command(async () =>
        {

            try
            {
                string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                //var folder = Xamarin.Forms.DependencyService.Get<IAccessFileService>().copy();


              string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                
                Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreateFile(filename);
                await Application.Current.MainPage.DisplayAlert("نجاح", "تم عمل نسخة احتياطية", "Ok");
                return;
  }
            catch (Exception ex)
            {
                

                string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

                var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                var db = new SQLiteConnection(_dbpath);
                string docFolder = Path.Combine(System.Environment.GetFolderPath
                     (System.Environment.SpecialFolder.MyDocuments), "logs");
                string szRestorePath = "/storage/emulated/0/Android/datacom.alshobky.myhasaby/files/logs/temp.db3";
                string libFolder = Path.Combine(docFolder, szRestorePath);
                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }


                string destinationDatabasePath = Path.Combine(libFolder, $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3");

                db.Backup(destinationDatabasePath, "main");
                await Application.Current.MainPage.DisplayAlert("حفط نسخة احتياطية", "مسار الحفظ Android/datacom.alshobky.myhasaby/files/logs/temp.db3", "OK");

        }

        });
        private ICommand reCommand = new Command(async () =>
          {
              ShellPage shell = new ShellPage();
              Version version = DeviceInfo.Version;
              if (version.Major < 10)
              {
                  await shell.Restor1();
              }
              else
              {
                  await shell.Restor();
              }
          });


        public ICommand BackCommand { get => backCommand; set => backCommand = value; }
        public ICommand ReCommand { get => reCommand; set => reCommand = value; }

        private async Task Restor()
        {
            
            

            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                SQLiteAsyncConnection toMerge;

                 var szRestorePath = Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreateFile1();
                //string folder= Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.System)+"/Download/" + "/" + "Myhasaby");
                
                string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
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

                            // File delete the temporary backup  file now.
                           // File.Delete($"{szLiveDBPath}OLD");
                            await Application.Current.MainPage.DisplayAlert("OK", "تم استعادة النسخة الاحتياطية", "OK");
                           
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

                var connection = new SQLiteConnection(_dbpath);
                //var connection = new SQLiteConnection(App.DataBasePath);
                SQLiteAsyncConnection toMerge;

                // Build a string that has the path to where we want the new database file for this procedure.
                //  string szRestorePath = "/storage/emulated/0/Android/data/com.alshobky.myhasaby/files/logs/temp.db3";
                // Check that we have access to be playing with these files.

                string docFolder = Path.Combine(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.MyDocuments), "logs");
                string libFolder = "/storage/emulated/0/Android/datacom.alshobky.myhasaby/files/logs/temp.db3";
                string szRestorePath = Path.Combine(docFolder, libFolder);
                var file = await FilePicker.PickAsync();
                if (file == null) return;
                string filetemp = file.FileName;
                var libFolder1 = file.FullPath;
                szRestorePath = Path.Combine(libFolder, filetemp);

                var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                if (statusWrite == Xamarin.Essentials.PermissionStatus.Granted && statusRead == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    try
                    {
                        if (!File.Exists(szRestorePath))
                        {
                            // Display an alert to let the user know they need to check the file.
                            await Application.Current.MainPage.DisplayAlert("Error", "Restore database not at path", "Oops");

                            // We're done get out of here.
                            return;
                        }

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

                            // File delete the temporary backup  file now.
                            File.Delete($"{szLiveDBPath}OLD");
                            await Application.Current.MainPage.DisplayAlert("OK", "تم استعادة النسخة الاحتياطية", "OK");
                            return;
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



    }
    }
    