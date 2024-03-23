using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Eco_Net_pro
{
    public partial class Report : UserControl
    {
        [FirestoreData]
        public class DailyReport
        {
            [FirestoreProperty]
            public string Aqua { get; set; }
            [FirestoreProperty]
            public string Community { get; set; }
            [FirestoreProperty]
            public string Education { get; set; }
            [FirestoreProperty]
            public string GreenScape { get; set; }
            [FirestoreProperty]
            public string GreenStep { get; set; }
            [FirestoreProperty]
            public string GrowPlant { get; set; }
            [FirestoreProperty]
            public string Herbs { get; set; }
            [FirestoreProperty]
            public string OnlineStores { get; set; }
            [FirestoreProperty]
            public DateTime RecordDate { get; internal set; }
            [FirestoreProperty]
            public string Vegetables { get; set; }
        }


        FirestoreDb database;

        public Report()
        {
            database = FireStoreHelp.Database;
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            GcountDocuments();

            showAllReortViews();
        }

        private async void GcountDocuments()
        {
            CollectionReference docRef1 = database.Collection("Aqua");
            QuerySnapshot snapshot1 = await docRef1.GetSnapshotAsync();
            int count1 = snapshot1.Documents.Count;
            guna2DataGridView1.Rows.Add("Aqua Guard Contents", count1);

            CollectionReference docRef2 = database.Collection("Community");
            QuerySnapshot snapshot2 = await docRef2.GetSnapshotAsync();
            int count2 = snapshot2.Documents.Count;
            guna2DataGridView1.Rows.Add("Community Messages", count2);

            CollectionReference docRef3 = database.Collection("Education");
            QuerySnapshot snapshot3 = await docRef3.GetSnapshotAsync();
            int count3 = snapshot3.Documents.Count;
            guna2DataGridView1.Rows.Add("Eco Education Contents", count3);

            CollectionReference docRefadd = database.Collection("GreenScape");
            QuerySnapshot snapshotadd = await docRefadd.GetSnapshotAsync();
            int countadd = snapshot3.Documents.Count;
            guna2DataGridView1.Rows.Add("Green Scape Contents", countadd);

            CollectionReference docRef4 = database.Collection("GreenStep");
            QuerySnapshot snapshot4 = await docRef4.GetSnapshotAsync();
            int count4 = snapshot4.Documents.Count;
            guna2DataGridView1.Rows.Add("Green Step Actions", count4);

            CollectionReference docRef5 = database.Collection("GrowPlant");
            QuerySnapshot snapshot5 = await docRef5.GetSnapshotAsync();
            int count5 = snapshot5.Documents.Count;
            guna2DataGridView1.Rows.Add("Grow Plant Tutorials", count5);

            CollectionReference docRef6 = database.Collection("Herbs");
            QuerySnapshot snapshot6 = await docRef6.GetSnapshotAsync();
            int count6 = snapshot6.Documents.Count;
            guna2DataGridView1.Rows.Add("Herbs Tutorials", count6);

            CollectionReference docRef7 = database.Collection("OnlineStores");
            QuerySnapshot snapshot7 = await docRef7.GetSnapshotAsync();
            int count7 = snapshot7.Documents.Count;
            guna2DataGridView1.Rows.Add("Online Store Stores", count7);

            CollectionReference docRef8 = database.Collection("Vegetables");
            QuerySnapshot snapshot8 = await docRef8.GetSnapshotAsync();
            int count8 = snapshot8.Documents.Count;
            guna2DataGridView1.Rows.Add("Vegetables Tutorials", count8);
        }

        private async void showAllReortViews()
        {
            CollectionReference DocDailyRef = database.Collection("DailyReport");
            QuerySnapshot SnapshotDaily = await DocDailyRef.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in SnapshotDaily.Documents)
            {
                if (storeDocument.Exists)
                {
                    DailyReport dailyreport = storeDocument.ConvertTo<DailyReport>();

                    string documentId = storeDocument.Id;
                    string greenstep = dailyreport.GreenStep;
                    string onlinestores = dailyreport.OnlineStores;
                    string growplant = dailyreport.GrowPlant;
                    string vegetables = dailyreport.Vegetables;
                    string herbs = dailyreport.Herbs;
                    string education = dailyreport.Education;
                    string community = dailyreport.Community;
                    string aqua = dailyreport.Aqua;
                    string greenscape = dailyreport.GreenScape;
                    DateTime recorddate = dailyreport.RecordDate;

                    guna2DataGridView2.Rows.Add(documentId, greenstep, onlinestores, growplant, vegetables, herbs, education, community, aqua, greenscape, recorddate);

                }
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private async void ReportSaveInDatabase()
        {
            DateTime currentDate = DateTime.Today;

            CollectionReference dayCountCollectionRef = database.Collection("DayCount");
            string nowthisdate = currentDate.ToString("yyyy-MM-dd");

            DocumentReference todayDocumentRef = dayCountCollectionRef.Document(nowthisdate);

            DocumentSnapshot todayDocumentSnapshot = await todayDocumentRef.GetSnapshotAsync();

            if (!todayDocumentSnapshot.Exists)
            {
                string aqua1 = guna2DataGridView1.Rows[0].Cells[1].Value.ToString();
                string community1 = guna2DataGridView1.Rows[1].Cells[1].Value.ToString();
                string education1 = guna2DataGridView1.Rows[2].Cells[1].Value.ToString();
                string greenscape1 = guna2DataGridView1.Rows[3].Cells[1].Value.ToString();
                string greenStep1 = guna2DataGridView1.Rows[4].Cells[1].Value.ToString();
                string growPlant1 = guna2DataGridView1.Rows[5].Cells[1].Value.ToString();
                string herbs1 = guna2DataGridView1.Rows[6].Cells[1].Value.ToString();
                string onlineStores1 = guna2DataGridView1.Rows[7].Cells[1].Value.ToString();
                string vegetables1 = guna2DataGridView1.Rows[8].Cells[1].Value.ToString();

                CollectionReference newCollection = database.Collection("DailyReport");

                DocumentReference newDocumentRef = await newCollection.AddAsync(new
                {
                    Aqua = aqua1,
                    Community = community1,
                    Education = education1,
                    GreenScape = greenscape1,
                    GreenStep = greenStep1,
                    GrowPlant = growPlant1,
                    Herbs = herbs1,
                    OnlineStores = onlineStores1,
                    Vegetables = vegetables1,
                    RecordDate = Google.Cloud.Firestore.Timestamp.GetCurrentTimestamp()
                });

                DocumentReference docRef = database.Collection("DayCount").Document(nowthisdate);
                await docRef.SetAsync(new { });

                MessageBox.Show("New item added to Daily Report collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Already Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ExportToExcel()
        {
            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("ExportedData");

            for (int i = 0; i < guna2DataGridView2.Columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = guna2DataGridView2.Columns[i].HeaderText;
            }

            for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView2.Columns.Count; j++)
                {
                    object cellValue = guna2DataGridView2.Rows[i].Cells[j].Value;

                    if (cellValue != null)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = cellValue.ToString();
                    }
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FileName = "ExportedData.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
            }

        }

        private void btnReportBuildRefrsh_Click(object sender, EventArgs e)
        {
            ReportSaveInDatabase();
        }
    }


}