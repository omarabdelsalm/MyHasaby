using Firebase.Database;
using Plugin.Messaging;
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
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://myhasaby-default-rtdb.firebaseio.com/");
        Acontact acontact = new Acontact();
       
        public AcontactPage()
        {
            InitializeComponent();

            
 
        }

      private  async void Button_Clicked(object sender, EventArgs e)
        {
            string MyImei = DependencyService.Get<IGetDeviceInfo>().GetDeviceID();
            var pers = await firebaseHelper.GetPerson(MyImei);
            if (pers.evect == "omar")
            {
                if (EntAcount.Text == "omar75moh77ali84bkr87")
                {
                    if (!string.IsNullOrEmpty(EntAcount.Text))
                    {


                        Acontact acontact = new Acontact()
                        {

                            Regest = EntAcount.Text
                        };
                        await App.acountUes.SaveAcontactAsync(acontact);
                        await DisplayAlert("تم", "تم اضافة الرمز", "Ok");
                        App.Current.MainPage = new ShellPage();

                    }
                    else
                    {
                        await DisplayAlert("خطا", "قم باعادة الادخال", "Ok");
                        return;
                    }
                }


            }

                        Regest = EntAcount.Text
                    };
                    await App.acountUes.SaveAcontactAsync(acontact);
                    
                    await DisplayAlert("تم", "تم اضافة الرمز", "Ok");
                    App.Current.MainPage = new ShellPage();
                } }
            else
            {
                await DisplayAlert("خطا", "عليك الاتصال بالشركة", "Ok");
            }
        }
      //SmsMessenger
        private void Smsbtn(object sender, EventArgs e)
        {
            // Send Sms
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms("01069160569");
        }
        // Email Messeage
        private void Emlbtn(object sender, EventArgs e)
        {
            
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail("93231975za@gmail.com", "DevSolm", "DevSolm في خدمتكم طاب يومكم بكل خير");

                // Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc.
                var email = new EmailMessageBuilder()
                  .To("93231975za@gmail.com")
                  .Cc("cc.plugins@xamarin.com")
                  .Bcc(new[] { "bcc1.plugins@xamarin.com", "bcc2.plugins@xamarin.com" })
                  .Subject("")
                  .Body("المنار للبرمجيات في خدمتكم طاب يومكم بكل خير")
                  .Build();

                emailMessenger.SendEmail(email);
            }
        }
        // call code
        private void Callbtn(object sender, EventArgs e)
        {
            
            // Make Phone Call
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("01200018116", "bkr alshobky");

        }
        //whatsapp Masseage
        private async void Send(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+2001200018116", "اود شراء التفعيل ");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        
    }
}
