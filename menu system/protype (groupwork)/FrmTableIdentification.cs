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
        #region (Variables)

        int tableNumber = 1;
        
        #endregion

        #region (Initialisers

        public FrmTableIdentification()
        {
            InitializeComponent();
        }
        
        #endregion

        #region (Buttons)
        
        private void btnMenus_Click(object sender, EventArgs e)
        {
            frmMenus menu = new frmMenus(tableNumber);
            menu.Show();
            this.Hide();
        }

        private void btnSetTable_Click(object sender, EventArgs e)
        {
            FrmStaffLogin staff = new FrmStaffLogin(tableNumber);
            staff.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnSetTable.Visible = true;
        }

        #endregion
        
    }
}
