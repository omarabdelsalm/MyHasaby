   using Android.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;

namespace MyHasaby
{
    [Android.App.Service]

    public class DemoIntentService : Android.App.IntentService
    {
        public DemoIntentService() : base("DemoIntentService")
        {
        }

        // نسخة احتياطية تلقائيا
       
        public override Android.App.StartCommandResult OnStartCommand(Intent intent, Android.App.StartCommandFlags flags, int startId)
        {
            // start a task here
            new Task(() =>
            {
                System.Threading.Thread.Sleep(12*60*60*1000);

                // long running code
                while (true)
                {
                    Version version = DeviceInfo.Version;

                    if (version.Major >= 10)
                    {
                        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");

                        try
                        {
                            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                            Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreateFile(filename);

                        }
                        catch (Exception ex)
                        {
                            string FileName = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";

                            System.Diagnostics.Debug.WriteLine("Failed to get data back from content resolver. Filename: " + FileName);
                            System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                            System.Diagnostics.Debug.Flush();
                            //return false;



                        }
                    }
                    else
                    {
                        try
                        {
                            string _dbpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                            var db = new SQLite.SQLiteConnection(_dbpath);

                            string docFolder = System.IO.Path.Combine(System.Environment.GetFolderPath
                                    (System.Environment.SpecialFolder.MyDocuments), "logs");
                            string szRestorePath = "/storage/emulated/0/Android/datacom.alshobky.myhasaby/files/logs/temp.db3";
                            string libFolder = System.IO.Path.Combine(docFolder, szRestorePath);
                            if (!System.IO.Directory.Exists(libFolder))
                            {
                                System.IO.Directory.CreateDirectory(libFolder);
                            }


                            string destinationDatabasePath = System.IO.Path.Combine(libFolder, $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3");

                            db.Backup(destinationDatabasePath, "main");



                        }
                        catch
                        {
                            string myfile = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                            Xamarin.Forms.DependencyService.Get<IAccessFileService>().CreateFile(myfile);
                        }

                    }

                }
            }).Start();
            return Android.App.StartCommandResult.Sticky;
        }

        protected override void OnHandleIntent(Intent intent)
        {
            
        }
    }
}
