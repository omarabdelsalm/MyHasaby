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


[assembly: Xamarin.Forms.Dependency(typeof(AccessFileImplement))]
namespace MyHasaby.Droid
{
    //method to get backup file use with android 10 and android 11
    public class AccessFileImplement : IAccessFileService
    {
        
        public void CreateFile(string FileName)
        {

            // //   Permissions.RequestAsync<Permissions.StorageWrite>();
            // //   Permissions.RequestAsync<Permissions.StorageRead>();
            string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");

<<<<<<< HEAD
            try
            {
                File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");
=======
            


            


            try
            {

                File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");


>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
                var isfolder = false;
                if (!folder.Exists())
                {
                    isfolder = folder.Mkdir();
                }
                string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                string destinationDatabasePath = Path.Combine(folder.ToString(), filename);
                var db = new SQLiteConnection(_dbpath);
                db.Backup(destinationDatabasePath, "main");
<<<<<<< HEAD
=======


>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to get data back from content resolver. Filename: " + FileName);
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                System.Diagnostics.Debug.Flush();
                //return false;



            }

        }
<<<<<<< HEAD
    //function to make backup for android 11
        public string CreateFile1()
        {
            
                // Do things the Lollipop way
                string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");

            File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");

            var isfolder = false;
                if (!folder.Exists())
                {
                    isfolder = folder.Mkdir();
                }
                // var file = FilePicker.PickAsync();

                string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                string destinationDatabasePath = Path.Combine(folder.ToString(), filename);

                return destinationDatabasePath;
           
  }
        //function to make backup for android 11

=======

        public string CreateFile1()
        {
            string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");
            
            File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");



            var isfolder = false;
            if (!folder.Exists())
            {
                isfolder = folder.Mkdir();
            }
           // var file = FilePicker.PickAsync();

            
            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            string destinationDatabasePath = Path.Combine(folder.ToString(), filename);


            return destinationDatabasePath;



        }
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
        public string copy()
        {
            string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");

<<<<<<< HEAD
            File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("Download") + "/" + "Myhasaby");
            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            string destinationDatabasePath = Path.Combine(folder.ToString(), filename);
              return destinationDatabasePath;
          }
       
 
=======
            File folder = new File(Android.OS.Environment.GetExternalStoragePublicDirectory("/Download/") + "/" + "Myhasaby");


            
              
           
            string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
            string destinationDatabasePath = Path.Combine(folder.ToString(), filename);


            return folder.ToString();


        }

>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
    }

}