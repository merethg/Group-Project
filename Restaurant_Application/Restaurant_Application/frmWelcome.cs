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
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void cmnOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmnOptions.SelectedIndex > -1)
            {
                btnAccept.Enabled = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string numOfDiners = cmnOptions.SelectedItem.ToString();
            string[] diners = numOfDiners.Split(' ');

            frmTableSelection tbs = new frmTableSelection(diners[0]);
            tbs.Show();
            this.Hide();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            btnAccept.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            cmnOptions.SelectedIndex = 1;

            lblWelcome.Left = (this.ClientSize.Width - lblWelcome.Width) / 2;
            lbluserMessage.Left = (this.ClientSize.Width - lbluserMessage.Width) / 2;
            cmnOptions.Left = (this.ClientSize.Width - cmnOptions.Width) / 2;
            btnAccept.Left  = (this.ClientSize.Width - btnAccept.Width) / 2;
        }
    }
}
