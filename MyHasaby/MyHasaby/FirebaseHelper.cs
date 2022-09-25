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
<<<<<<< HEAD
                  evect= item.Object.evect,

              }).ToList();
        }
        public async Task AddPerson(string Imeiy, string name, string MyPhon, string evct) => await firebase
              .Child("Persons")
              .PostAsync(new Person1() { Imei = Imeiy, Name = name, MyPhon = MyPhon, evect = evct });
=======

                  
              }).ToList();
        }
        public async Task AddPerson(string Imeiy, string name, string MyPhon,bool evect)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person1() { Imei = Imeiy, Name = name, MyPhon = MyPhon ,evect=false});
        }
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b

        public async Task<Person1> GetPerson(string Imeiy)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
<<<<<<< HEAD
              .OnceAsync<Person1>();
            return allPersons.Where(a => a.Imei == Imeiy).FirstOrDefault();
        }

        public async Task UpdatePerson(string Imeiy, string name, string MyPhon, string evct)
=======
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Imei == Imeiy).FirstOrDefault();
        }

        public async Task UpdatePerson(string name, string Imeiy, string MyPhon)
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person1>()).Where(a => a.Object.Imei == Imeiy).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
<<<<<<< HEAD
              .PutAsync(new Person1() { Imei = Imeiy, Name = name, MyPhon = MyPhon ,evect= evct });
=======
              .PutAsync(new Person1() { Imei = Imeiy, Name = name, MyPhon = MyPhon });
>>>>>>> e3d0996f4d657ca68edcb3f470a0af6bccc04d0b
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
