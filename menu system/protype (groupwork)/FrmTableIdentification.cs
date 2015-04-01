using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace protype__groupwork_
{
    public partial class FrmTableIdentification : Form
    {
        int tableNumber = 1;

        public FrmTableIdentification()
        {
            InitializeComponent();
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            frmMenus menu = new frmMenus(tableNumber);
            menu.Show();
            this.Hide();
        }
    }
}
