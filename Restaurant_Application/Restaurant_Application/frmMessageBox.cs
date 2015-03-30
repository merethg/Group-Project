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
    public partial class frmMessageBox : Form
    {
        public string message = "";

        public frmMessageBox()
        {
            InitializeComponent();
        }

        public frmMessageBox(string strText)
        {
            InitializeComponent();
            label1.Text = strText;
        }
    }
}
