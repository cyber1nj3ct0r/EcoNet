using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eco_Net_pro.Aqua_Guard;

namespace Eco_Net_pro
{
    public partial class Green_Scape : UserControl
    {
        FirestoreDb database;
        public Green_Scape()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditForms.DelGreen f002edit = new EditForms.DelGreen();
            f002edit.TextBox1.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            f002edit.ShowDialog();
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            EditForms.AddGreen f0a04edit = new EditForms.AddGreen();
            f0a04edit.ShowDialog();
        }

        private void Green_Scape_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowEducationData();
        }

        async void ShowEducationData()
        {
            CollectionReference DocRef001 = database.Collection("GreenScape");
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
    }
}
