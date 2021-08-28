using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyHasaby.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFiles))]
namespace MyHasaby.Droid
{
    public class LocalFiles : IBaseUrl
    {
        public string GetUrl()
        {
            return "file:///android_asset/";
        }
    }
}