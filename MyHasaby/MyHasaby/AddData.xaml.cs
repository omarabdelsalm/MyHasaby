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
        public int egmaijdaen;
        public int egmaijdaen1;
        public int egmaijdaen2;
        public string name2;
        public  AddData(int id, string name) {
            InitializeComponent();
            name2 = name;
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
                    PersonId = Convert.ToInt32(txtid.Text),
                    Nots= Molhazt.Text
                }) ;
                await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");
                string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

                var db = new SQLiteConnection(_dbpath);
                var PersonId1 = int.Parse(txtid.Text);
                var table = db.Table<Users>().Where(i => i.PersonId == PersonId1);
                foreach (var s in table)
                {
                    var data = s.Dane;
                    egmaijdaen += data;
                    var ModanData = s.Mdan;
                    egmaijdaen1 += ModanData;
                }

                await App.User1.SaveEgmalyAsync(new EgmalyDanMden
                {
                    Name = name2,
                    PersonId = PersonId1,
                    EgDane = egmaijdaen,

                    EgMdan = egmaijdaen1

                });
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
                    PersonId = Convert.ToInt32(txtid.Text),
                    Nots = Molhazt.Text

                });
                await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");
                string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

                var db = new SQLiteConnection(_dbpath);
                var PersonId1 = int.Parse(txtid.Text);
                var table = db.Table<Users>().Where(i => i.PersonId == PersonId1);
                foreach (var s in table)
                {
                    var data = s.Dane;
                    egmaijdaen += data;
                    var ModanData = s.Mdan;

                    egmaijdaen1 += ModanData;
                }

                await App.User1.SaveEgmalyAsync(new EgmalyDanMden
                {
                    Name = name2,
                    PersonId = PersonId1,
                    EgDane = egmaijdaen,

                    EgMdan = egmaijdaen1

                });
                await Navigation.PopAsync();

                TexDane.Text = txtid.Text = string.Empty;
            }
        }
    }
}