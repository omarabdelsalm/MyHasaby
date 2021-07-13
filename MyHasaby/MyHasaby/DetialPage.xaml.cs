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
    public partial class DetialPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        public DetialPage(int id,String name)
        {
            InitializeComponent();
            txtname.Text = name;
            txtid.Text = id.ToString();
            BtnDane.Clicked += BtnDane_Clicked;//له
            BtnMdane.Clicked += BtnMdane_Clicked;//علية
            var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
            //_listView.ItemsSource = db.Table<Users>().OrderBy(x => x.PersonId).ToList();
            _listView.ItemsSource = db.Table<Users>().Where(i => i.PersonId == PersonId1);//.FirstOrDefaultAsync();
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
               
                TexDane.Text = txtid.Text = string.Empty;
            }
        }

       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteConnection(_dbpath);
           
            var PersonId1 = int.Parse(txtid.Text);
            _listView.ItemsSource = db.Table<Users>().Where(i => i.PersonId == PersonId1);
        }

    }
}