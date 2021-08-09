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
        //private string scope = "https://www.googleapis.com/auth/drive.file";
        //private string clientId = "315539561799-3gjn0admv6pf668blkpn1q0b0amshkvm.apps.googleusercontent.com";
        //private string redirectUrl = "xamarin.test.driverest:/oauth2redirect";



        public Command OnGoogleDrive { get; private set; }

        //public event PropertyChangedEventHandler PropertyChanged;

       // public ICommand OnGoogleDrive { get; set; }
        public DrivePage()
        {
            InitializeComponent();
            BindingContext =new MainViewModel();

        }

    //    private void Button_Clicked(object sender, EventArgs e)
    //    {
    //        DriveHeal();
    //    }
    //    private async Task DriveHeal()
    //    {
    //        var auth = new Xamarin.Auth.OAuth2Authenticator(

    //                     this.clientId,
    //                     string.Empty,
    //                     scope,
    //         new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
    //         new Uri(redirectUrl),
    //         new Uri("https://www.googleapis.com/oauth2/v4/token"),
    //         isUsingNativeUI: true);
    //        AuthenticatorHelper.OAuth2Authenticator = auth;
    //        auth.Completed += async (sender, e) =>
    //        {
    //            if (e.IsAuthenticated)
    //            {

    //                var initializer = new GoogleAuthorizationCodeFlow.Initializer
    //                {
    //                    ClientSecrets = new Google.Apis.Auth.OAuth2.ClientSecrets()
    //                    {
    //                        ClientId = clientId,
    //                    }
    //                };
    //                initializer.Scopes = new[] { scope
    //};
    //                initializer.DataStore = new FileDataStore("Google.Apis.Auth");
    //                var flow = new GoogleAuthorizationCodeFlow(initializer);
    //                var user = "DriveTest";
    //                var token = new TokenResponse()
    //                {
    //                    AccessToken = e.Account.Properties["access_token"],
    //                    ExpiresInSeconds = Convert.ToInt64(e.Account.Properties["expires_in"]),
    //                    RefreshToken = e.Account.Properties["refresh_token"],
    //                    Scope = e.Account.Properties["scope"],
    //                    TokenType = e.Account.Properties["token_type"]
    //                };
    //                UserCredential userCredential = new UserCredential(flow, user, token);
    //                var driveService = new DriveService(new BaseClientService.Initializer()
    //                {
    //                    HttpClientInitializer = userCredential,
    //                    ApplicationName = "my Hasaby",
    //                });


    //                //test google drive
    //                DriveServiceHelper helper = new DriveServiceHelper(driveService);
    //                var id = await helper.CreateFile();
    //                await helper.SaveFile(id, "test", "test save content");
    //                var content = await helper.ReadFile(id);
    //            }
    //        };
    //        auth.Error += (sender, e) =>
    //        {
    //            DisplayAlert("Error", e.Message, "OK");
    //        };

    //        this.OnGoogleDrive = new Command(() =>
    //        {
    //            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
    //            if (presenter != null)
    //                presenter.Login(auth);

    //        });

    //    }

    //    public static class AuthenticatorHelper
    //    {
    //        public static Xamarin.Auth.OAuth2Authenticator OAuth2Authenticator { get; set; }

    //    }


    }
}