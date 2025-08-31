using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHasaby.Categories;
using MyHasaby.Categories.Data;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DipAllCategories : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        
        int myId1;
        TafselCategory lastselected;
        public DipAllCategories(int id)
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbpath);
            this.myId1 = id;
            
            listview.ItemsSource = db.Table<TafselCategory>().Where(i => i.IDCategory == myId1);
        }
        Categor Lost;
        
        protected override  void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteConnection(_dbpath);
            listview.ItemsSource = db.Table<TafselCategory>().Where(i => i.IDCategory == myId1);
        }
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lastselected = e.SelectedItem as TafselCategory;
             Navigation.PushAsync(new EditAllTeCategory(lastselected));

        }
        
    }
}