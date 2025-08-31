using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHasaby
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://myhasaby-default-rtdb.firebaseio.com/");

        public async Task<List<Person1>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person1>()).Select(item => new Person1
              {
                  Name = item.Object.Name,
                  Imei = item.Object.Imei,
                  MyPhon = item.Object.MyPhon,

                  
              }).ToList();
        }
        public async Task AddPerson(string Imeiy, string name, string MyPhon,bool evect)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person1() { Imei = Imeiy, Name = name, MyPhon = MyPhon ,evect=false});
        }

        public async Task<Person1> GetPerson(string Imeiy)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Imei == Imeiy).FirstOrDefault();
        }

        public async Task UpdatePerson(string name, string Imeiy, string MyPhon)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person1>()).Where(a => a.Object.Imei == Imeiy).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person1() { Imei = Imeiy, Name = name, MyPhon = MyPhon });
        }
        public async Task DeletePerson(string Imei)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person1>()).Where(a => a.Object.Imei == Imei).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}
