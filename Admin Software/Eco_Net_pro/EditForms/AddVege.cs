﻿using Eco_Net_pro.Classes;
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

namespace Eco_Net_pro.EditForms
{
    public partial class AddVege : Form
    {
        public AddVege()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string itemname = TextBox4.Text.Trim();
            string itemabout = TextBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference growPlantCollection = db.Collection("Vegetables");

            DocumentReference newDocumentRef = await growPlantCollection.AddAsync(new
            {
                Vname = itemname,
                Vlink = itemabout
            });

            MessageBox.Show("New item added to Vegetable collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
