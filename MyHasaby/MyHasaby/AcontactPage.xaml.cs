using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcontactPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        public AcontactPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Acontact acontact = new Acontact();
            //await App.User1.SavePerson5Async(new Acontact
            //{


            //    ActivSumble = EntAcount.Text

            //});
            //await DisplayAlert("", "adding", "ok");
            // omar 9323 moha 1977 ali 1984 bkr 1987
            if (EntAcount.Text== acontact.ActivSumble)
            {
                 App.Current.MainPage = new ShellPage();//Navigation.PushAsync(new ShellPage());

            }
            else
            {
                await DisplayAlert("عذراً", "عليك تفعيل التطبيق", "Ok");
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }

        }
    }
}