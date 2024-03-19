using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eco_Net_pro.btnAddStore;
using static Eco_Net_pro.Eco_Community;
using static Google.Cloud.Firestore.V1.StructuredAggregationQuery.Types.Aggregation.Types;

namespace Eco_Net_pro
{
    public partial class Report : UserControl
    {
        FirestoreDb database;

        public Report()
        {
            InitializeComponent();
        }

        private async void Report_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            GcountDocuments("Aqua", "Aqua_Guard Contents");
            GcountDocuments("Community", "Community Messages");
            GcountDocuments("Education", "Eco_Education Contents");
            GcountDocuments("GreenStep", "GreenStep Actions");
            GcountDocuments("GrowPlant", "GrowPlant Tutorials");
            GcountDocuments("Herbs", "Herbs Tutorials");
            GcountDocuments("OnlineStores", "OnlineStore Stores");
            GcountDocuments("Vegetables", "Vegetables Tutorials");

            ReportcountDocuments("WeeklyCounts");

            Dictionary<string, int> counts = new Dictionary<string, int>();
            counts["Community"] = await CountDocuments("Community");
            counts["Aqua"] = await CountDocuments("Aqua");
            counts["Education"] = await CountDocuments("Education");
            counts["GreenScape"] = await CountDocuments("GreenScape");
            counts["GreenStep"] = await CountDocuments("GreenStep");
            counts["GrowPlant"] = await CountDocuments("GrowPlant");
            counts["Herbs"] = await CountDocuments("Herbs");
            counts["OnlineStores"] = await CountDocuments("OnlineStores");
            counts["Vegetables"] = await CountDocuments("Vegetables");

            SaveCountsToFirestore(counts);

        }

        private async Task<int> CountDocuments(string collectionName)
        {
            CollectionReference docRef = database.Collection(collectionName);
            QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
            return snapshot.Documents.Count;
        }

        private async void SaveCountsToFirestore(Dictionary<string, int> counts)
        {
            CollectionReference weeklyCountsRef = database.Collection("WeeklyCounts");

            int currentWeek = GetWeekOfYear(DateTime.Now);

            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "Week", currentWeek },
                { "Counts", counts }
            };

            await weeklyCountsRef.Document($"Week_{currentWeek}").SetAsync(data);
        }

        private int GetWeekOfYear(DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }


        private async void GcountDocuments(string collectionName, string displayName)
        {
            CollectionReference docRef = database.Collection(collectionName);
            QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
            int count = snapshot.Documents.Count;
            guna2DataGridView1.Rows.Add(displayName, count);
        }

        private async void ReportcountDocuments(string collectionName)
        {
            CollectionReference docRef = database.Collection(collectionName);
            QuerySnapshot snapshot = await docRef.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in snapshot.Documents)
            {
                if (storeDocument.Exists)
                {
                    string documentId = storeDocument.Id;
                    string weekNew = "";

                    int year = 2024;
                    int weekValue = storeDocument.GetValue<int>("Week");

                    (string monthName, int weekOfMonth) = GetMonthAndWeekNumberOfWeek(year, weekValue);

                    if (weekOfMonth == 1)
                    {
                        weekNew = "First";

                    }else if (weekOfMonth == 2)
                    {
                        weekNew = "Second";
                    }else if (weekOfMonth == 3)
                    {
                        weekNew = "Third";
                    }else if (weekOfMonth == 4)
                    { 
                        weekNew = "Forth";
                    }
                    else
                    {
                        weekNew = "Not";
                    }

                    guna2DataGridView2.Rows.Add(documentId, monthName + " " + weekNew + " Week");
 
                }
            }
        }

        public static (string monthName, int weekNumber) GetMonthAndWeekNumberOfWeek(int year, int weekNumber)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(jan1, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var adjustedWeekNumber = weekNumber;
            if (firstWeek <= 1)
            {
                adjustedWeekNumber -= 1;
            }
            DateTime result = firstMonday.AddDays(adjustedWeekNumber * 7);

            string monthName = result.ToString("MMMM");
            int weekOfMonth = (result.Day - 1) / 7 + 1;
            

            return (monthName, weekOfMonth);
        }

    }
}