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
    public partial class DeleatPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        public DeleatPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            _ListView.ItemsSource = await App.User.GetPeopleAsync();
        }
        Person omar;
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            omar = e.SelectedItem as Person;


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            bool result = await DisplayAlert("انتباه","هل تريد الحذف","Yes","No");
            if (result==true) {
                db.Table<Person>().Delete(X => X.ID == omar.ID);
                db.Table<Users>().Delete(X => X.PersonId == omar.ID);
            } else { return; }
            
            _ListView.ItemsSource = await App.User.GetPeopleAsync();
            return;
            await Navigation.PushAsync(new ShellPage());
        }
    }
}