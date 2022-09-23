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
    public partial class DAllMePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://myhasaby-default-rtdb.firebaseio.com/");
        public DAllMePage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {


            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            
            listview.ItemsSource = allPersons;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {

                await firebaseHelper.UpdatePerson(Eimei.Text, EName.Text, EPhone.Text,Eevect.Text);
                
                await DisplayAlert("Success", "updated", "OK");
            }
            else
            {
                await DisplayAlert("Attention", "الرجاء الاتصال بالانترنت", "ok");
                return;
            }
        }

        private void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var omar = e.SelectedItem as Person1;
            EName.Text = omar.Name;
            Eevect.Text = omar.evect;
            EPhone.Text = omar.MyPhon;
            Eimei.Text = omar.Imei;
        }
    }
}