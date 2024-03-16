using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
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
    public partial class AddAqua : Form
    {
        public AddAqua()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string name = TextBox2.Text.Trim();
            string range = TextBox3.Text.Trim();
            double latitude = Convert.ToDouble(TextBox4.Text); // Assuming latitude is entered as a string in a TextBox
            double longitude = Convert.ToDouble(TextBox5.Text); // Assuming longitude is entered as a string in a TextBox
            string about = TextBox6.Text.Trim();
            GeoPoint geoPoint = new GeoPoint(latitude, longitude);

            if (!IsValidStoreID(Name))
            {
                MessageBox.Show("Please fill out the all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference growPlantCollection = db.Collection("Aqua");

            DocumentReference newDocumentRef = await growPlantCollection.AddAsync(new
            {
                Name = name,
                Range = range,
                Location = geoPoint,
                About = about
            });

            MessageBox.Show("New content added to Aqua collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private bool IsValidStoreID(string ids)
        {
            return !string.IsNullOrEmpty(ids);
        }


    }
}
