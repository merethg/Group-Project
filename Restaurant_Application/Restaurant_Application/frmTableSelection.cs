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
    public partial class frmTableSelection : Form
    {
        int searchValue;

        public frmTableSelection()
        {
            InitializeComponent();
        }

        public frmTableSelection(int intDiners)
        {
            InitializeComponent();
            lblDiners.Text = intDiners.ToString();
            searchValue = intDiners;

            if (searchValue % 2 == 1)
            {
                searchValue += 1;
            }

            lblSearch.Text = searchValue.ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
