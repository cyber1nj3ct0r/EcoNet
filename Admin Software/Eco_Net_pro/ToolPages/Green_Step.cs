using System;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Eco_Net_pro.Classes;

namespace Eco_Net_pro
{
    public partial class Green_Step : UserControl
    {
        [FirestoreData]
        public class GreenstepClass
        {
            [FirestoreProperty]
            public string Email { get; set; }
            [FirestoreProperty]
            public DateTime Sdate { get; internal set; }
            [FirestoreProperty]
            public DateTime Edate { get; internal set; }
            [FirestoreProperty]
            public string Rank { get; set; }
        }

        FirestoreDb database;
        public Green_Step()
        {
            InitializeComponent();
        }


        private void Green_Step_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;
            GetAllDocuments("GreenStep");
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

                    guna2DataGridView1.Rows.Add(documentSnapshot.Id, greenstepclass.Email, greenstepclass.Sdate, greenstepclass.Edate, greenstepclass.Rank);

                }
            }

            UpdateRowCountLabel();
        }

        private void UpdateRowCountLabel()
        {
            int rowCount = guna2DataGridView1.RowCount;

            label8.Text = $"{rowCount}";
            label9.Text = $"{rowCount}";
        }
    }
}
