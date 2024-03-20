using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Net_pro.Classes
{
    [FirestoreData]
    public class UserData
    {
        public static string LoggedInEmail { get; internal set; }
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string Phone { get; set; }
        [FirestoreProperty]
        public string Gender { get; set; }
        [FirestoreProperty]
        public string Country { get; set; }
        [FirestoreProperty]
        public string PINCode { get; set; }
       

    }
}
