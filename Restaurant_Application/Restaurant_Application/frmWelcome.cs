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
            frmTableSelection tbs = new frmTableSelection(cmnOptions.SelectedItem.ToString());
            tbs.Show();
            this.Hide();
        }

    }
}
