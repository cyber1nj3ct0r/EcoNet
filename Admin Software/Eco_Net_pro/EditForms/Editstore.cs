using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class Editstore : Form
    {
        public Editstore()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string itemid = TextBox4.Text.Trim();
            string itemname = TextBox5.Text.Trim();
            string itemabout = TextBox6.Text.Trim(); 
            string itemprice = TextBox7.Text.Trim();
            string itemsimg = TextBox8.Text.Trim();
            

            if (!IsValidStoreID(id))
            {
                MessageBox.Show("Invalid Store ID. It should start with 'S' followed by numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidItemID(itemid))
            {
                MessageBox.Show("Invalid Item ID. It should start with 'I' followed by numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPrice(itemprice))
            {
                MessageBox.Show("Invalid Item Price. It should contain a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DocumentReference OnlinestoreRef = db.Collection("OnlineStores").Document(id);

            DocumentSnapshot snapshot = await OnlinestoreRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> UpdatesItems = new Dictionary<string, object>();

                UpdatesItems["Name"] = itemname;
                UpdatesItems["ItemsAbout"] = itemabout;
                UpdatesItems["Price"] = itemprice;
                UpdatesItems["ImageLink"] = itemsimg;

                CollectionReference itemsCollectionRef = OnlinestoreRef.Collection("Items");
                DocumentReference subDocRef = itemsCollectionRef.Document(itemid);

                await subDocRef.SetAsync(UpdatesItems, SetOptions.MergeAll);

                MessageBox.Show("Store item information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }

        private bool IsValidStoreID(string id)
        {
            return id.Length > 0 && id.StartsWith("S") && id.Substring(1).All(char.IsDigit);
        }

        private bool IsValidItemID(string id)
        {
            return id.Length > 0 && id.StartsWith("I") && id.Substring(1).All(char.IsDigit);
        }

        private bool IsValidPrice(string price)
        {
            double value;
            return double.TryParse(price, out value);
        }

        private async void btnItemDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = FireStoreHelp.Database;

                string id = TextBox1.Text.Trim();
                string itemid = TextBox4.Text.Trim();

                DocumentReference storeDelRef = db.Collection("OnlineStores").Document(id);

                CollectionReference storeDelcollectRef = storeDelRef.Collection("Items");
                DocumentReference delItmesRef = storeDelcollectRef.Document(itemid);

                await delItmesRef.DeleteAsync();

                MessageBox.Show("Store item Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                this.Close();
            }
            

        }
    }
}
