﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Timer tmr;

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Use timer class
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 4000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            Login mf = new Login();
            mf.Show();
            mf.BringToFront();

            //hide this form
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
