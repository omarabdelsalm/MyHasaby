using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHasaby
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //collectionView.SelectionChanged += CollectionView_SelectionChanged;
        }

        //public async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var person = e.CurrentSelection as Person;
        //   // var persons = (person)sender as Person;
        //    //var name = person.Name;
        //    //var id = person.ID;
        //   await Navigation.PushAsync(new DetialPage(person.ID, person.Name.ToString()));
        //}
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Person;

        }


        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {

            ListView lv = (ListView)sender;

            //// this assumes your List is bound to a List<Club>

            Person monkeys = (Person)lv.SelectedItem;


            // await Navigation.PushAsync(new MyPageDisplay(monkeys.Url.ToString(), monkeys.Name.ToString()));
            await Navigation.PushAsync(new DetialPage(monkeys.ID, monkeys.Name.ToString()));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            _ListView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Phone = int.Parse(ageEntry.Text)
                });

                nameEntry.Text = ageEntry.Text = string.Empty;
                //collectionView.ItemsSource = await App.Database.GetPeopleAsync();
                _ListView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }
}
