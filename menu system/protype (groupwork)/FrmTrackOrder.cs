using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace protype__groupwork_
{
    public partial class FrmTrackOrder : Form
    {
        #region (Variables)
       
        int intRefreshTime = 2;
        int intRelapsTime = 5;
        int intOrderNumber;
        
        #endregion

        #region (Initialisers)
        
        public FrmTrackOrder()
        {
            InitializeComponent();
        }

        public FrmTrackOrder(int orderNumber)
        {
            InitializeComponent();
            intOrderNumber = orderNumber;
        }
        
        #endregion

        private void FrmTrackOrder_Load(object sender, EventArgs e)
        {
            trackTimer.Enabled = true;
            lblOrderMessage.Text = "Thank you your order has been placed";
            picOrderActive.BackColor = Color.Red;
            picOrderCooking.BackColor = Color.Red;
            picOrderComplete.BackColor = Color.Red;
        }

        #region (Timers)
        
        private void trackTimer_Tick(object sender, EventArgs e)
        {
            intRefreshTime -= 1;

            if (intRefreshTime == 0)
            {
                intRefreshTime = 10;

                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //MySqlCommand comand = new MySqlCommand("select Status from demo.order where Table_ID = '2' ;", myConn);
                    MySqlCommand comand = new MySqlCommand("select Status from demo.order where Order_ID = '" + intOrderNumber.ToString() + "' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "Recieved")
                        {
                            picOrderActive.BackColor = Color.Green;
                            picOrderCooking.BackColor = Color.Red;
                            picOrderComplete.BackColor = Color.Red;
                            lblOrderMessage.Text = "Your order has now been recieved";
                        }

                        if (reader.GetString(0) == "Processing")
                        {
                            picOrderActive.BackColor = Color.Green;
                            picOrderCooking.BackColor = Color.Green;
                            picOrderComplete.BackColor = Color.Red;
                            lblOrderMessage.Text = "Your order is now being proesses";
                        }

                        if (reader.GetString(0) == "Complete")
                        {
                            picOrderActive.BackColor = Color.Green;
                            picOrderCooking.BackColor = Color.Green;
                            picOrderComplete.BackColor = Color.Green;
                            lblOrderMessage.Text = "Your order is now complete";

                            trackTimer.Enabled = false;
                            tmrRelapseTimer.Enabled = true;

                        }
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tmrRelapseTimer_Tick(object sender, EventArgs e)
        {
            intRelapsTime -= 1;

            if (intRelapsTime == 0)
            {
                tmrRelapseTimer.Enabled = false;
                FrmTableIdentification table = new FrmTableIdentification();
                table.Show();
                this.Close();
            }
        }
        
        #endregion

    }
}
