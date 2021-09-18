using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcontactPage : ContentPage
    {

        //string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        Acontact acontact = new Acontact();
        public AcontactPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Acontact acontact = new Acontact();
            if (EntAcount.Text=="omar")
            {
                await App.acountUes.SaveAcontactAsync(new Acontact
                {
                          ID=1,
                            ActivSumble = "omar",
                           Regest = EntAcount.Text

                }); ;
                await DisplayAlert("تم", "تم اضافة الرمز", "Ok");
            }
            else
            {
                await DisplayAlert("عذراً", "اسف الرمز خطا حاول مرة اخري", "Ok");
                EntAcount.Text = "";
                return;
            }
            
            
            App.Current.MainPage = new ShellPage();

            



        }
    }
}