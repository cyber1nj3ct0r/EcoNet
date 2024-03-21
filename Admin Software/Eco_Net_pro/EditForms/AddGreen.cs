using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class AddGreen : Form
    {
        public AddGreen()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string name = TextBox2.Text.Trim();
            string range = TextBox3.Text.Trim();
            string about = TextBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(TextBox4.Text) || string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                MessageBox.Show("Please provide valid latitude and longitude values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double latitude, longitude;

            if (!double.TryParse(TextBox4.Text, out latitude) || !double.TryParse(TextBox5.Text, out longitude))
            {
                MessageBox.Show("Invalid latitude or longitude value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GeoPoint geoPoint = new GeoPoint(latitude, longitude);

            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(range) ||
                string.IsNullOrWhiteSpace(about))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference growPlantCollection = db.Collection("GreenScape");

            try
            {
                DocumentReference newDocumentRef = await growPlantCollection.AddAsync(new
                {
                    Name = name,
                    Range = range,
                    Location = geoPoint,
                    About = about
                });

                MessageBox.Show("New content added to GreenScape collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding content to GreenScape collection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
