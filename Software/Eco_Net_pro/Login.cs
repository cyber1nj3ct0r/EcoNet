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

namespace Eco_Net_pro
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkRegister_MouseClick(object sender, MouseEventArgs e)
        {
            Hide();
            Register form = new Register();
            form.ShowDialog();
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ResetErrorHighlight();

            if (string.IsNullOrWhiteSpace(EmailBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CorrectError(EmailBox);
                CorrectError(PasswordBox);
            }

            string email = EmailBox.Text.Trim();
            string password = PasswordBox.Text;

            var db = FireStoreHelp.Database;
            DocumentReference docRef = db.Collection("UserData").Document(email);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if (data != null )
            {
                if(password == Security.Decrypt(data.Password))
                {
                    Hide();
                    Mainform form = new Mainform();
                    form.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Passowrd Incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else
            {
                MessageBox.Show("Login Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResetErrorHighlight()
        {
            EmailBox.BorderColor = Color.FromArgb(213, 218, 223);
            PasswordBox.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void HighlightError(Control control)
        {
            control.BackColor = Color.Red;
        }

        private void CorrectError(Control control)
        {
            control.BackColor = Color.LimeGreen;
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-z0-9]+@gmail\.com$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

    }
}
