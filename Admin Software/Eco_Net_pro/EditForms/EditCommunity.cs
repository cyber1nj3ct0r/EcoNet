using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class EditCommunity : Form
    {
        public EditCommunity()
        {
            InitializeComponent();
        }

        public object dateTimePicker1 { get; internal set; }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string title = TextBox2.Text.Trim();
            DateTime Date = DateTimePicker1.Value.ToUniversalTime();
            string about = TextBox3.Text.Trim();
            string imgurl = TextBox4.Text.Trim();


            DocumentReference OnlinestoreRef = db.Collection("Community").Document(id);

            DocumentSnapshot snapshot = await OnlinestoreRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> UpdatesItems = new Dictionary<string, object>();

                UpdatesItems["Title"] = title;
                UpdatesItems["Date"] = Date;
                UpdatesItems["Description"] = about;
                UpdatesItems["imgurl"] = imgurl;

                await OnlinestoreRef.SetAsync(UpdatesItems, SetOptions.MergeAll);

                MessageBox.Show("Content information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private async void btnItemDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = FireStoreHelp.Database;

                string id = TextBox1.Text.Trim();

                DocumentReference storeDelRef = db.Collection("Community").Document(id);

                await storeDelRef.DeleteAsync();

                MessageBox.Show("Details Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                this.Close();
            }
            

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
