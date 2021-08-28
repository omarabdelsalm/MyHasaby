using Foundation;
using MyHasaby.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFiles))]
namespace MyHasaby.iOS
{
    public class LocalFiles : IBaseUrl
    {
        public string GetUrl()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
