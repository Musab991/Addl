using AADL.People;
using AADL.Regulators;
using AADL.Users;
using AADLBusiness;
using AADLBusiness.Sharia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using AADL.Judgers;
using AADLBusiness.Judger;
using AADL.Judgers.Controls;
using AADL.Experts;
using AADL.Sharia;
namespace AADL
{
    public partial class frmLaunch : Form
    {
        public frmLaunch()
        {
            InitializeComponent();
        }

        private void frmLaunch_Load(object sender, EventArgs e)
        {

        }

        private void btnLawyerInfo_Click(object sender, EventArgs e)
        {
            // Show input dialog to get integer input
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter an RegulatorID:", "Input", "");

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int intValue))
            {
                // Valid integer input
                frmRegulatorInfo frmRegulator = new frmRegulatorInfo(intValue);
                frmRegulator.ShowDialog();
            }
            else
            {
                // Display error if input is empty or not a valid integer
                MessageBox.Show("Please enter a valid integer.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePractitioner frmAddUpdateRegulator = new frmAddUpdatePractitioner();
            frmAddUpdateRegulator.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show input dialog to get integer input
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter an PractitionerID:", "Input", "");

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int intValue))
            {
                // Valid integer input
                frmAddUpdatePractitioner frmAddUpdateprac = new frmAddUpdatePractitioner(intValue);
                frmAddUpdateprac.ShowDialog();
            }
            else
            {
                // Display error if input is empty or not a valid integer
                MessageBox.Show("Please enter a valid integer.");
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmListPeople frmListPeople = new frmListPeople();
            frmListPeople.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmListUsers frmListUsers = new frmListUsers();
            frmListUsers.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmPractitionersList   regulatorsList = new frmPractitionersList();
            regulatorsList.ShowDialog();
        }


        private void button6_Click_1(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter an PractitionerID:", "Input", "");

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int intValue))
            {
                // Valid integer input
                frmJudgerCard frmJudgerCard = new frmJudgerCard(intValue,ctrJudgerCard.enWhichID.JudgerID);
                frmJudgerCard.ShowDialog();
            }
            else
            {
                // Display error if input is empty or not a valid integer
                MessageBox.Show("Please enter a valid integer.");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmJudgersList frmJudgersList = new frmJudgersList();

            frmJudgersList.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmRegulatorList frmRegulatorList = new frmRegulatorList(); 
            frmRegulatorList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmExpertsList frmExpertsList = new frmExpertsList();
            frmExpertsList.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmShariaList form= new frmShariaList();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmRegulatorDraft draft = new frmRegulatorDraft();
            draft.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmShariaDraft draft = new frmShariaDraft();
            draft.ShowDialog();
        }
    }
}
