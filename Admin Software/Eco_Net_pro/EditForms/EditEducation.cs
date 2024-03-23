using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class EditEducation : Form
    {
        public EditEducation()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string title = TextBox2.Text.Trim();
            string tags = TextBox3.Text.Trim();
            DateTime DateTime = DateTimePicker.Value.ToUniversalTime();
            string about = TextBox4.Text.Trim();


            DocumentReference OnlinestoreRef = db.Collection("Education").Document(id);

            DocumentSnapshot snapshot = await OnlinestoreRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> UpdatesItems = new Dictionary<string, object>();

                UpdatesItems["Title"] = title;
                UpdatesItems["Tags"] = tags;
                UpdatesItems["Date"] = DateTime;
                UpdatesItems["Description"] = about;

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

                DocumentReference storeDelRef = db.Collection("Education").Document(id);

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
