using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby.Traders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisTraders : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
       
        public DisTraders(int id)
        {
            InitializeComponent();
            EId.Text = id.ToString();
            var db = new SQLiteConnection(_dbpath);
           
            var EgDafee = db.Table<SubTraderClass>().Where(i => i.TraderID == id).Select(x => x.Dafee).Sum();
            var EgAlih = db.Table<SubTraderClass>().Where(i => i.TraderID == id).Select(x => x.Alih).Sum();
            
            AddeGmaly();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteConnection(_dbpath);
            int nom = Convert.ToInt32(EId.Text);
            var nomar = db.Table<SubTraderClass>().Where(i => i.TraderID == nom);
            _listview.ItemsSource = nomar;
           
        }
       // edit subtrader
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            int nom = Convert.ToInt32(EId.Text);
            if (!string.IsNullOrWhiteSpace(EDafee.Text) && !string.IsNullOrWhiteSpace(EAlih.Text))
            {
                try {
                    await App.User1.SaveSubTraderAsync(new SubTraderClass
                    {
                        TraderID = Convert.ToInt32(EId.Text),
                        Dafee = Convert.ToInt32(EDafee.Text),
                        Alih = Convert.ToInt32(EAlih.Text),
                        EgDafee = db.Table<SubTraderClass>().Where(i => i.TraderID == nom).Select(x => x.Dafee).Sum(),
                        EgAlih = db.Table<SubTraderClass>().Where(i => i.TraderID == nom).Select(x => x.Alih).Sum(),
                    });
                    await DisplayAlert("نجاح", "تم اضافة  بنجاح", "Ok");
                    EDafee.Text = EAlih.Text = string.Empty;
                   
                    var nomar = db.Table<SubTraderClass>().Where(i => i.TraderID == nom);
                    _listview.ItemsSource = nomar;
                    await Navigation.PopAsync();
                }
                catch
                {
                   await DisplayAlert("انتباه", "يجب تحديث الصفحة", "Ok");
                    return;
                }
                
            }
        }

        SubTraderClass lastselect;
        private void _listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lastselect = e.SelectedItem as SubTraderClass;
            idever.Text = lastselect.ID.ToString();
            EId.Text = lastselect.TraderID.ToString();
            
        }

        
        // Deleat member
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            bool result = await DisplayAlert("انتباه", "هل تريد الحذف", "Yes", "No");
            if (result == true)
            {
                db.Table<SubTraderClass>().Delete(X => X.ID == lastselect.ID);
                await DisplayAlert("حذف", "تم حذف العملية بنجاح", "ok");


            }
            else { return; }
            int nom = Convert.ToInt32(EId.Text);
            var nomar = db.Table<SubTraderClass>().Where(i => i.TraderID == nom);
            _listview.ItemsSource = nomar;
        }


        
        private void AddeGmaly()
        {
            var db = new SQLiteConnection(_dbpath);
            int nom = Convert.ToInt32(EId.Text);
            var EgDafee = db.Table<SubTraderClass>().Where(i => i.TraderID == nom).Select(x => x.Dafee).Sum();
            var EgAlih = db.Table<SubTraderClass>().Where(i => i.TraderID == nom).Select(x => x.Alih).Sum();
            EgmalyModanText.Text =  EgDafee.ToString();
            EgmalyDaenText.Text =  EgAlih.ToString();
            EgmalyEModanText.Text = (EgDafee - EgAlih).ToString();
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mey = sender as MenuItem;
            var m = mey.CommandParameter as SubTraderClass;
            var db = new SQLiteConnection(_dbpath);
            bool result = await DisplayAlert("انتباه", "هل تريد الحذف", "Yes", "No");
            if (result == true)
            {
                db.Table<SubTraderClass>().Delete(X => X.ID == m.ID);
                await DisplayAlert("حذف", "تم حذف العملية بنجاح", "ok");


            }
            else { return; }
            int nom = Convert.ToInt32(EId.Text);
            var nomar = db.Table<SubTraderClass>().Where(i => i.TraderID == nom);
            _listview.ItemsSource = nomar;

        }
    }
}