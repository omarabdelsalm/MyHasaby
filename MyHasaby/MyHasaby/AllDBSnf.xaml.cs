using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHasaby.Categories.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHasaby.Categories;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllDBSnf : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        int myId;
        Categor lastselected1;
        public AllDBSnf()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            _ListView.ItemsSource = await App.User22.GetPeopleAsync();
        }

        
       void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var _container = BindingContext as Categor;
            var db = new SQLiteConnection(_dbpath);
            _ListView.BeginRefresh();
            var pres = db.Table<Categor>();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                _ListView.ItemsSource = from emp in pres select emp;//await App.User.GetPeopleAsync();
            else
                _ListView.ItemsSource = from emps in pres
                                        where emps.Name.Contains(e.NewTextValue)
                                        select emps;

            ;

            _ListView.EndRefresh();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage= new AddCategory();
            await Navigation.PushAsync(new AddCategory());
        }
        Categor lastselect;
        private  void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lastselect = e.SelectedItem as Categor;
            lastselected1 = e.SelectedItem as Categor;
                int myId = lastselected1.ID;

           
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
          
           
            var db = new SQLiteConnection(_dbpath);
            
            // App.User22.DeleteItemCatAsync(lastselected1);
            db.Table<Categor>().Delete(X => X.ID == lastselect.ID);
            db.Table<TafselCategory>().Delete(X => X.IDCategory == lastselect.ID);
            await DisplayAlert("Delete", "Delete Successfully", "ok");
            _ListView.ItemsSource = await App.User22.GetPeopleAsync();
            return;
        }
       //تسجيل الاصناف الفرعية صفحة
        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            
            int myId2 = lastselect.ID;
            try 
            {
                await Navigation.PushAsync(new DisblyCategory(myId2));
                
            } catch 
            {
                App.Current.MainPage = new DisblyCategory(myId2);
            }
           
        }

        

        //عرض الاصناف الفرعية صفحة
        private async void ImageButton_Clicked2(object sender, EventArgs e)
        {
            //Categor lastselect = new Categor();
           int myId = lastselect.ID;
            try {
                await Navigation.PushAsync(new DipAllCategories(myId));
                 }
            catch {
                App.Current.MainPage = new DipAllCategories(myId);
            }
           
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mey=sender as MenuItem; 
            var m=mey.CommandParameter as Categor;
            var db = new SQLiteConnection(_dbpath);

            // App.User22.DeleteItemCatAsync(lastselected1);
            db.Table<Categor>().Delete(X => X.ID == m.ID);
            db.Table<TafselCategory>().Delete(X => X.IDCategory == m.ID);
            await DisplayAlert("Delete", "Delete Successfully", "ok");
            _ListView.ItemsSource = await App.User22.GetPeopleAsync();
            return;

        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mey = sender as MenuItem;
            var m = mey.CommandParameter as Categor;
            int myId2 = m.ID;
            try
            {
                await Navigation.PushAsync(new DisblyCategory(myId2));

            }
            catch
            {
                App.Current.MainPage = new DisblyCategory(myId2);
            }
        }

        private async void MenuItem_Clicked_2(object sender, EventArgs e)
        {
            var mey = sender as MenuItem;
            var m = mey.CommandParameter as Categor;
            int myId = m.ID;
            try
            {
                await Navigation.PushAsync(new DipAllCategories(myId));
            }
            catch
            {
                App.Current.MainPage = new DipAllCategories(myId);
            }

        }
    }
}