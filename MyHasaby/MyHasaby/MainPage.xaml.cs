﻿


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
                DisplayAlert("تم", "تم اضافة العميل بنجاح", "Ok");
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

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            omar2.IsVisible = true;
            
       }
        private async Task Restor()
        {

            try
            {
                var connection = new SQLiteConnection(_dbpath);
                //var connection = new SQLiteConnection(App.DataBasePath);
                SQLiteAsyncConnection toMerge;

                // Build a string that has the path to where we want the new database file for this procedure.
                //  string szRestorePath = "/storage/emulated/0/Android/data/com.alshobky.myhasaby/files/logs/temp.db3";
                // Check that we have access to be playing with these files.

                string docFolder = Path.Combine(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.MyDocuments), "logs");
                string libFolder = "/storage/emulated/0/Android/datacom.alshobky.myhasaby/files/logs/temp.db3";
                string szRestorePath = Path.Combine(docFolder, libFolder);
                var file = await FilePicker.PickAsync();
                if (file == null) return;
                string filetemp = file.FileName;
                var libFolder1 = file.FullPath;
                szRestorePath = Path.Combine(libFolder, filetemp);

                var statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
                var statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                if (statusWrite == Xamarin.Essentials.PermissionStatus.Granted && statusRead == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    try
                    {
                        if (!File.Exists(szRestorePath))
                        {
                            // Display an alert to let the user know they need to check the file.
                            await DisplayAlert("Error", "Restore database not at path", "Oops");

                            // We're done get out of here.
                            return;
                        }

                        // Get our connection to the new database.
                        toMerge = new SQLiteAsyncConnection(szRestorePath);

                        // Save a location to the live database path.
                        string szLiveDBPath = connection.DatabasePath;

                        // Make an insanity check backup.
                        connection.Backup(connection.DatabasePath.Insert(connection.DatabasePath.Length, "OLD"));
                        // Close the existing DB.
                        connection.Close();

                        // Check to make sure we have the backup DB before deleting the active DB
                        if (File.Exists($"{szLiveDBPath}OLD"))
                        {
                            // Delete the active database.
                            File.Delete(szLiveDBPath);

                            // Close the handle to the new DB just to make sure it's not going to gripe about that.
                            await toMerge.CloseAsync().ConfigureAwait(true);

                            // Copy the new one to the location for the "Live" database.
                            File.Copy(toMerge.DatabasePath, szLiveDBPath);

                            // Attempt a connection using the new database file and see if this all worked.
                            connection = new SQLiteConnection(_dbpath);

                            // Enable write ahead (this will also make sure the DB is really connected and so on)
                            connection.EnableWriteAheadLogging();

                            // File delete the temporary backup  file now.
                            File.Delete($"{szLiveDBPath}OLD");
                            DisplayAlert("OK", "تم استعادة النسخة الاحتياطية", "OK");
                            return;
                            //Quit the application.
                            // System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", ex.Message, "Oops");
                    }

                }
                else
                    throw new Exception("Give the Application the ability to access to storage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Oops");
            }

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Restor();
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DrivePage());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleatPage());

        }
       async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
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

<<<<<<< HEAD
        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }

        
=======
       
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
    }
}
