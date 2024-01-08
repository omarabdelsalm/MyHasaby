using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //صفحة تسجيل ملاك التطبيق على فايربيس
    public partial class CreativePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://myhasaby-default-rtdb.firebaseio.com/");
        public CreativePage()
        {
            InitializeComponent();
           
            string MyImei = DependencyService.Get<IGetDeviceInfo>().GetDeviceID();
            
            TxtMyName.Completed += async (object sender, EventArgs e) =>
            {
                var pers1 = await firebaseHelper.GetPerson(MyImei);

                if (MyImei == pers1.Imei)
                {

                    App.Current.MainPage = new AcontactPage();
                }
                else
                {
                    TxtMyPhon.Focus();
                }

            };
            TxtMyPhon.Completed += async (object sender, EventArgs e) =>
            {
                var pers1 = await firebaseHelper.GetPerson(MyImei);

                if (MyImei == pers1.Imei)
                {

                    App.Current.MainPage = new AcontactPage();
                }

            };

        }

        private async void MyBtn_Clicked(object sender, EventArgs e)
        {
           
            string MyImei = DependencyService.Get<IGetDeviceInfo>().GetDeviceID();
            
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                if (TxtMyName.Text != null && TxtMyPhon.Text != null)
                {
                    TxtMyImei.Text = MyImei;
                    TxtMyevct.Text  = "ah";
                   await firebaseHelper.AddPerson(TxtMyImei.Text, TxtMyName.Text, TxtMyPhon.Text,TxtMyevct.Text);

                    TxtMyName.Text = string.Empty;
                    TxtMyPhon.Text = string.Empty;

                    await DisplayAlert("Success", "Data has been added", "OK");

                 
                 App.Current.MainPage = new AcontactPage();
                }

            }
            else
            {
              await  DisplayAlert("attention", "Please connect to the Internet", "OK");
            }
                  

        }
       
    }
}
