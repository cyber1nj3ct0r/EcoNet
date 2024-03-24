using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class EditVege : Form
    {
        public EditVege()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string itemname = TextBox4.Text.Trim();
            string itemabout = TextBox5.Text.Trim();


            DocumentReference OnlinestoreRef = db.Collection("Vegetables").Document(id);

            DocumentSnapshot snapshot = await OnlinestoreRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> UpdatesItems = new Dictionary<string, object>();

                UpdatesItems["Vname"] = itemname;
                UpdatesItems["Vlink"] = itemabout;

                await OnlinestoreRef.SetAsync(UpdatesItems, SetOptions.MergeAll);

                MessageBox.Show("Store item information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }

        private async void btnItemDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = FireStoreHelp.Database;

                string id = TextBox1.Text.Trim();

                DocumentReference storeDelRef = db.Collection("Vegetables").Document(id);

                await storeDelRef.DeleteAsync();

                MessageBox.Show("Crop Details Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                this.Close();
            }
            

        }
    }
}
