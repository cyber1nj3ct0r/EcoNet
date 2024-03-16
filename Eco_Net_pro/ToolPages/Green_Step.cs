using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using System.Threading;
using Eco_Net_pro.Classes;

namespace Eco_Net_pro
{
    public partial class Green_Step : UserControl
    {
        [FirestoreData]
        public class GreenstepClass
        {
            [FirestoreProperty]
            public string Name { get; set; }
        }

        FirestoreDb database;
        private int rowIndexCounter = 1;
        public Green_Step()
        {
            InitializeComponent();
        }


        private void Green_Step_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            GetAllDocuments("AppUser");


        }

        async void GetAllDocuments(string nameofCollection)
        {
            Query query = database.Collection(nameofCollection);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    GreenstepClass greenstepclass = documentSnapshot.ConvertTo<GreenstepClass>();

                    guna2DataGridView1.Rows.Add(rowIndexCounter++, documentSnapshot.Id, greenstepclass.Name);

                }
            }
        }
    }
}
