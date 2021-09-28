using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyHasaby
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //public virtual void OnpropertyChanged(string propertyname)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

        //}
        
         public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //var handler = PropertyChanged;
            //if (handler != null)
            //    handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
