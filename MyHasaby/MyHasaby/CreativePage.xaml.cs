using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
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
<<<<<<< HEAD
           
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
            
=======
            var allPersons =  firebaseHelper.GetAllPersons();
           

        }
        private async void MyBtn_Clicked(object sender, EventArgs e)
        {
           
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                if (TxtMyName.Text != null && TxtMyPhon.Text != null)
                {
<<<<<<< HEAD
                    TxtMyImei.Text = MyImei;
                    TxtMyevct.Text  = "ah";
                   await firebaseHelper.AddPerson(TxtMyImei.Text, TxtMyName.Text, TxtMyPhon.Text,TxtMyevct.Text);
=======
                    string MyImei = DependencyService.Get<IGetDeviceInfo>().GetDeviceID();
                    TxtMyImei.Text = MyImei;
                   await firebaseHelper.AddPerson(TxtMyImei.Text, TxtMyName.Text, TxtMyPhon.Text, false);
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b

                    TxtMyName.Text = string.Empty;
                    TxtMyPhon.Text = string.Empty;

                    await DisplayAlert("Success", "تم اضافة البيانات", "OK");

<<<<<<< HEAD
                 
                 App.Current.MainPage = new AcontactPage();
=======
                 await Navigation.PushAsync(new ContentPage());
                  //App.Current.MainPage = new NavigationPage(new ShellPage());
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
                }

            }
            else
            {
              await  DisplayAlert("انتباه", "الرجاء الاتصال بالانترنت", "ok");
            }
<<<<<<< HEAD
                  

        }
       
=======
            
           // App.Current.MainPage = new NavigationPage(new ShellPage());

        }
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
    }
}
