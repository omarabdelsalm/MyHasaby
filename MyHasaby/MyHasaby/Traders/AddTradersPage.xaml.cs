using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby.Traders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTradersPage : ContentPage
    {
        public AddTradersPage()
        {
            InitializeComponent();
        }
            private async void BtnEdite_Clicked(object sender, EventArgs e)
               {
            if (!string.IsNullOrWhiteSpace(EName.Text) && !string.IsNullOrWhiteSpace(ECuntry.Text)&&
                
                !string.IsNullOrWhiteSpace(EPhone.Text)
                )
            {
                await App.User1.SaveTraderAsync(new TradersClass
                {
                    Name = EName.Text,
                    
                    Cuntry = ECuntry.Text,
                    Phone = EPhone.Text
                });
                await DisplayAlert("نجاح", "تم اضافة المورد بنجاح", "Ok");
                
                ECuntry.Text=EPhone.Text=EName.Text=EId.Text = string.Empty;
                await Navigation.PopAsync();
                //return;
                
            }
           
        }

        
    }
}