using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Application
{
    public partial class frmWelcome : Form
    {
        //Constructor setting form item properties
        public frmWelcome()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.bg2;

            lblWelcome.Left = (this.ClientSize.Width - lblWelcome.Width) / 2;
            lbluserMessage.Left = (this.ClientSize.Width - lbluserMessage.Width) / 2;
            cmnOptions.Left = (this.ClientSize.Width - cmnOptions.Width) / 2;
            btnAccept.Left = (this.ClientSize.Width - btnAccept.Width) / 2;

            
            btnAccept.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            cmnOptions.SelectedIndex = 1;
        }

        private void cmnOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enables button if an item is selected
            if (cmnOptions.SelectedIndex > -1)
            {
                btnAccept.Enabled = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //gets number of diners
            string numOfDiners = cmnOptions.SelectedItem.ToString();
            string[] diners = numOfDiners.Split(' ');

            //Form transition passing number of diners
            frmTableSelection tbs = new frmTableSelection(diners[0]);
            tbs.Show();
            this.Hide();
        }      
    }
}
