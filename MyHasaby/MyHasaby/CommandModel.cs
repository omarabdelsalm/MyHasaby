using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyHasaby
{

    public class CommandModel
    {
        Command Imagimbied1 = new Command(async()=> {

            var RusaltPicker = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Omar"

            });
            if (RusaltPicker != null)
            {
                var stream = await RusaltPicker.OpenReadAsync();

              var name= ImageSource.FromStream(() => stream);
               
            }
            
        }) ;

        

        
    }
    
    
}
