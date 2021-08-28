using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHasaby.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainsPage : ContentPage
    {
        public MainsPage()
        {
            InitializeComponent();
            var urlSource = new UrlWebViewSource();

            string baseUrl = DependencyService.Get<IBaseUrl>().GetUrl();
            string filePathUrl = Path.Combine(baseUrl, "TextFile.html");
            urlSource.Url = filePathUrl;
            webviewjava.Source = urlSource;
        }
    }
}