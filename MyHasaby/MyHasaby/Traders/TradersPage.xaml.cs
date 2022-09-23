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
    public partial class TradersPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        public TradersPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            _ListView.ItemsSource = await App.User1.GetTradersAsync();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTradersPage());
        }
        TradersClass omar;
        private  void _ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            omar = e.SelectedItem as TradersClass;
           
        }
        // Delete by image button
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            bool result = await DisplayAlert("انتباه","هل تريد الحذف","Yes","No");
            if (result == true)
            {
                db.Table<TradersClass>().Delete(X => X.ID == omar.ID);
                db.Table<SubTraderClass>().Delete(X => X.TraderID == omar.ID);
                await DisplayAlert("حذف", "تم حذف العملية بنجاح", "ok");
            }
            else { return; }
            _ListView.ItemsSource = await App.User1.GetTradersAsync();
            return;
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DisTraders(omar));
        }
    }
}