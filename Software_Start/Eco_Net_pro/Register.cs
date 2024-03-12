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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void linkBackLogin_MouseClick(object sender, MouseEventArgs e)
        {
            Hide();
            Login form = new Login();
            form.ShowDialog();
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            ResetErrorHighlight();

            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneBox.Text) ||
                string.IsNullOrWhiteSpace(GenderBox.Text) ||
                string.IsNullOrWhiteSpace(CountryBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text) ||
                string.IsNullOrWhiteSpace(CPasswordBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidName(NameBox.Text.Trim()))
            {
                HighlightError(NameBox);
                MessageBox.Show("Please enter a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CorrectError(NameBox);
            }

            if (!IsValidEmail(EmailBox.Text.Trim()))
            {
                HighlightError(EmailBox);
                MessageBox.Show("Please enter a valid Gmail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CorrectError(EmailBox);
            }

            if (!IsValidPhoneNumber(PhoneBox.Text.Trim()))
            {
                HighlightError(PhoneBox);
                MessageBox.Show("Please enter a valid phone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CorrectError(PhoneBox);
            }

            if (!IsValidCountry(CountryBox.Text.Trim()))
            {
                HighlightError(CountryBox);
                MessageBox.Show("Please enter a valid country name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CorrectError(CountryBox);
            }

            if (PasswordBox.Text != CPasswordBox.Text)
            {
                HighlightError(PasswordBox);
                HighlightError(CPasswordBox);
                MessageBox.Show("Passwords do not match. Please re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                CorrectError(PasswordBox);
                CorrectError(CPasswordBox);
            }

            if (!guna2CheckBox1.Checked)
            {
                MessageBox.Show("Please agree to the terms and conditions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var db = FireStoreHelp.Database;

            var data = GetWriteData();
            DocumentReference docRef = db.Collection("UserData").Document(data.Email);
            docRef.SetAsync(data);

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Hide();
            Login form = new Login();
            form.ShowDialog();
            Close();
        }
        private UserData GetWriteData()
        {
            string username = NameBox.Text.Trim();
            string password = Security.Encrypt(PasswordBox.Text);
            string email = EmailBox.Text.Trim();
            string phone = PhoneBox.Text.Trim();
            string gender = GenderBox.Text.Trim();
            string country = CountryBox.Text.Trim();

            return new UserData()
            {
                Username = username,
                Password = password,
                Email = email,
                Phone = phone,
                Gender = gender,
                Country = country

            };
        }

        private void ResetErrorHighlight()
        {
            EmailBox.BorderColor = Color.FromArgb(213, 218, 223);
            PhoneBox.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private bool IsValidName(string name)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z ]+$");
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

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+[0-9]{10,}$");
        }

        private bool IsValidCountry(string country)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(country, @"^[a-zA-Z ]+$");
        }

    }
}
