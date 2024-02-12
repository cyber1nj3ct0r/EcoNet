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
    public partial class Tool : UserControl
    {
        

        public Tool()
        {
           

            InitializeComponent();
        }

        private void btnGreen_Step_Tool_Click(object sender, EventArgs e)
        {
            // Show the second user control
            Green_Step secondUserControl = new Green_Step();
            secondUserControl.Dock = DockStyle.Fill;
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.BringToFront();



        }
    }
}
