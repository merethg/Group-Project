using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySQLClass;

namespace Kitchen_Application
{
    public partial class FrmKitchen : Form
    {

        #region(Variables)
        string activeOrders ;
        string tableNumbers;
        int activeOrderTime = 5;
        int removeTime = 120;
        string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
        MySQLClient sqlClient = new MySQLClient("localhost", "demo", "Conrad", "Conrad2015", 3306);
        #endregion

        public FrmKitchen()
        {
            InitializeComponent();
        }

        private void FrmKitchen_Load(object sender, EventArgs e)
        {
            tmrActiveOrder.Enabled = true;
            tmrRemoveTimer.Enabled = true;
        }

        private void updateActiveOrders()
        {
            try
            {
                //string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.order where Status in ('Recieved','Processing');", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                //MessageBox.Show("Connected");

                while (reader.Read())
                {
                    activeOrders = activeOrders + " " + reader.GetString(0);
                    tableNumbers = tableNumbers + " " + reader.GetString(1);
                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOrders()
        {
            string[] orderNumbers = activeOrders.Split(' ');
            string[] arTableNumbers = {};// = tableNumbers.Split(' ');
            string order = "";
            string[] orders = {};
            int i = -1;

            if (activeOrders.Length >= 1)
            {
                activeOrders = activeOrders.Remove(0, 1);
                tableNumbers = tableNumbers.Remove(0, 1);
                arTableNumbers = tableNumbers.Split(' ');
            }
            

            foreach (string orderID in orderNumbers)
            {
                try
                {
                    //string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.order_item where Order_ID = '" + orderID + "' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        order = order + "/" + reader.GetString(1);
                    }

                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (order.Length >= 1)
                {
                    order = order.Remove(0, 1);


                    orders = order.Split('/');

                    if (lstOrderOne.Items.Count <= 0)
                    {
                        lstOrderOne.Items.Add("Order_ID: " + orderID);
                        lstOrderOne.Items.Add("Table_ID: " + arTableNumbers[i]);
                        lstOrderOne.Items.Add("");
                        lstOrderOne.Items.AddRange(orders);

                        btnCooking1.Enabled = true;
                        btnComplete.Enabled = true;
                    }
                    else
                    {
                        if (lstOrderTwo.Items.Count <= 0)
                        {
                            lstOrderTwo.Items.Add("Order_ID: " + orderID);
                            lstOrderTwo.Items.Add("Table_ID: " + arTableNumbers[i]);
                            lstOrderTwo.Items.Add("");
                            lstOrderTwo.Items.AddRange(orders);

                            btnCooking2.Enabled = true;
                            btnComplete2.Enabled = true;
                        }
                        else
                        {
                            if (lstOrderThree.Items.Count <= 0)
                            {
                                lstOrderThree.Items.Add("Order_ID: " + orderID);
                                lstOrderThree.Items.Add("Table_ID: " + arTableNumbers[i]);
                                lstOrderThree.Items.Add("");
                                lstOrderThree.Items.AddRange(orders);

                                btnCooking3.Enabled = true;
                                btnComplete3.Enabled = true;
                            }
                            else
                            {
                                if (lstOrderFour.Items.Count <= 0)
                                {
                                    lstOrderFour.Items.Add("Order_ID: " + orderID);
                                    lstOrderFour.Items.Add("Table_ID: " + arTableNumbers[i]);
                                    lstOrderFour.Items.Add("");
                                    lstOrderFour.Items.AddRange(orders);

                                    btnCooking4.Enabled = true;
                                    btnComplete4.Enabled = true;
                                }
                                else
                                {
                                    if (lstOrderFive.Items.Count <= 0)
                                    {
                                        lstOrderFive.Items.Add("Order_ID: " + orderID);
                                        lstOrderFive.Items.Add("Table_ID: " + arTableNumbers[i]);
                                        lstOrderFive.Items.Add("");
                                        lstOrderFive.Items.AddRange(orders);

                                        btnCooking5.Enabled = true;
                                        btnComplete5.Enabled = true;
                                    }
                                    else
                                    {
                                        if (lstOrderSix.Items.Count <= 0)
                                        {
                                            lstOrderSix.Items.Add("Order_ID: " + orderID);
                                            lstOrderSix.Items.Add("Table_ID: " + arTableNumbers[i]);
                                            lstOrderSix.Items.Add("");
                                            lstOrderSix.Items.AddRange(orders);

                                            btnCooking6.Enabled = true;
                                            btnComplete6.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                order = "";
                
                if (orders.Length >= 1)
                {
                    Array.Clear(orders, 0, orders.Length);
                }
                
                i++;

            }
        }

        private void tmrActiveOrder_Tick(object sender, EventArgs e)
        {
            activeOrderTime--;

            if (activeOrderTime == 0)
            {
                activeOrders = "";

                lstOrderOne.Items.Clear();
                lstOrderTwo.Items.Clear();
                lstOrderThree.Items.Clear();
                lstOrderFour.Items.Clear();
                lstOrderFive.Items.Clear();
                lstOrderSix.Items.Clear();

                updateActiveOrders();
                activeOrderTime = 30;
                getOrders();

                if (lstOrderOne.Items.Count <= 0)
                {
                    btnCooking1.Enabled = false;
                    btnComplete.Enabled = false;
                }

                if (lstOrderTwo.Items.Count <= 0)
                {
                    btnCooking2.Enabled = false;
                    btnComplete2.Enabled = false;
                }

                if (lstOrderThree.Items.Count <= 0)
                {
                    btnCooking3.Enabled = false;
                    btnComplete3.Enabled = false;
                }

                if (lstOrderFour.Items.Count <= 0)
                {
                    btnCooking4.Enabled = false;
                    btnComplete4.Enabled = false;
                }

                if (lstOrderFive.Items.Count <= 0)
                {
                    btnCooking5.Enabled = false;
                    btnComplete5.Enabled = false;
                }

                if (lstOrderSix.Items.Count <= 0)
                {
                    btnCooking6.Enabled = false;
                    btnComplete6.Enabled = false;
                }
            }
        }
              
        private void updateToProcessing(string orderNum)
        {
            //string orderNumber = lstOrderOne.Items[0].ToString();
            string orderNumber = orderNum;
            string[] orderID = orderNumber.Split(' ');
            orderNumber = orderID[1];

            try
            {
                //string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("update demo.order set Status = 'Processing' where Order_ID = '" + orderNumber + "' ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateToComplete(string orderNum)
        {
            //string orderNumber = lstOrderOne.Items[0].ToString();
            string orderNumber = orderNum;
            string[] orderID = orderNumber.Split(' ');
            orderNumber = orderID[1];

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("update demo.order set Status = 'Complete' where Order_ID = '" + orderNumber + "' ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region(Cooking Buttons)
        private void btnCooking1_Click(object sender, EventArgs e)
        {
            updateToProcessing(lstOrderOne.Items[0].ToString());
        }

        private void btnCooking2_Click(object sender, EventArgs e)
        {
            updateToProcessing(lstOrderTwo.Items[0].ToString());
        }
        
        private void btnCooking3_Click(object sender, EventArgs e)
        {
            updateToProcessing(lstOrderThree.Items[0].ToString());
        }

        private void btnCooking4_Click(object sender, EventArgs e)
        {
            updateToProcessing(lstOrderFour.Items[0].ToString());
        }

        private void btnCooking5_Click(object sender, EventArgs e)
        {
            updateToProcessing(lstOrderFive.Items[0].ToString());
        }

        private void btnCooking6_Click(object sender, EventArgs e)
        {
            updateToProcessing(lstOrderSix.Items[0].ToString());
        }
        #endregion

        #region(Complete Buttons)
        private void btnComplete_Click(object sender, EventArgs e)
        {
            updateToComplete(lstOrderOne.Items[0].ToString());
            lstOrderOne.Items.Clear();

            btnComplete.Enabled = false;
            btnCooking1.Enabled = false;
        }     

        private void btnComplete2_Click(object sender, EventArgs e)
        {
            updateToComplete(lstOrderTwo.Items[0].ToString());
            lstOrderTwo.Items.Clear();
            
            btnComplete2.Enabled = false;
            btnCooking2.Enabled = false;
        }

        private void btnComplete3_Click(object sender, EventArgs e)
        {
            updateToComplete(lstOrderThree.Items[0].ToString());
            lstOrderThree.Items.Clear();

            btnComplete3.Enabled = false;
            btnCooking3.Enabled = false;
        }

        private void btnComplete4_Click(object sender, EventArgs e)
        {
            updateToComplete(lstOrderFour.Items[0].ToString());
            lstOrderFour.Items.Clear();

            btnComplete4.Enabled = false;
            btnCooking4.Enabled = false;
        }

        private void btnComplete5_Click(object sender, EventArgs e)
        {
            updateToComplete(lstOrderFive.Items[0].ToString());
            lstOrderFive.Items.Clear();

            btnComplete5.Enabled = false;
            btnCooking5.Enabled = false;
        }

        private void btnComplete6_Click(object sender, EventArgs e)
        {
            updateToComplete(lstOrderSix.Items[0].ToString());
            lstOrderSix.Items.Clear();

            btnComplete6.Enabled = false;
            btnCooking6.Enabled = false;
        }
        
        #endregion

        private void tmrRemoveTimer_Tick(object sender, EventArgs e)
        {
            removeTime--;

            if (removeTime == 0)
            {
                removeTime = 120;

                sqlClient.Delete("order", "Status = 'Complete'");
                //sqlClient.Update("order", "Status = 'Ready'", "Status = 'Complete'");
            }
        }

      








    }
}
