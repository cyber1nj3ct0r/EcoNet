using Eco_Net_pro.Classes;
using System;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace Eco_Net_pro
{
    public partial class Growing_Crops : UserControl
    {
        [FirestoreData]
        public class gorwingClass
        {
            [FirestoreProperty]
            public string ID { get; set; }
            [FirestoreProperty]
            public string Name { get; set; }
            [FirestoreProperty]
            public string About { get; set; }

            [FirestoreProperty]
            public string id { get; set; }
            [FirestoreProperty]
            public string Vname { get; set; }
            [FirestoreProperty]
            public string Vlink { get; set; }
            [FirestoreProperty]
            public string Hname { get; set; }
            [FirestoreProperty]
            public string Hlink { get; set; }

        }

        FirestoreDb database;
        public Growing_Crops()
        {
            InitializeComponent();
        }

        private void Growing_Crops_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowGrowPlantData();
            ShowGrowVegetablesData();
            ShowGrowHerbsData();
        }

        async void ShowGrowPlantData()
        {
            CollectionReference DocRef03 = database.Collection("GrowPlant");

            QuerySnapshot Snapshot03 = await DocRef03.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot03.Documents)
            {
                if (storeDocument.Exists)
                {
                    gorwingClass growPlants = storeDocument.ConvertTo<gorwingClass>();

                    string documentId = storeDocument.Id;
                    string growName = growPlants.Name;
                    string growAbout = growPlants.About;

                    btnAddVegetable.Rows.Add(documentId, growName, growAbout);
                }
            }
        }

        async void ShowGrowVegetablesData()
        {

            CollectionReference DocRef04 = database.Collection("Vegetables");
            QuerySnapshot Snapshot04 = await DocRef04.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot04.Documents)
            {
                if (storeDocument.Exists)
                {
                    gorwingClass gorwingclass = storeDocument.ConvertTo<gorwingClass>();

                    string documentId = storeDocument.Id;
                    string vName = gorwingclass.Vname;
                    string vLink = gorwingclass.Vlink;

                    guna2DataGridView2.Rows.Add(documentId, vName, vLink);

                }
            }
        }

        async void ShowGrowHerbsData()
        {

            CollectionReference DocRef04 = database.Collection("Herbs");
            QuerySnapshot Snapshot04 = await DocRef04.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot04.Documents)
            {
                if (storeDocument.Exists)
                {
                    gorwingClass gorwingclass = storeDocument.ConvertTo<gorwingClass>();

                    string documentId = storeDocument.Id;
                    string HName = gorwingclass.Hname;
                    string HLink = gorwingclass.Hlink;

                    guna2DataGridView3.Rows.Add(documentId, HName, HLink);

                }
            }
        }

       

        private void btnAddFeature_Click(object sender, EventArgs e)
        {
            EditForms.AddCrops f2edit = new EditForms.AddCrops();
            f2edit.ShowDialog();
        }

       

        private void btnAddVegetable_Click(object sender, EventArgs e)
        {

            EditForms.AddVege f4edit = new EditForms.AddVege();
            f4edit.ShowDialog();
        }

     

        private void btnAddHerbs_Click(object sender, EventArgs e)
        {
            EditForms.AddHerbs f6edit = new EditForms.AddHerbs();
            f6edit.ShowDialog();
        }

        private void btnAddVegetable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open the dialog only if the cell value is not null or empty
            EditForms.EditCrops f2edit = new EditForms.EditCrops();
            f2edit.TextBox1.Text = this.btnAddVegetable.CurrentRow.Cells[0].Value.ToString();
            f2edit.TextBox4.Text = this.btnAddVegetable.CurrentRow.Cells[1].Value.ToString();
            f2edit.TextBox5.Text = this.btnAddVegetable.CurrentRow.Cells[2].Value.ToString();

            f2edit.ShowDialog();
        }

        private void guna2DataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EditForms.EditVege f3edit = new EditForms.EditVege();
            f3edit.TextBox1.Text = this.guna2DataGridView2.CurrentRow.Cells[0].Value.ToString();
            f3edit.TextBox4.Text = this.guna2DataGridView2.CurrentRow.Cells[1].Value.ToString();
            f3edit.TextBox5.Text = this.guna2DataGridView2.CurrentRow.Cells[2].Value.ToString();

            f3edit.ShowDialog();
        }

        private void guna2DataGridView3_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EditForms.EditHerbs f5edit = new EditForms.EditHerbs();
            f5edit.TextBox1.Text = this.guna2DataGridView3.CurrentRow.Cells[0].Value.ToString();
            f5edit.TextBox4.Text = this.guna2DataGridView3.CurrentRow.Cells[1].Value.ToString();
            f5edit.TextBox5.Text = this.guna2DataGridView3.CurrentRow.Cells[2].Value.ToString();

            f5edit.ShowDialog();
        }
    }
}
