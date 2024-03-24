using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Net_pro
{
    public partial class Setting : UserControl
    {
        private bool isDatabaseConnected = false;
#pragma warning disable CS0169 // The field 'Setting.database' is never used
        FirestoreDb database;
#pragma warning restore CS0169 // The field 'Setting.database' is never used
        public Setting()
        {
            InitializeComponent();
            ConnectToFirestore();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            string loggedInEmail = UserData.LoggedInEmail;

            var db = FireStoreHelp.Database;
            DocumentReference docRef = db.Collection("UserData").Document(loggedInEmail);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            guna2TextBox1.Text = data.Username;
            guna2TextBox2.Text = loggedInEmail;
            guna2TextBox3.Text = data.Gender;
            guna2TextBox4.Text = data.Country;
            guna2TextBox5.Text = data.Phone;
            guna2TextBox6.Text = Security.Decrypt(data.Password);
            guna2TextBox7.Text = data.PINCode;
        }

        private void ConnectToFirestore()
        {
            // Your code to connect to Firestore database
            // This is just a placeholder for demonstration purposes
            try
            {
                var db = FireStoreHelp.Database;
                isDatabaseConnected = true;

                if (isDatabaseConnected)
                {
                    ToggleSwitch1.Checked = true; 
                    ToggleSwitch2.Checked = true;
                }
                else
                {
                    ToggleSwitch1.Checked = false;
                    ToggleSwitch2.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to Firestore database: " + ex.Message);
            }
        }

        private async void btnaddStore_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string Aemail = guna2TextBox2.Text.Trim();
            string phoneno = guna2TextBox5.Text.Trim();
            string password = Security.Encrypt(guna2TextBox6.Text);



            DocumentReference UserDocRef = db.Collection("UserData").Document(Aemail);

            DocumentSnapshot snapshot = await UserDocRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> UpdatesItems = new Dictionary<string, object>();

                UpdatesItems["Phone"] = phoneno;
                UpdatesItems["Password"] = password;

                await UserDocRef.SetAsync(UpdatesItems, SetOptions.MergeAll);

                MessageBox.Show("Content information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            else
            {
                MessageBox.Show("Content information update Error!", "Error");
            }
        }
    }
}
