using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;

namespace Eco_Net_pro.EditForms
{
    public partial class DelGreen : Form
    {
        public DelGreen()
        {
            InitializeComponent();
        }



        private async void btnItemDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = FireStoreHelp.Database;

                string id = TextBox1.Text.Trim();

                DocumentReference storeDelRef = db.Collection("GreenScape").Document(id);

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

        private void btneditStoreDone_Click(object sender, EventArgs e)
        {

        }
    }
}
