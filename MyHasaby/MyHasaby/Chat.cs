using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyHasaby
{
    public class Chat
    {
        public static void Open(string phoneNumber, string message = null)
        {
            try
            {
                var uriString = "whatsapp://send?phone=" + phoneNumber;

                if (!string.IsNullOrWhiteSpace(message))
                    uriString += "&text=" + message;

                Device.OpenUri(new Uri(uriString));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
