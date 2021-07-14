using SQLite;
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
    public partial class AddData : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        
        public  AddData(int id, string name) {
            InitializeComponent();

            txtname.Text = name;
            txtid.Text = id.ToString();
            BtnDane.Clicked += BtnDane_Clicked;//له
            BtnMdane.Clicked += BtnMdane_Clicked;//علية
        }
       
        
    private async void BtnMdane_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TexDane.Text) && !string.IsNullOrWhiteSpace(txtid.Text))
            {
                await App.User1.SavePersonAsync(new Users
                {
                    Dane = Convert.ToInt32(TexDane.Text),
                    PersonId = Convert.ToInt32(txtid.Text)
                });
                await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");
                await Navigation.PopAsync();
                TexDane.Text = txtid.Text = string.Empty;
            }
        }

        private async void BtnDane_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TexDane.Text))// && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.User1.SavePersonAsync(new Users
                {
                    Mdan = Convert.ToInt32(TexDane.Text),
                    PersonId = Convert.ToInt32(txtid.Text)
                });
                await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");
                await Navigation.PopAsync();

                TexDane.Text = txtid.Text = string.Empty;
            }
        }
    }
}