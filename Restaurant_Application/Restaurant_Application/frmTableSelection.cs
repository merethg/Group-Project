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
        string tables = "";

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
            lblTest.Text = tables;
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
                //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                MySqlCommand comand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);  ////########
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    tables = tables + " " + reader.GetString(0);
                }

                //myDataAdapter.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Refresh();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //set initial table availability
            #region
            string[] tableNumbers = tables.Split(' ');

            foreach (string c in tableNumbers)
            {
                if (c == "1")
                {
                    pbTable1.Enabled = true;
                    pbTable1.BackColor = Color.Green;
                }

                if (c == "2")
                {
                    pbTable2.Enabled = true;
                    pbTable2.BackColor = Color.Green;
                }

                if (c == "3")
                {
                    pbTable3.Enabled = true;
                    pbTable3.BackColor = Color.Green;
                }

                if (c == "4")
                {
                    pbTable4.Enabled = true;
                    pbTable4.BackColor = Color.Green;
                }

                if (c == "5")
                {
                    pbTable5.Enabled = true;
                    pbTable5.BackColor = Color.Green;
                }

                if (c == "6")
                {
                    pbTable6.Enabled = true;
                    pbTable6.BackColor = Color.Green;
                }

                if (c == "7")
                {
                    pbTable7.Enabled = true;
                    pbTable7.BackColor = Color.Green;
                }

                if (c == "8")
                {
                    pbTable8.Enabled = true;
                    pbTable8.BackColor = Color.Green;
                }

                if (c == "9")
                {
                    pbTable9.Enabled = true;
                    pbTable9.BackColor = Color.Green;
                }

                if (c == "10")
                {
                    pbTable10.Enabled = true;
                    pbTable10.BackColor = Color.Green;
                }

                if (c == "11")
                {
                    pbTable11.Enabled = true;
                    pbTable11.BackColor = Color.Green;
                }

                if (c == "12")
                {
                    pbTable12.Enabled = true;
                    pbTable12.BackColor = Color.Green;
                }

                if (c == "13")
                {
                    pbTable13.Enabled = true;
                    pbTable13.BackColor = Color.Green;
                }

                if (c == "14")
                {
                    pbTable14.Enabled = true;
                    pbTable14.BackColor = Color.Green;
                }

                if (c == "15")
                {
                    pbTable15.Enabled = true;
                    pbTable15.BackColor = Color.Green;
                }

                if (c == "16")
                {
                    pbTable16.Enabled = true;
                    pbTable16.BackColor = Color.Green;
                }

                if (c == "17")
                {
                    pbTable17.Enabled = true;
                    pbTable17.BackColor = Color.Green;
                }

                if (c == "18")
                {
                    pbTable18.Enabled = true;
                    pbTable18.BackColor = Color.Green;
                }

                if (c == "19")
                {
                    pbTable19.Enabled = true;
                    pbTable19.BackColor = Color.Green;
                }

                if (c == "20")
                {
                    pbTable20.Enabled = true;
                    pbTable20.BackColor = Color.Green;
                }
            #endregion
            }
        }
    }
}
