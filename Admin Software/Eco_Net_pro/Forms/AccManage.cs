using Eco_Net_pro.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;

namespace Eco_Net_pro
{
    public partial class AccManage : UserControl
    {
        [FirestoreData]
        public class AdminClass
        {
            [FirestoreProperty]
            public string ID { get; set; }
             [FirestoreProperty]
            public string Email { get; set; }
            [FirestoreProperty]
            public string Username { get; set; }
            [FirestoreProperty]
            public string Country { get; set; }
            [FirestoreProperty]
            public string Phone { get; internal set; }
            [FirestoreProperty]
            public string Gender { get; set; }
            [FirestoreProperty]
            public string Password { get; set; }
            [FirestoreProperty]
            public string PINCode { get; set; }
        }

        FirestoreDb database;
        public AccManage()
        {
            InitializeComponent();
        }

        private void AccManage_Load(object sender, EventArgs e)
        {
            database = FireStoreHelp.Database;

            ShowEducationData();
        }

        async void ShowEducationData()
        {
            CollectionReference DocRef001 = database.Collection("UserData");
            QuerySnapshot Snapshot001 = await DocRef001.GetSnapshotAsync();

            foreach (DocumentSnapshot storeDocument in Snapshot001.Documents)
            {
                if (storeDocument.Exists)
                {
                    AdminClass adminClass = storeDocument.ConvertTo<AdminClass>();

                    string username = adminClass.Username;
                    string email = adminClass.Email;
                    string gender = adminClass.Gender;
                    string phone = adminClass.Phone;
                    string country = adminClass.Country;
                    string password = Security.Decrypt(adminClass.Password);
                    string PinCode = adminClass.PINCode;

                    guna2DataGridView1.Rows.Add(username, email, gender, phone, country, password, PinCode);

                }
            }
        }
    }
}
