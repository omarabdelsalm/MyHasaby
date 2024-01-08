


using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace MyHasaby
{
    public partial class MainPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        
       
        public MainPage()
        {
            InitializeComponent();
            btncon.Clicked += Btncon_Clicked;
           

        }

        private async void Btncon_Clicked(object sender, EventArgs e)
        {
            try
            {
                var contact = await Contacts.PickContactAsync();

                if (contact == null)
                    return;
                nameEntry.Text = contact.GivenName+" "+contact.MiddleName+" "+contact.FamilyName;
                ageEntry.Text = contact.Phones.FirstOrDefault()?.PhoneNumber;

            }
            catch (Exception)
            {

            }
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.User.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Phone = ageEntry.Text
                });
               
               
                _ListView.ItemsSource = await App.User.GetPeopleAsync();
                await DisplayAlert("Add", "Add Successfully", "Ok");
                omar2.IsVisible = false;
                Person person = new Person();
                var db = new SQLiteConnection(_dbpath);
                var maxPK = db.Table<Person>().OrderByDescending(c => c.ID).FirstOrDefault();
                int id = (maxPK == null ? 1 : maxPK.ID);
                string name = nameEntry.Text;
                await Navigation.PushAsync(new AddData(id, name));
                nameEntry.Text = ageEntry.Text = string.Empty;

            }
        }
        Person omar;
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            omar = e.SelectedItem as Person;
           

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
            _ListView.ItemsSource = await App.User.GetPeopleAsync();
        }

        private  void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            omar2.IsVisible = true;
            
       }
       

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleatPage());

        }
        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var _container = BindingContext as Person;
            var db = new SQLiteConnection(_dbpath);
            _ListView.BeginRefresh();
            var pres = db.Table<Person>();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                _ListView.ItemsSource = from emp in pres select emp;//await App.User.GetPeopleAsync();
            else
                _ListView.ItemsSource = from emps in pres
                                        where emps.Name.Contains(e.NewTextValue)
                                        select emps;
                                        
                                        ;

            _ListView.EndRefresh();
        }

        

        
    }
}
