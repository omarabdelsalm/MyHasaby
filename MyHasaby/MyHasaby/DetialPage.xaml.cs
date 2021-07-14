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
            _listView.RefreshCommand = new Command(() => {
                //Do your stuff.    
                RefreshData();
                _listView.IsRefreshing = false;
            });
            AddEgmalyHasabAsync();
        }
        public void RefreshData()
        {
            var db = new SQLiteConnection(_dbpath);
            int PersonId1;     // = Convert.ToInt32(txtid.Text);
            if (Int32.TryParse(txtid.Text, out PersonId1))
            {
              PersonId1= Convert.ToInt32(txtid.Text);
            }
            //_listView.ItemsSource = null;
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
        private void AddEgmalyHasabAsync()
        {
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

           var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
            var table = db.Table<Users>().Where(i => i.PersonId == PersonId1);//db.Table<Users>();
            foreach (var s in table)
            {
                var data = s.Dane;
                egmaijdaen += data;
                EgmalyDaenText.Text = egmaijdaen.ToString();
                var ModanData = s.Mdan;
                egmaijdaen1 += ModanData;
                EgmalyModanText.Text = egmaijdaen1.ToString();

                // egmaijdaen2 = Convert.ToInt32(EgmalyDaenText.Text)+ Convert.ToInt32(EgmalyModanText.Text);
                //var ModanData1 = s.Egmaly;
                //egmaijdaen2 += ModanData1;
               
            }



        }

    }
}