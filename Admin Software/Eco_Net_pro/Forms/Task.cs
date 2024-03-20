using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eco_Net_pro.Eco_Community;

namespace Eco_Net_pro
{
    public partial class Task : UserControl
    {
        [FirestoreData]
        public class TaskClass
        {
            [FirestoreProperty]
            public string ID { get; set; }
            [FirestoreProperty]
            public string Subject { get; set; }
            [FirestoreProperty]
            public string About { get; set; }
            [FirestoreProperty]
            public string Client { get; set; }
            [FirestoreProperty]
            public DateTime Date { get; internal set; }
            [FirestoreProperty]
            public string Owner { get; set; }
            [FirestoreProperty]
            public string Queue { get; set; }
            [FirestoreProperty]
            public string Resources { get; set; }
            [FirestoreProperty]
            public bool Status { get; set; }
        }

        FirestoreDb database;
        public Task()
        {
            InitializeComponent();
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            EditForms.AddTask ftaskedit = new EditForms.AddTask();
            ftaskedit.ShowDialog();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Task_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowTask();
        }

        async void ShowTask()
        {
            CollectionReference DocRef001 = database.Collection("Tasks");
            QuerySnapshot Snapshot001 = await DocRef001.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot001.Documents)
            {
                if (storeDocument.Exists)
                {
                    TaskClass taskClass = storeDocument.ConvertTo<TaskClass>();

                    string documentId = storeDocument.Id;
                    string subject = taskClass.Subject;
                    string about = taskClass.About;
                    string client = taskClass.Client;
                    DateTime Date = taskClass.Date;
                    string owner = taskClass.Owner;
                    string queue = taskClass.Queue;
                    string resources = taskClass.Resources;
                    Boolean status = taskClass.Status;

                    guna2DataGridView1.Rows.Add(documentId, subject, Date, about, resources, queue, client, owner, status);

                }
            }
        }
    }
}
