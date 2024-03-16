using Google.Cloud.Firestore;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Net_pro.Classes
{
    [FirestoreData]
    internal class OnlineStores
    {
        [FirestoreProperty]
        public string ID { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string About { get; set; }
        [FirestoreProperty]
        public DateTime StartDate { get; internal set; }
    }
}
