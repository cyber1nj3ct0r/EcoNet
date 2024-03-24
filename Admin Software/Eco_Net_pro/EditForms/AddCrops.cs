using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class AddCrops : Form
    {
        public AddCrops()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string itemname = TextBox4.Text.Trim();
            string itemabout = TextBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference growPlantCollection = db.Collection("GrowPlant");

            DocumentReference newDocumentRef = await growPlantCollection.AddAsync(new
            {
                Name = itemname,
                About = itemabout
            });

            MessageBox.Show("New item added to GrowPlant collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
