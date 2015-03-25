using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Restaurant_Application
{
    public partial class frmTableSelection : Form
    {
        int searchValue;
        int elapseTime = 5;

        public frmTableSelection()
        {
            InitializeComponent();
        }

        public frmTableSelection(string strDiners)
        {
            InitializeComponent();
            lblDiners.Text = strDiners;
            searchValue = Convert.ToInt32(strDiners);

            if (searchValue % 2 == 1)
            {
                searchValue += 1;
            }

            lblSearch.Text = searchValue.ToString();
        }

        frmMessageBox msg = new frmMessageBox();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            msg.Show();
            elapseTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapseTime -= 1;

            if (elapseTime == 0)
            {
                this.Hide();
                frmWelcome wel = new frmWelcome();
                wel.Show();
                msg.Hide();
                elapseTimer.Enabled = false;
            }
        }
    }
}
