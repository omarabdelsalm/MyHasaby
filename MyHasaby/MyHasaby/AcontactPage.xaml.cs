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
        Acontact acontact;
        public AcontactPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try{
                //if (EntAcount.Text == "omar 1975 moha 1977 ali 1984 bkr 1987")
                //{
                //if (acontact!=null)
                //{
                //    await App.useAcount.SaveAcontactAsync(new Acontact
                //    {


                //        Regest = EntAcount.Text

                //    });
                //}
                    
                    await DisplayAlert("تم", "تم اضافة الرمز", "Ok");
                    App.Current.MainPage = new ShellPage();

                //}
                //else
                //{
                //    await DisplayAlert("عذراً", "عليك تفعيل التطبيق", "Ok");
                //    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                //}

            }
            catch
            {
                await DisplayAlert("عذراً", "error التطبيق", "Ok");
                return;

            }



        }
    }
}