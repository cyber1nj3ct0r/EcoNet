using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using Google.Rpc;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string subject = TextBox2.Text.Trim();
            DateTime openingDateTime = DateTimePicker1.Value.ToUniversalTime();
            string about = TextBox3.Text.Trim();
            string resources = TextBox4.Text.Trim();
            string queue = TextBox5.Text.Trim();
            string client = TextBox6.Text.Trim();
            string owner = TextBox7.Text.Trim();
            bool status = false;

            if (string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text) ||
                string.IsNullOrWhiteSpace(TextBox6.Text) ||
                string.IsNullOrWhiteSpace(TextBox7.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference taskCollection = db.Collection("Tasks");

            DocumentReference newDocumentRef = await taskCollection.AddAsync(new
            {
                Subject = subject,
                Date = openingDateTime,
                About = about,
                Resources = resources,
                Queue = queue,
                Client = client,
                Owner = owner,
                Status = status

            });

            MessageBox.Show("New content added to Task collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
