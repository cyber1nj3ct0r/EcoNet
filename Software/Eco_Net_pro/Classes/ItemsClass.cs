using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Net_pro.Classes
{
    [FirestoreData]
    public class ItemsClass
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Price { get; set; }
        [FirestoreProperty]
        public string ItemsAbout { get; set; }
    }
}
