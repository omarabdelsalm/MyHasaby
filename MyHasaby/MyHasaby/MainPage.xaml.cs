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

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.User.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Phone = Convert.ToInt32(ageEntry.Text)
                });

                nameEntry.Text = ageEntry.Text = string.Empty;
                //collectionView.ItemsSource = await App.Database.GetPeopleAsync();
                _ListView.ItemsSource = await App.User.GetPeopleAsync();
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

        
    }
}
