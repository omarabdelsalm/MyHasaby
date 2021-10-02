using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivePage : ContentPage
    {


        public Command OnGoogleDrive { get; private set; }

        
        public DrivePage()
        {
            InitializeComponent();
            BindingContext =new MainViewModel();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ShellPage();
        }

        


    }
}