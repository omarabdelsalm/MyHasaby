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


namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategory : ContentPage
    {
       
        public AddCategory()
        {
            InitializeComponent();
            

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

            var db = new SQLiteConnection(_dbpath);
            App.User22.SaveCategorAsync(new Categor
            {
                Name = CatName.Text
            });
           await App.Current.MainPage.DisplayAlert("تم", "تم اضافة صنف جديد", "ok");
            CatName.Text = string.Empty;
            
            try {
                await Navigation.PopAsync();

            } 
            catch
            {
                App.Current.MainPage = new AllDBSnf();
            }
            finally {
                await Navigation.PushAsync(new AllDBSnf());
            }
        }

        
    }
}