using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Profile profile;
        


        public Mainform()
        {
            dash = new Dashboard();
            tool = new Tool();
            task = new Task();
            report = new Report();
            accManage = new AccManage();
            setting = new Setting();
            profile = new Profile();

            InitializeComponent();
        }




        private void Mainform_Load(object sender, EventArgs e)
        {
            tool.Hide();
            task.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();
            profile.Hide();

            dash.Show();
            dash.Dock = DockStyle.Fill;
            this.Controls.Add(dash);
            dash.BringToFront();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            tool.Hide();
            task.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();
            profile.Hide();

            dash.Show();
            dash.Dock = DockStyle.Fill;
            this.Controls.Add(dash);
            dash.BringToFront();
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            dash.Hide();
            task.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();
            profile.Hide();

            tool.Show();
            tool.Dock = DockStyle.Fill;
            this.Controls.Add(tool);
            tool.BringToFront();
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            accManage.Hide();
            setting.Hide();
            profile.Hide();

            task.Show();
            task.Dock = DockStyle.Fill;
            this.Controls.Add(task);
            task.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            task.Hide();
            accManage.Hide();
            setting.Hide();
            profile.Hide();

            report.Show();
            report.Dock = DockStyle.Fill;
            this.Controls.Add(report);
            report.BringToFront();
        }

        private void btnAccoManage_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            task.Hide();
            setting.Hide();
            profile.Hide();

            accManage.Show();
            accManage.Dock = DockStyle.Fill;
            this.Controls.Add(accManage);
            accManage.BringToFront();
        }


        private void btnLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            task.Hide();
            accManage.Hide();
            profile.Hide();

            setting.Show();
            setting.Dock = DockStyle.Fill;
            this.Controls.Add(setting);
            setting.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            dash.Hide();
            tool.Hide();
            report.Hide();
            task.Hide();
            accManage.Hide();
            setting.Hide();

            profile.Show();
            profile.Dock = DockStyle.Fill;
            this.Controls.Add(profile);
            profile.BringToFront();
        }
    }
}
