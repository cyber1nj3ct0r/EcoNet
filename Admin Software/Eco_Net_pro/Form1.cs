using System;
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
            tmr = new Timer();
            tmr.Interval = 4000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            Hide();
            Login mf = new Login();
            mf.ShowDialog();
            Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
