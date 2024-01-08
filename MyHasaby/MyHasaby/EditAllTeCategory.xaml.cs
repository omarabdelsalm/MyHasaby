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
    public partial class EditAllTeCategory : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        
        TafselCategory LastCateogry;
        public EditAllTeCategory(TafselCategory LastCateogry)
        {
            InitializeComponent();
           
            this.LastCateogry = LastCateogry;
            InD1.Text = LastCateogry.ID.ToString();
            InD.Text = LastCateogry.IDCategory.ToString();
            EName.Text = LastCateogry.Name;
            Equantity.Text = LastCateogry.Quantity.ToString();
            Esoldout.Text = LastCateogry.Soldout.ToString();

            Epurchasprice.Text = LastCateogry.Purchasprice.ToString();
            Esellprice.Text = LastCateogry.Sellprice.ToString();
            EMort.Text = 0.ToString();
        }
       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EName.Text) && 
                !string.IsNullOrWhiteSpace(Equantity.Text) &&
                !string.IsNullOrWhiteSpace(Esoldout.Text) 
                &&
                !string.IsNullOrWhiteSpace(Epurchasprice.Text) &&
                !string.IsNullOrWhiteSpace(Esellprice.Text))
            {

                await App.User22.SaveTafselCategoryAsync(new TafselCategory {
                    ID = Convert.ToInt32(InD1.Text),
                    IDCategory = Convert.ToInt32(InD.Text),
                    Name = EName.Text,
                    Quantity = Convert.ToInt32(Equantity.Text),
                   Purchasprice = Convert.ToInt32(Epurchasprice.Text),
                   Sellprice = Convert.ToInt32(Esellprice.Text),
                    Residual = Convert.ToInt32(Equantity.Text) - Convert.ToInt32(Esoldout.Text) + Convert.ToInt32(EMort.Text),
                    Soldout = Convert.ToInt32(Esoldout.Text) - Convert.ToInt32(EMort.Text),
                    Netprofit = Convert.ToInt32(Esellprice.Text) - Convert.ToInt32(Epurchasprice.Text)
            });
                 await  App.Current.MainPage.DisplayAlert("Success", "Updated successfully", "OK");
                 await Navigation.PopAsync();
               
            }
        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await App.User22.DeleteItemtafAsync(LastCateogry);
            await App.Current.MainPage.DisplayAlert("Delete", "Delete successfully", "OK");
            await Navigation.PopAsync();
        }
        }
}