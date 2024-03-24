using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;

namespace Eco_Net_pro
{
    public partial class Dashboard : UserControl
    {
#pragma warning disable CS0169 // The field 'Dashboard.timer' is never used
        Timer timer;
#pragma warning restore CS0169 // The field 'Dashboard.timer' is never used
        FirestoreDb database;

        public Dashboard()
        {
            InitializeComponent();
            InitializeFirestore();
            InitializeTimer();
        }

        private void InitializeFirestore()
        {
            string projectId = "econet-store";
            database = FirestoreDb.Create(projectId);
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick; 
            timer.Start();
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Firestore database is not initialized.");
                return;
            }

            CollectionReference collectionRef = database.Collection("Tasks");

            QuerySnapshot snapshot = await collectionRef.GetSnapshotAsync();

            int documentCount = snapshot.Count;

            DateTime startDate = new DateTime(2024, 3, 19);
            DateTime endDate = DateTime.Today;

            TimeSpan difference = endDate - startDate;
            int daysDifference = (int)difference.TotalDays;

            DateTime currentTime = DateTime.Now;

            DateTime midnight = currentTime.Date;

            TimeSpan timeElapsed = currentTime - midnight;
            int hoursElapsed = (int)timeElapsed.TotalHours;

            label6.Text = daysDifference.ToString();
            label4.Text = documentCount.ToString();
            label3.Text = hoursElapsed.ToString() + $" Hr";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
