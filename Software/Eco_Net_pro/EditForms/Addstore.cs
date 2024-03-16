using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            string itemid = TextBox4.Text.Trim();
            string itemname = TextBox5.Text.Trim();
            string itemabout = TextBox6.Text.Trim();
            string itemprice = TextBox7.Text.Trim();


            // Validate input data
            if (!IsValidStoreID(id))
            {
                MessageBox.Show("Invalid Store ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidItemID(itemid))
            {
                MessageBox.Show("Invalid Item ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPrice(itemprice))
            {
                MessageBox.Show("Invalid Item Price. It should contain a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Dictionary<string, object> itemData = new Dictionary<string, object>
            {
                { "Name", itemname },
                { "ItemsAbout", itemabout },
                { "Price", itemprice }
            };

            CollectionReference itemsCollectionRef = mainDocRef.Collection("Items");
            DocumentReference subDocRef = itemsCollectionRef.Document(itemid);
            await subDocRef.SetAsync(itemData);

            MessageBox.Show("Save Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
        private void Addstore_Load(object sender, EventArgs e)
        {
        }

        private bool IsValidStoreID(string id)
        {
            return id.Length > 0 && id.StartsWith("S") && id.Substring(1).All(char.IsDigit);
        }

        private bool IsValidItemID(string id)
        {
            return id.Length > 0 && id.StartsWith("I") && id.Substring(1).All(char.IsDigit);
        }

        private bool IsValidPrice(string price)
        {
            double value;
            return double.TryParse(price, out value);
        }
    }
}