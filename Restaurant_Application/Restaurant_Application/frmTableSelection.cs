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
        DataSet ds = new DataSet();

        //default constructor
        public frmTableSelection()
        {
            InitializeComponent();
        }

        //overload constructor
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

        private void frmTableSelection_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                myDataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
