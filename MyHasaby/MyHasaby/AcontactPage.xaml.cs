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

        //string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        Acontact acontact = new Acontact();
        public AcontactPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Acontact acontact = new Acontact();
            if (EntAcount.Text== "omar 1975 moha 1977 ali 1984 bkr 1987")
            {
                await App.acountUes.SaveAcontactAsync(new Acontact
                {
                            ID=1,
                            ActivSumble = "omar 1975 moha 1977 ali 1984 bkr 1987",
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

        private void Smsbtn(object sender, EventArgs e)
        {
            // Send Sms
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms("01069160569");
        }

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
                  .Body("ابوبكر في خدمتكم طاب يومكم بكل خير")
                  .Build();

                emailMessenger.SendEmail(email);
            }
        }

        private void Callbtn(object sender, EventArgs e)
        {
            
            // Make Phone Call
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("01069160569", "bkr alshobky");

        }
    }
}