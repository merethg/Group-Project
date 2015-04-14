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

        //Consturctor that sets form item properties
        public FrmTableIdentification()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.bg2;
            btnMenus.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnMenus.ForeColor = Color.White;
            btnSetTable.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnSetTable.ForeColor = Color.White;
        }
        
        #endregion

        #region (Buttons)
        
        //showns menus
        private void btnMenus_Click(object sender, EventArgs e)
        {
            frmMenus menu = new frmMenus(tableNumber);
            menu.Show();
            this.Hide();
        }

        //shows staff options
        private void btnSetTable_Click(object sender, EventArgs e)
        {
            FrmStaffLogin staff = new FrmStaffLogin(tableNumber);
            staff.Show();
        }

        //shows hidden button
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnSetTable.Visible = true;
        }

        #endregion
        
    }
}
