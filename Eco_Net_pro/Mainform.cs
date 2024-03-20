using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Eco_Net_pro
{
    public partial class Mainform : Form
    {
        Dashboard dash;
        Tool tool;
        Task task;
        Report report;
        AccManage accManage;
        Setting setting;
        
        public Mainform()
        {
            dash = new Dashboard();
            tool = new Tool();
            task = new Task();
            report = new Report();
            accManage = new AccManage();
            setting = new Setting();

            InitializeComponent();
        }
        




        private void Mainform_Load(object sender, EventArgs e)
        {
            tool.Hide();
            task.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();

            dash.Show();
            dash.Dock = DockStyle.Fill;
            this.Controls.Add(dash);
            dash.BringToFront();
            PositionInd.Location = new Point(0, 86);
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            tool.Hide();
            task.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();

            dash.Show();
            dash.Dock = DockStyle.Fill;
            this.Controls.Add(dash);
            dash.BringToFront();

            PositionInd.Location = new Point(0, 86);

        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            dash.Hide();
            task.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();

            tool.Show();
            tool.Dock = DockStyle.Fill;
            this.Controls.Add(tool);
            tool.BringToFront();

            PositionInd.Location = new Point(0, 150);
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();

            task.Show();
            task.Dock = DockStyle.Fill;
            this.Controls.Add(task);
            task.BringToFront();

            PositionInd.Location = new Point(0, 215);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            task.Hide();
            accManage.Hide();
            setting.Hide();

            report.Show();
            report.Dock = DockStyle.Fill;
            this.Controls.Add(report);
            report.BringToFront();

            PositionInd.Location = new Point(0, 280);
        }

        private void btnAccoManage_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            task.Hide();
            setting.Hide();

            accManage.Show();
            accManage.Dock = DockStyle.Fill;
            this.Controls.Add(accManage);
            accManage.BringToFront();

            PositionInd.Location = new Point(0, 345);
        }


        private void btnLogo_Click(object sender, EventArgs e)
        {
            PositionInd.Location = new Point(0, 15);

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            task.Hide();
            accManage.Hide();

            setting.Show();
            setting.Dock = DockStyle.Fill;
            this.Controls.Add(setting);
            setting.BringToFront();
        }

        

        private void btnRefreshPictureBox_Click(object sender, EventArgs e)
        {
            string exePath = Application.ExecutablePath;
            Process.Start(exePath);
            Application.Exit();
        }

        private void btnProfilePictureBox_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            task.Hide();
            accManage.Hide();

            setting.Show();
            setting.Dock = DockStyle.Fill;
            this.Controls.Add(setting);
            setting.BringToFront();
        }
    }
}
