using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;

namespace Eco_Net_pro
{
    public partial class btnAddStore : UserControl
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
            [FirestoreProperty]
            public string Price { get; set; }
            [FirestoreProperty]
            public string ItemsAbout { get; set; }
        }


        FirestoreDb database;
        

        public btnAddStore()
        {
            InitializeComponent();
        }

        private void Marketplace_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowFirestoreData();
        }

        async void ShowFirestoreData()
        {
            CollectionReference DocRef01 = database.Collection("OnlineStores");

            QuerySnapshot Snapshot01 = await DocRef01.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot01.Documents)
            {
                if (storeDocument.Exists)
                {
                    OnlineStores marketClass = storeDocument.ConvertTo<OnlineStores>();

                    string documentId = storeDocument.Id;
                    string marketName = marketClass.Name;
                    string marketAbout = marketClass.About;
                    DateTime marketStartDate = marketClass.StartDate;

                    guna2DataGridView1.Rows.Add(documentId, marketName, marketAbout, marketStartDate, "", "", "", "");

                    CollectionReference DocRef02 = database.Collection("OnlineStores").Document(documentId).Collection("Items");

                    QuerySnapshot Snapshot02 = await DocRef02.GetSnapshotAsync();

                    foreach (DocumentSnapshot itemDocument in Snapshot02.Documents)
                    {
                        if (itemDocument.Exists)
                        {
                            OnlineStores itemsClass = itemDocument.ConvertTo<OnlineStores>();

                            string itemID = itemDocument.Id;
                            string itemsName = itemsClass.Name;
                            string itemsAbout = itemsClass.ItemsAbout;
                            string itemsPrice = itemsClass.Price;


                            guna2DataGridView1.Rows.Add(documentId, "","", "", itemID, itemsName, itemsAbout, itemsPrice);
                        }
                    }
                }
            }
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open the dialog only if the cell value is not null or empty
            EditForms.Editstore f2edit = new EditForms.Editstore();
            f2edit.TextBox1.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            f2edit.TextBox4.Text = this.guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            f2edit.TextBox5.Text = this.guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            f2edit.TextBox6.Text = this.guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            f2edit.TextBox7.Text = this.guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();

            if (string.IsNullOrEmpty(this.guna2DataGridView1.CurrentRow.Cells[1].Value.ToString()))
            {
                f2edit.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("You can only edit store items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAddStores_Click(object sender, EventArgs e)
        {
            EditForms.Addstore faddstore = new EditForms.Addstore();
            faddstore.ShowDialog();
            
        }
    }
}
