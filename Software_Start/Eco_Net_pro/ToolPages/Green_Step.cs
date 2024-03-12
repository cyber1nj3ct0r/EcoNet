using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using System.Threading;
using Eco_Net_pro.Classes;

namespace Eco_Net_pro
{
    public partial class Green_Step : UserControl
    {
        FirestoreDb database;
        private int rowIndexCounter = 1;
        public Green_Step()
        {
            InitializeComponent();
        }


        private void Green_Step_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("econet-store");

            GetAllDocuments("AppUser");


        }

        async void GetAllDocuments(string nameofCollection)
        {
            Query query = database.Collection(nameofCollection);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    GreenstepClass greenstepclass = documentSnapshot.ConvertTo<GreenstepClass>();

                    Dictionary<string, object> data = documentSnapshot.ToDictionary();
                    if (data.ContainsKey("Green_Step") && data["Green_Step"] is Dictionary<string, object> greenStepMap)
                    {
                        DateTime? endDate = null;
                        DateTime? startDate = null;
                        object rank = null;

                        if (greenStepMap.ContainsKey("endDate"))
                        {
                            endDate = ((Timestamp)greenStepMap["endDate"]).ToDateTime().ToLocalTime();
                        }
                        if (greenStepMap.ContainsKey("startDate"))
                        {
                            startDate = ((Timestamp)greenStepMap["startDate"]).ToDateTime().ToLocalTime();
                        }
                        if (greenStepMap.ContainsKey("rank"))
                        {
                            rank = greenStepMap["rank"];
                        }

                        guna2DataGridView1.Rows.Add(rowIndexCounter++, documentSnapshot.Id, greenstepclass.Name, endDate, startDate, rank);
                    }
                }
            }
        }
    }
}
