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
        TradersClass tradersClass;
        int m;
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
        //private async void ImageButton_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var db = new SQLiteConnection(_dbpath);
        //        bool result = await DisplayAlert("انتباه", "هل تريد الحذف", "Yes", "No");
        //        if (result == true)
        //        {
        //            db.Table<TradersClass>().Delete(X => X.ID == omar.ID);
        //            db.Table<SubTraderClass>().Delete(X => X.TraderID == omar.ID);
        //            await DisplayAlert("حذف", "تم حذف العملية بنجاح", "ok");
        //        }
        //        else { return; }
        //        _ListView.ItemsSource = await App.User1.GetTradersAsync();
        //        return;
        //    }
        //    catch (Exception)
        //    {
        //        await DisplayAlert("تحذير", "يجب تحديد الصف اولا", "ok");
        //        return;
        //    }

        //}
        //// TradersClass omar2;
        TradersClass omar2;

        //private void _ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //   var mey= sender as ListView;
        //    var m = mey.BindingContext as TradersClass;
            

        //}
        //private async void ImageButton_Clicked_1(object sender, EventArgs e)
        //{

            
        //    bool result = await DisplayAlert("انتباه", "هل تريد التعديل", "Yes", "No");
        //    if (result == true)
        //    {
              
               
        //        await Navigation.PushAsync(new DisTraders(m));
               
        //    }
        //    else { return; }
        //    //try {
        //    //    await Navigation.PushAsync(new DisTraders(omar2));
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    await DisplayAlert("تحذير", "يجب تحديد الصف اولا", "ok");
        //    //    return;
        //    //}
           
        //}

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mey = sender as MenuItem;
            var m = mey.CommandParameter as TradersClass;
            try
            {
                var db = new SQLiteConnection(_dbpath);
                bool result = await DisplayAlert("Attention", "Do you want to delete?", "Yes", "No");
                if (result == true)
                {
                    db.Table<TradersClass>().Delete(X => X.ID == m.ID);
                    db.Table<SubTraderClass>().Delete(X => X.TraderID == m.ID);
                    await DisplayAlert("Delete", "Deleted Successfully", "OK");
                }
                else { return; }
                _ListView.ItemsSource = await App.User1.GetTradersAsync();
                return;
            }
            catch {  return; }

        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mey = sender as MenuItem;
            var m = mey.CommandParameter as TradersClass;
            try
            {
                   await Navigation.PushAsync(new DisTraders(m.ID));
            }
            catch (Exception)
            {
                await DisplayAlert("warning", "You must select the class first", "OK");
                return;
            }
        }
    }
}