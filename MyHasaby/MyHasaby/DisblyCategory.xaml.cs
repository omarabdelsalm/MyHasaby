using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHasaby.Categories;
using MyHasaby.Categories.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisblyCategory : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

        public int id2;
        private Categor lastselected;

        public DisblyCategory(int Id)
        {
            InitializeComponent();
           this.id2 = Id;
        }

        public DisblyCategory(Categor lastselected)
        {
            this.lastselected = lastselected;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EName.Text) && !string.IsNullOrWhiteSpace(Equantity.Text) &&
                !string.IsNullOrWhiteSpace(Esoldout.Text) &&
                
                !string.IsNullOrWhiteSpace(Epurchasprice.Text) &&
                !string.IsNullOrWhiteSpace(Esellprice.Text))
            {
                await App.User22.SaveTafselCategoryAsync(new TafselCategory
                {
                    IDCategory = id2,
                    Name = EName.Text,
                    Quantity = Convert.ToInt32(Equantity.Text),
                    Soldout = Convert.ToInt32(Esoldout.Text),
                    Residual = Convert.ToInt32(Equantity.Text)- Convert.ToInt32(Esoldout.Text),
                    Purchasprice = Convert.ToInt32(Epurchasprice.Text),
                    Sellprice = Convert.ToInt32(Esellprice.Text),
                    Netprofit = Convert.ToInt32(Esellprice.Text)  - Convert.ToInt32(Epurchasprice.Text) 

                });
                await DisplayAlert("نجاح", "تم اضافة العملية بنجاح", "ok");
                await Navigation.PopAsync();
            }
        }
    }
}