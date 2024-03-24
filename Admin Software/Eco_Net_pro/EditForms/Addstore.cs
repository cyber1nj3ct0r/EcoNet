using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class Addstore : Form
    {
        public Addstore()
        {
            InitializeComponent();
        }

        private async void btnaddStore_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string name = TextBox2.Text.Trim();
            string about = TextBox3.Text.Trim();
            DateTime openingDateTime = DateTimePicker.Value.ToUniversalTime();


            if (
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(DateTimePicker.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Dictionary<string, object> storeData = new Dictionary<string, object>
            {
                { "Name", name },
                { "About", about },
                { "StartDate", Timestamp.FromDateTime(openingDateTime) }
            };

            DocumentReference mainDocRef = db.Collection("OnlineStores").Document(id);
            await mainDocRef.SetAsync(storeData);

            MessageBox.Show("Save Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
        private void Addstore_Load(object sender, EventArgs e)
        {
        }
    }
}