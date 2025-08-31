using Android;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Java.IO;
using MyHasaby.Droid;
using Plugin.CurrentActivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Android.Provider.SyncStateContract;

using Xamarin.Forms;
using File = Java.IO.File;
using Android.Content.PM;
using Android.Support.V4.App;
using Java.Nio.Channels;
using Environment = Android.OS.Environment;
using Org.Apache.Http.Protocol;

[assembly: Xamarin.Forms.Dependency(typeof(AccessFileImplement))]
namespace MyHasaby.Droid
{
    //method to get backup file use with android 10 and android 11
    public class AccessFileImplement : IAccessFileService
    {
        [Obsolete]
        public void CreateFile(string FileName)
        {


            string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");

            try
            {
                File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");
                var isfolder = false;
                if (!folder.Exists())
                {
                    isfolder = folder.Mkdir();
                }
                string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                string destinationDatabasePath = Path.Combine(folder.ToString(), filename);
                var db = new SQLiteConnection(_dbpath);
                db.Backup(destinationDatabasePath, "main");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to get data back from content resolver. Filename: " + FileName);
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                System.Diagnostics.Debug.Flush();
                //return false;



            }

        }

        // my test to make back up android < 10

        public string CreatFile2(string filename)
        {

            File folder = new File(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.MyDocuments), "logs");

            var isfolder = false;
            if (!folder.Exists())
            {
                isfolder = folder.Mkdir();
            }

            var destinationDatabasePath = Path.Combine((string)folder, "omar");

            return destinationDatabasePath;



        }

        //function to make backup for android 11

        [Obsolete]
        public string CreateFile1()
        {


            File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");




            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            string destinationDatabasePath = Path.Combine(folder.ToString(), filename);

            return destinationDatabasePath;

        }

        //function to make backup for android 11

        [Obsolete]
        public string copy()
        {

            File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("Download") + "/" + "Myhasaby");


            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            string destinationDatabasePath = Path.Combine(folder.ToString(), filename);
            return destinationDatabasePath;
        }

        





    } 

}






























    