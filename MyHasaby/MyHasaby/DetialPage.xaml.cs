using SQLite;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Drawing;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetialPage : ContentPage
    {
        string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
        public int egmaijdaen;
        public int egmaijdaen1;
        public int egmaijdaen2;
        internal object listView;
        public string name2;
        public int id2;
        public int item1;
        public int item2;
        public DetialPage(int id,String name)
        {
            InitializeComponent();
            var name2 = name;
            var id2 = id;
            txtname.Text = name;
            txtid.Text = id.ToString();
            BtnDane.Clicked += BtnDane_Clicked;//له
            BtnMdane.Clicked += BtnMdane_Clicked;//علية
            var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
          
            _listView.ItemsSource = db.Table<Users>().Where(i => i.PersonId == PersonId1);//.FirstOrDefaultAsync();
            
            AddEgmalyHasabAsync();
        }
        

        private async void BtnMdane_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TexDane.Text) && !string.IsNullOrWhiteSpace(txtid.Text))
            {
                await App.User1.SavePersonAsync(new Users
                {
                    Dane = Convert.ToInt32(TexDane.Text),
                    PersonId = Convert.ToInt32(txtid.Text),
                    Nots = Molhazt.Text

                });
               await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");

                var db = new SQLiteConnection(_dbpath);

                var PersonId1 = int.Parse(txtid.Text);
                

                await App.User1.SaveEgmalyAsync(new EgmalyDanMden
                {
                    Name = txtname.Text,
                    PersonId = Convert.ToInt32(txtid.Text),
                    EgDane = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Dane).Sum(),
                    EgMdan = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Mdan).Sum()

                });
                TexDane.Text = txtid.Text = string.Empty;
                await Navigation.PopAsync();
            }
        }

        private async void BtnDane_Clicked(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(TexDane.Text) && !string.IsNullOrWhiteSpace(Molhazt.Text))
            {
                await App.User1.SavePersonAsync(new Users
                {
                    Mdan = Convert.ToInt32(TexDane.Text),
                    PersonId = Convert.ToInt32(txtid.Text),
                    Nots = Molhazt.Text

                });
                await DisplayAlert("تم اضافة المبلغ بنجاح", "adding", "ok");

                var db = new SQLiteConnection(_dbpath);
                
                var PersonId1 = int.Parse(txtid.Text);
                

                await App.User1.SaveEgmalyAsync(new EgmalyDanMden
                {
                    Name = txtname.Text,
                    PersonId = Convert.ToInt32(txtid.Text),
                    EgDane = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Dane).Sum(),
                    EgMdan = db.Table<Users>().Where(i => i.PersonId == PersonId1).Select(x => x.Mdan).Sum()
                });
                TexDane.Text = txtid.Text = string.Empty;
                await Navigation.PopAsync();
            }
        }

       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
            _listView.ItemsSource = db.Table<Users>().Where(i => i.PersonId == PersonId1);//.FirstOrDefaultAsync();


        }
        private async void AddEgmalyHasabAsync()
        {
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

           var db = new SQLiteConnection(_dbpath);
            var PersonId1 = int.Parse(txtid.Text);
            var table = db.Table<Users>().Where(i => i.PersonId == PersonId1);
            foreach (var s in table)
            {
                var data = s.Dane;
                egmaijdaen += data;
                EgmalyDaenText.Text = egmaijdaen.ToString();
                var ModanData = s.Mdan;
                egmaijdaen1 += ModanData;
                EgmalyModanText.Text = egmaijdaen1.ToString();
               var egmaiy = int.Parse(EgmalyModanText.Text )- int.Parse(EgmalyDaenText.Text);
                EgmalyEModanText.Text = egmaiy.ToString();
               
            }
            
        }
        void DrawTable()
        {
            ////List of Columns 
            Users usr = new Users();
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");

            var db = new SQLiteConnection(_dbpath);
            //List<Users> collection = new List<Users>();

            //Users customer = new Users();

            //customer.Dane = usr.Dane;
            //customer.Mdan = usr.Mdan;
            //collection.Add(customer);

            ////Add values to list 
            //List<object> data = new List<object>();
            //for (int i = 0; i < collection.Count; i++)
            //{
            //    Object row = new { Date = collection[i].CreateAt, Dane= collection[i].Dane,deyou= collection[i].Mdan };
            //    data.Add(row);
            //}
            ////Add list to IEnumerable 
            //IEnumerable<object> tableData = data;
            ////Assign data source
            //PdfDocument doc = new PdfDocument();
            ////Add a page.
            //PdfPage page = doc.Pages.Add();
            ////Create a PdfGrid.
            //PdfGrid pdfGrid = new PdfGrid();
            //pdfGrid.DataSource = tableData;
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list
            //List<Users> data = new List<Users>();
            //Object row1 = new { ID = "ديون", Name =usr.Mdan };
            //Object row2 = new { ID = "مدفوع", Name = usr.Dane };
            //Object row3 = new { ID = "ملاحظات", Name = usr.Nots };
            //Object row4 = new { ID = "التاريخ", Name = usr.CreateAt };
            
            //data.Add((Users)row1);
            //data.Add((Users)row2);
            //data.Add((Users)row3);
            //data.Add((Users)row4);
            
            //Add list to IEnumerable
            //IEnumerable<object> dataTable = data;
            ////Assign data source.
            pdfGrid.DataSource = db.Table<Users>().OrderBy(x => x.ID).ToList(); ;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(10, 10));
            //Save the PDF document to stream.
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
            //Save the PDF document to stream.
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //Close the document.
            doc.Close(true);
            stream.Position = 0;
            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DrawTable();

        }
    }
}