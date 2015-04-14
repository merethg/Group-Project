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
        string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
        
        #endregion

        #region (Initialisers)
        
        //Constructor setting form item properties
        public FrmTrackOrder()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.bg2;

            lblOrderMessage.Text = "Thank you your order has been placed";
            picOrderActive.BackColor = Color.Red;
            picOrderCooking.BackColor = Color.Red;
            picOrderComplete.BackColor = Color.Red;

            picOrderCooking.Location = new Point(this.Width / 2 - 90, this.Height/2 - picOrderCooking.Height / 2);
            picOrderActive.Location = new Point(picOrderCooking.Left - (picOrderActive.Width + 30), this.Height / 2 - picOrderActive.Height / 2);
            picOrderComplete.Location = new Point(picOrderCooking.Right + 30, this.Height / 2 - picOrderComplete.Height / 2);

            lblOrderMessage.Location = new Point(this.Width / 2 - lblOrderMessage.Width / 2, 150);
        }

        //Constructor setting form item properties
        public FrmTrackOrder(int orderNumber)
        {
            InitializeComponent();
            intOrderNumber = orderNumber;
            this.BackgroundImage = Properties.Resources.bg;

            lblOrderMessage.Text = "Thank you your order has been placed";
            picOrderActive.BackColor = Color.Red;
            picOrderCooking.BackColor = Color.Red;
            picOrderComplete.BackColor = Color.Red;

            picOrderCooking.Location = new Point(this.Width / 2 - picOrderCooking.Width / 2, this.Height / 2 - picOrderCooking.Height / 2);
            picOrderActive.Location = new Point(picOrderCooking.Left - (picOrderActive.Width + 30), this.Height / 2 - picOrderActive.Height / 2);
            picOrderComplete.Location = new Point(picOrderCooking.Right + 30, this.Height / 2 - picOrderComplete.Height / 2);
            
            lblOrderMessage.Location = new Point(this.Width / 2 - lblOrderMessage.Width / 2, 150); 
        }
        
        #endregion

        private void FrmTrackOrder_Load(object sender, EventArgs e)
        {
            trackTimer.Enabled = true;
        }

        #region (Timers)
        
        //Retrieves order status and sets UI form items To represent the status
        private void trackTimer_Tick(object sender, EventArgs e)
        {
            intRefreshTime -= 1;

            if (intRefreshTime == 0)
            {
                intRefreshTime = 10;

                try
                {
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                            lblOrderMessage.ForeColor = Color.Red;
                            lblOrderMessage.Location = new Point(this.Width / 2 - lblOrderMessage.Width / 2, 150);
                        }

                        if (reader.GetString(0) == "Processing")
                        {
                            picOrderActive.BackColor = Color.Green;
                            picOrderCooking.BackColor = Color.Green;
                            picOrderComplete.BackColor = Color.Red;
                            lblOrderMessage.Text = "Your order is now being proesses";
                            lblOrderMessage.ForeColor = Color.Orange;
                            lblOrderMessage.Location = new Point(this.Width / 2 - lblOrderMessage.Width / 2, 150);
                        }

                        if (reader.GetString(0) == "Complete")
                        {
                            picOrderActive.BackColor = Color.Green;
                            picOrderCooking.BackColor = Color.Green;
                            picOrderComplete.BackColor = Color.Green;
                            lblOrderMessage.Text = "Your order is now complete";
                            lblOrderMessage.ForeColor = Color.Green;
                            lblOrderMessage.Location = new Point(this.Width / 2 - lblOrderMessage.Width / 2, 150);

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

        //closes form and opens welcome form
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
