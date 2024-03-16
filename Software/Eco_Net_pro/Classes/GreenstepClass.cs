using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Net_pro.Classes
{
    [FirestoreData]
    public class GreenstepClass
    {
        [FirestoreProperty]
        public string Name { get; set; }
    }
}
