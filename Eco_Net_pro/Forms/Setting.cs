using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using Google.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Eco_Net_pro
{
    public partial class Setting : UserControl
    {
        private bool isDatabaseConnected = false;
        FirestoreDb database;
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

       


    }
}
