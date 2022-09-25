using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms;
using Plugin.CurrentActivity;
<<<<<<< HEAD

using MyHasaby.Droid;
=======
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b

namespace MyHasaby.Droid
{
    [Activity(Label = "مدير الحسابات", Icon = "@drawable/logoApp", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            string dbName = "SM4U.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderPath, dbName);
            
<<<<<<< HEAD
            

=======
            //LoadApplication(new App());
            this.StartService(new Android.Content.Intent(this, typeof(DemoIntentService)));
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
            base.OnCreate(savedInstanceState);
            
            Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
<<<<<<< HEAD
            this.StartService(new Android.Content.Intent(this, typeof(DemoIntentService)));
=======
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);
            global::Xamarin.Auth.CustomTabsConfiguration.CustomTabsClosingMessage = null;
<<<<<<< HEAD
            //LoadApplication(new App());
=======
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
            
            LoadApplication(new App(fullpath));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}