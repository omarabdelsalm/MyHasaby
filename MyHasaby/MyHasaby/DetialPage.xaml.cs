using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetialPage : ContentPage
    {
        public DetialPage(int id,String name)
        {
            InitializeComponent();
            txtname.Text = name;
            txtid.Text = id.ToString();
        }
    }
}