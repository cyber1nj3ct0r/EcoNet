using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class AddEducation : Form
    {
        public AddEducation()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string id = TextBox1.Text.Trim();
            string title = TextBox2.Text.Trim();
            string tags = TextBox3.Text.Trim();
            DateTime oDateTime = DateTimePicker.Value.ToUniversalTime();
            string about = TextBox4.Text.Trim();

            if (
                 string.IsNullOrWhiteSpace(TextBox2.Text) ||
                 string.IsNullOrWhiteSpace(TextBox3.Text) ||
                 string.IsNullOrWhiteSpace(TextBox4.Text) ||
                 string.IsNullOrWhiteSpace(DateTimePicker.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference growPlantCollection = db.Collection("Education");

            DocumentReference newDocumentRef = await growPlantCollection.AddAsync(new
            {
                Title = title,
                Tags = tags,
                Date = Timestamp.FromDateTime(oDateTime),
                Description = about
            });

            MessageBox.Show("New content added to Education collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
