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
            var allPersons =  firebaseHelper.GetAllPersons();
           

        }
        private async void MyBtn_Clicked(object sender, EventArgs e)
        {
           
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                if (TxtMyName.Text != null && TxtMyPhon.Text != null)
                {
                    string MyImei = DependencyService.Get<IGetDeviceInfo>().GetDeviceID();
                    TxtMyImei.Text = MyImei;
                   await firebaseHelper.AddPerson(TxtMyImei.Text, TxtMyName.Text, TxtMyPhon.Text, false);

                    TxtMyName.Text = string.Empty;
                    TxtMyPhon.Text = string.Empty;

                    await DisplayAlert("Success", "تم اضافة البيانات", "OK");

                 await Navigation.PushAsync(new ContentPage());
                  //App.Current.MainPage = new NavigationPage(new ShellPage());
                }

            }
            else
            {
              await  DisplayAlert("انتباه", "الرجاء الاتصال بالانترنت", "ok");
            }
            
           // App.Current.MainPage = new NavigationPage(new ShellPage());

        }
    }
}
