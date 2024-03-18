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
    public partial class AddHerbs : Form
    {
        public AddHerbs()
        {
            InitializeComponent();
        }

        private async void btneditStoreDone_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelp.Database;

            string itemname = TextBox4.Text.Trim();
            string itemabout = TextBox5.Text.Trim();

            if (!IsValidStoreID(itemname))
            {
                MessageBox.Show("Please fill out the all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollectionReference growPlantCollection = db.Collection("Herbs");

            DocumentReference newDocumentRef = await growPlantCollection.AddAsync(new
            {
                Hname = itemname,
                Hlink = itemabout
            });

            MessageBox.Show("New item added to Vegetable collection with ID: " + newDocumentRef.Id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private bool IsValidStoreID(string ids)
        {
            return !string.IsNullOrEmpty(ids);
        }


    }
}