﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySQLClass;

namespace Restaurant_Application
{
    public partial class frmTableSelection : Form
    {
        int searchValue;
        int elapseTime = 5;
        string tables = "";
        string customerChoice;

        DataSet ds = new DataSet();
        frmMessageBox msg = new frmMessageBox();

        //default constructor
        public frmTableSelection()
        {
            InitializeComponent();
        }

        //overload constructor
        public frmTableSelection(string strDiners)
        {
            InitializeComponent();
            lblDiners.Text = "Diners " + strDiners;
            searchValue = Convert.ToInt32(strDiners);

            if (searchValue % 2 == 1)
            {
                searchValue += 1;
            }

            lblSearch.Text = "Table for " + searchValue.ToString();
        }

        private void frmTableSelection_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);  ////########
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    tables = tables + " " + reader.GetString(0);
                }

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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MySQLClient sqlClient = new MySQLClient("localhost", "demo", "Conrad", "Conrad2015", 3306);

            sqlClient.Update("table", "Table_Status = 'Un-Available'", "Table_ID = '" + customerChoice + "'");

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

        //table button press controls
        #region
        private void pbTable1_Click(object sender, EventArgs e)
        {
            customerChoice = "1";
            pbTable1.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable2_Click(object sender, EventArgs e)
        {
            customerChoice = "2";
            pbTable2.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable3_Click(object sender, EventArgs e)
        {
            customerChoice = "3";
            pbTable3.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }

            
        }

        private void pbTable4_Click(object sender, EventArgs e)
        {
            customerChoice = "4";
            pbTable4.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }

            
        }

        private void pbTable5_Click(object sender, EventArgs e)
        {
            customerChoice = "5";
            pbTable5.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }

            
        }

        private void pbTable6_Click(object sender, EventArgs e)
        {
            customerChoice = "6";
            pbTable6.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable7_Click(object sender, EventArgs e)
        {
            customerChoice = "7";
            pbTable7.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable8_Click(object sender, EventArgs e)
        {
            customerChoice = "8";
            pbTable8.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable9_Click(object sender, EventArgs e)
        {
            customerChoice = "9";
            pbTable9.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable10_Click(object sender, EventArgs e)
        {
            customerChoice = "10";
            pbTable10.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable11_Click(object sender, EventArgs e)
        {
            customerChoice = "11";
            pbTable11.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable12_Click(object sender, EventArgs e)
        {
            customerChoice = "12";
            pbTable12.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable13_Click(object sender, EventArgs e)
        {
            customerChoice = "13";
            pbTable13.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable14_Click(object sender, EventArgs e)
        {
            customerChoice = "14";
            pbTable14.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable15_Click(object sender, EventArgs e)
        {
            customerChoice = "15";
            pbTable15.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable16_Click(object sender, EventArgs e)
        {
            customerChoice = "16";
            pbTable16.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable17_Click(object sender, EventArgs e)
        {
            customerChoice = "17";
            pbTable17.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable18_Click(object sender, EventArgs e)
        {
            customerChoice = "18";
            pbTable18.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable19_Click(object sender, EventArgs e)
        {
            customerChoice = "19";
            pbTable19.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }

            if (pbTable20.Enabled == true)
            {
                pbTable20.BackColor = Color.Green;
            }
            else
            {
                pbTable20.BackColor = Color.Red;
            }
        }

        private void pbTable20_Click(object sender, EventArgs e)
        {
            customerChoice = "20";
            pbTable20.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Table selected: " + customerChoice;

            if (pbTable2.Enabled == true)
            {
                pbTable2.BackColor = Color.Green;
            }
            else
            {
                pbTable2.BackColor = Color.Red;
            }

            if (pbTable3.Enabled == true)
            {
                pbTable3.BackColor = Color.Green;
            }
            else
            {
                pbTable3.BackColor = Color.Red;
            }

            if (pbTable4.Enabled == true)
            {
                pbTable4.BackColor = Color.Green;
            }
            else
            {
                pbTable4.BackColor = Color.Red;
            }

            if (pbTable5.Enabled == true)
            {
                pbTable5.BackColor = Color.Green;
            }
            else
            {
                pbTable5.BackColor = Color.Red;
            }

            if (pbTable6.Enabled == true)
            {
                pbTable6.BackColor = Color.Green;
            }
            else
            {
                pbTable6.BackColor = Color.Red;
            }

            if (pbTable7.Enabled == true)
            {
                pbTable7.BackColor = Color.Green;
            }
            else
            {
                pbTable7.BackColor = Color.Red;
            }

            if (pbTable8.Enabled == true)
            {
                pbTable8.BackColor = Color.Green;
            }
            else
            {
                pbTable8.BackColor = Color.Red;
            }

            if (pbTable9.Enabled == true)
            {
                pbTable9.BackColor = Color.Green;
            }
            else
            {
                pbTable9.BackColor = Color.Red;
            }

            if (pbTable10.Enabled == true)
            {
                pbTable10.BackColor = Color.Green;
            }
            else
            {
                pbTable10.BackColor = Color.Red;
            }

            if (pbTable11.Enabled == true)
            {
                pbTable11.BackColor = Color.Green;
            }
            else
            {
                pbTable11.BackColor = Color.Red;
            }

            if (pbTable12.Enabled == true)
            {
                pbTable12.BackColor = Color.Green;
            }
            else
            {
                pbTable12.BackColor = Color.Red;
            }

            if (pbTable13.Enabled == true)
            {
                pbTable13.BackColor = Color.Green;
            }
            else
            {
                pbTable13.BackColor = Color.Red;
            }

            if (pbTable14.Enabled == true)
            {
                pbTable14.BackColor = Color.Green;
            }
            else
            {
                pbTable14.BackColor = Color.Red;
            }

            if (pbTable15.Enabled == true)
            {
                pbTable15.BackColor = Color.Green;
            }
            else
            {
                pbTable15.BackColor = Color.Red;
            }

            if (pbTable16.Enabled == true)
            {
                pbTable16.BackColor = Color.Green;
            }
            else
            {
                pbTable16.BackColor = Color.Red;
            }

            if (pbTable17.Enabled == true)
            {
                pbTable17.BackColor = Color.Green;
            }
            else
            {
                pbTable17.BackColor = Color.Red;
            }

            if (pbTable18.Enabled == true)
            {
                pbTable18.BackColor = Color.Green;
            }
            else
            {
                pbTable18.BackColor = Color.Red;
            }

            if (pbTable19.Enabled == true)
            {
                pbTable19.BackColor = Color.Green;
            }
            else
            {
                pbTable19.BackColor = Color.Red;
            }

            if (pbTable1.Enabled == true)
            {
                pbTable1.BackColor = Color.Green;
            }
            else
            {
                pbTable1.BackColor = Color.Red;
            }
        }
        #endregion
    }
}
