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
using static Eco_Net_pro.Growing_Crops;

namespace Eco_Net_pro
{
    public partial class Eco_Education : UserControl
    {
        [FirestoreData]
        public class EducationClass
        {
            [FirestoreProperty]
            public string ID { get; set; }
            [FirestoreProperty]
            public string Title { get; set; }
            [FirestoreProperty]
            public string Tags { get; set; }

            [FirestoreProperty]
            public string Description { get; set; }
            [FirestoreProperty]
            public DateTime Date { get; internal set; }


        }


        FirestoreDb database;
        public Eco_Education()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open the dialog only if the cell value is not null or empty
            EditForms.EditEducation f02edit = new EditForms.EditEducation();
            f02edit.TextBox1.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            f02edit.TextBox2.Text = this.guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            f02edit.TextBox3.Text = this.guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            f02edit.TextBox4.Text = this.guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();

            f02edit.ShowDialog();
        }

        private void Eco_Education_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowEducationData();
        }

        async void ShowEducationData()
        {
            CollectionReference DocRef001 = database.Collection("Education");
            QuerySnapshot Snapshot001 = await DocRef001.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot001.Documents)
            {
                if (storeDocument.Exists)
                {
                    EducationClass educationClass = storeDocument.ConvertTo<EducationClass>();

                    string documentId = storeDocument.Id;
                    string Title = educationClass.Title;
                    string Tags = educationClass.Tags;
                    DateTime Date = educationClass.Date;
                    string Description = educationClass.Description;

                    guna2DataGridView1.Rows.Add(documentId, Title, Tags, Date, Description);

                }
            }
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            EditForms.AddEducation f04edit = new EditForms.AddEducation();
            f04edit.ShowDialog();
        }
    }
}
