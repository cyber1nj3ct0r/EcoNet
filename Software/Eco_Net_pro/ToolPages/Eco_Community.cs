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
using static Eco_Net_pro.Eco_Education;

namespace Eco_Net_pro
{
    public partial class Eco_Community : UserControl
    {
        [FirestoreData]
        public class CommunityClass
        {
            [FirestoreProperty]
            public string ID { get; set; }
            [FirestoreProperty]
            public string Title { get; set; }
            [FirestoreProperty]
            public string Description { get; set; }
            [FirestoreProperty]
            public DateTime Date { get; internal set; }
            [FirestoreProperty]
            public string imgurl { get; set; }
            [FirestoreProperty]
            public DateTime Value { get; set; }
        }




        FirestoreDb database;
        public Eco_Community()
        {
            InitializeComponent();

        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            EditForms.AddCommunity f0a4edit = new EditForms.AddCommunity();
            f0a4edit.ShowDialog();
        }

     

        private void Eco_Community_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowEducationData();
        }

        async void ShowEducationData()
        {
            CollectionReference DocRef001 = database.Collection("Community");
            QuerySnapshot Snapshot001 = await DocRef001.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot001.Documents)
            {
                if (storeDocument.Exists)
                {
                    CommunityClass communityClass = storeDocument.ConvertTo<CommunityClass>();

                    string documentId = storeDocument.Id;
                    string Title = communityClass.Title;
                    DateTime Date = communityClass.Date;
                    string Description = communityClass.Description;
                    string imgurl = communityClass.imgurl;

                    guna2DataGridView1.Rows.Add(documentId, Title, Date, Description, imgurl);

                }
            }
        }

        private void guna2DataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EditForms.EditCommunity f002edit = new EditForms.EditCommunity();
            DateTimePicker dt = new DateTimePicker();
            dt.Value = DateTime.Today;

            f002edit.TextBox1.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            f002edit.TextBox2.Text = this.guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            f002edit.dateTimePicker1 = dt; 
            f002edit.TextBox3.Text = this.guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            f002edit.TextBox4.Text = this.guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();

            f002edit.ShowDialog();
        }
    }
}
