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

        private void btnGreenStep_Tool_Click(object sender, EventArgs e)
        {
            // Show the second user control
            Green_Step secondUserControl = new Green_Step();
            Tool tool = new Tool();
            secondUserControl.Dock = DockStyle.Fill;
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(tool);
            secondUserControl.BringToFront();



        }

        private void btnMarketplace_Tool_Click(object sender, EventArgs e)
        {
            // Show the second user control
            btnAddStore MarketplacePage = new btnAddStore();
            Tool tool = new Tool();
            MarketplacePage.Dock = DockStyle.Fill;
            Parent.Controls.Add(MarketplacePage);
            Parent.Controls.Remove(tool);
            MarketplacePage.BringToFront();
        }

        private void btnGrow_Tool_Click(object sender, EventArgs e)
        {
            Growing_Crops Growing_CropsPage = new Growing_Crops();
            Tool tool = new Tool();
            Growing_CropsPage.Dock = DockStyle.Fill;
            Parent.Controls.Add(Growing_CropsPage);
            Parent.Controls.Remove(tool);
            Growing_CropsPage.BringToFront();
        }

        private void btnEducation_Tool_Click(object sender, EventArgs e)
        {
            Eco_Education Eco_EducationPage = new Eco_Education();
            Tool tool = new Tool();
            Eco_EducationPage.Dock = DockStyle.Fill;
            Parent.Controls.Add(Eco_EducationPage);
            Parent.Controls.Remove(tool);
            Eco_EducationPage.BringToFront();
        }

        private void btnEcoQuest_Tool_Click(object sender, EventArgs e)
        {
            Eco_Quest Eco_QuestPage = new Eco_Quest();
            Tool tool = new Tool();
            Eco_QuestPage.Dock = DockStyle.Fill;
            Parent.Controls.Add(Eco_QuestPage);
            Parent.Controls.Remove(tool);
            Eco_QuestPage.BringToFront();
        }

        private void btnAquaGuard_Tool_Click(object sender, EventArgs e)
        {
            Aqua_Guard Aqua_GuardPage = new Aqua_Guard();
            Tool tool = new Tool();
            Aqua_GuardPage.Dock = DockStyle.Fill;
            Parent.Controls.Add(Aqua_GuardPage);
            Parent.Controls.Remove(tool);
            Aqua_GuardPage.BringToFront();
        }

        private void btnGreenScape_Tool_Click(object sender, EventArgs e)
        {
            Green_Scape Green_ScapePage = new Green_Scape();
            Tool tool = new Tool();
            Green_ScapePage.Dock = DockStyle.Fill;
            Parent.Controls.Add(Green_ScapePage);
            Parent.Controls.Remove(tool);
            Green_ScapePage.BringToFront();
        }
    }
}
