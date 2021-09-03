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
        public int egmaijdaen;
        public int egmaijdaen1;
        public int egmaijdaen2;
        internal object listView;
        public string name2;
        public int id2;
        public int item1;
        public int item2;
        public DetialPage(int id,String name)
        {
            InitializeComponent();
            var name2 = name;
            var id2 = id;
            txtname.Text = name;
            txtid.Text = id.ToString();
            BtnDane.Clicked += BtnDane_Clicked;//له
            BtnMdane.Clicked += BtnMdane_Clicked;//علية
            var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
          
            _listView.ItemsSource = db.Table<Users>().Where(i => i.PersonId == PersonId1);//.FirstOrDefaultAsync();
            
            AddEgmalyHasabAsync();
        }
        

        private async void BtnMdane_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TexDane.Text) && !string.IsNullOrWhiteSpace(txtid.Text))
            {
                await App.User1.SavePersonAsync(new Users
                {
                    Dane = Convert.ToInt32(TexDane.Text),
                    PersonId = Convert.ToInt32(txtid.Text),
                    Nots = Molhazt.Text

                });
               await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");

                var db = new SQLiteConnection(_dbpath);

                var PersonId1 = int.Parse(txtid.Text);
                //var table = db.Table<Users>().Where(i => i.PersonId == PersonId1);
                //foreach (var s in table)
                //{
                //    var data = s.Dane;
                //    egmaijdaen += data;
                //    var ModanData = s.Mdan;
                //    egmaijdaen1 += ModanData;
                //}

                await App.User1.SaveEgmalyAsync(new EgmalyDanMden
                {
                    Name = txtname.Text,
                    PersonId = Convert.ToInt32(txtid.Text),
                    EgDane = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Dane).Sum(),
                    EgMdan = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Mdan).Sum()

                });
                TexDane.Text = txtid.Text = string.Empty;
                await Navigation.PopAsync();
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

                var db = new SQLiteConnection(_dbpath);
                
                var PersonId1 = int.Parse(txtid.Text);
                //var table = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x=>x.Dane).Sum();
                //foreach (var s in table)
                //{
                //    var data = s.Dane;
                //    egmaijdaen += data;
                //    var ModanData = s.Mdan;
                //    egmaijdaen1 += ModanData;
                //}

                await App.User1.SaveEgmalyAsync(new EgmalyDanMden
                {
                    Name = txtname.Text,
                    PersonId = Convert.ToInt32(txtid.Text),
                    EgDane = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Dane).Sum(),
                    EgMdan = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Mdan).Sum()
                });
                TexDane.Text = txtid.Text = string.Empty;
                await Navigation.PopAsync();
            }
        }

       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
            _listView.ItemsSource = db.Table<Users>().Where(i => i.PersonId == PersonId1);//.FirstOrDefaultAsync();


        }
        private async void AddEgmalyHasabAsync()
        {
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

           var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
            var table = db.Table<Users>().Where(i => i.PersonId == PersonId1);
            foreach (var s in table)
            {
                var data = s.Dane;
                egmaijdaen += data;
                EgmalyDaenText.Text = egmaijdaen.ToString();
                var ModanData = s.Mdan;
                egmaijdaen1 += ModanData;
                EgmalyModanText.Text = egmaijdaen1.ToString();
               var egmaiy = int.Parse(EgmalyModanText.Text )- int.Parse(EgmalyDaenText.Text);
                EgmalyEModanText.Text = egmaiy.ToString();
               
            }
            
        }

    }
}