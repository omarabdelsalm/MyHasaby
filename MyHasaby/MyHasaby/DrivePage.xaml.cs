using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivePage : ContentPage
    {
        [Obsolete]
        public DrivePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "people.db3");
                string filename = $"temp{DateTime.Now.ToString("dd-MM-yyyy")}.db3";
                var db = new SQLiteConnection(_dbpath);

                var szRestorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
                db.Backup(szRestorePath, "main");
                var path = Path.Combine(FileSystem.AppDataDirectory, szRestorePath);

                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = "مدير الحسابات",
                    File = new ShareFile(path)
                });

            }
            catch (Exception)
            {
                App.Current.MainPage = new ShellPage();
            }
        }
    }
}