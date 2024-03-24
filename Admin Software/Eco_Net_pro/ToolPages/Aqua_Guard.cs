using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;


namespace Eco_Net_pro
{

    public partial class Aqua_Guard : UserControl
    {
        [FirestoreData]
        public class AquaClass
        {
            [FirestoreProperty]
            public string ID { get; set; }
            [FirestoreProperty]
            public string Name { get; set; }
            [FirestoreProperty]
            public string Range { get; set; }
            [FirestoreProperty]
            public string About { get; set; }

        }

        FirestoreDb database;
        public Aqua_Guard()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditForms.DelAqua f002edit = new EditForms.DelAqua();
            f002edit.TextBox1.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            f002edit.ShowDialog();
        }

        private void Aqua_Guard_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowEducationData();
        }

        async void ShowEducationData()
        {
            CollectionReference DocRef001 = database.Collection("Aqua");
            QuerySnapshot Snapshot001 = await DocRef001.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot001.Documents)
            {
                if (storeDocument.Exists)
                {
                    AquaClass aquaClass = storeDocument.ConvertTo<AquaClass>();

                    string documentId = storeDocument.Id;
                    string Name = aquaClass.Name;
                    string Range = aquaClass.Range;
                    string About = aquaClass.About;

                    GeoPoint geoPoint = storeDocument.GetValue<GeoPoint>("Location");
                    string geoPointString = $"({geoPoint.Latitude}, {geoPoint.Longitude})";

                    guna2DataGridView1.Rows.Add(documentId, Name, Range, geoPointString, About);

                }
            }
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            EditForms.AddAqua f0a04edit = new EditForms.AddAqua();
            f0a04edit.ShowDialog();
        }
    }
}
