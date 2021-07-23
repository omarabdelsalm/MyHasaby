using Android.Content;


using Java.Nio.Channels;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MyHasaby
{
    public partial class MainPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

      
        public MainPage()
        {
            InitializeComponent();
            //collectionView.SelectionChanged += CollectionView_SelectionChanged;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.User.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Phone = int.Parse(ageEntry.Text)
                });
               
               
                _ListView.ItemsSource = await App.User.GetPeopleAsync();
                DisplayAlert("تم", "تم اضافة العميل بنجاح", "Ok");
                Person person = new Person();
                var db = new SQLiteConnection(_dbpath);
                var maxPK = db.Table<Person>().OrderByDescending(c => c.ID).FirstOrDefault();
                int id = (maxPK == null ? 1 : maxPK.ID);
                string name = nameEntry.Text;
                await Navigation.PushAsync(new AddData(id, name));
                nameEntry.Text = ageEntry.Text = string.Empty;

            }
        }
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Person;

        }


        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {

            ListView lv = (ListView)sender;

            //// this assumes your List is bound to a List<Club>

            Person monkeys = (Person)lv.SelectedItem;


            await Navigation.PushAsync(new DetialPage(monkeys.ID, monkeys.Name.ToString()));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            _ListView.ItemsSource = await App.User.GetPeopleAsync();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            try
            {
                var db = new SQLiteConnection(_dbpath);
                string docFolder = Path.Combine(System.Environment.GetFolderPath
                     (System.Environment.SpecialFolder.MyDocuments), "logs");
                string libFolder = Path.Combine(docFolder, "/storage/emulated/0/Android/data/MyApp/files/logs");
                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }


                string destinationDatabasePath = Path.Combine(libFolder, "temp.db3");//"/storage/emulated/0/Android/data/MyApp/files/logs";//

                db.Backup( destinationDatabasePath, "main");
               
                DisplayAlert("تم بحمد الله", "ok", "OK");

                
            }
            catch
                {
                DisplayAlert("محاولة مرةاخرى","no","om");
                    
                }
            }

       
    }
}
