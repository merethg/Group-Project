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

namespace protype__groupwork_
{

    public partial class frmMenus : Form
    {
        #region (Variables)

        string strTotal;
        double total = 0.00;
        int tablecheck = 0;
        int intTableNumber = 0;
        int orderNumber;
        DataSet ds = new DataSet();
        Random rnd = new Random();

        #endregion

        #region (Initialisers)
        
        public frmMenus()
        {            
            InitializeComponent();
        }
        
        //Initialises form taking tableNumber brom parent form
        public frmMenus(int tableNumber)
        {
            InitializeComponent();
            intTableNumber = tableNumber;
        }
        
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Total = £0.00";
            lblTableNumber.Text = "Table: " + intTableNumber.ToString();

            //Calls text rap methods and enitialises custom draw methods
            listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem += lst_MeasureItem;
        }

        #region (Buttons)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //exected if listbox contains items
            if (listBox1.Items.Count >= 1)
            {
                //executed if an item is selected
                if (listBox1.SelectedIndex != -1)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    
                    //calculates price to add to total
                    string cost = listBox1.Items[listBox1.SelectedIndex + 2].ToString();
                    cost = cost.Remove(0, 1);
                    double dblCost = Convert.ToDouble(cost);

                    total = total + dblCost;

                    strTotal = String.Format("{0:C}", total);

                    label1.Text = "Total = " + strTotal;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            double holder = 0.00;
            string value;

            foreach (string item in listBox1.Items)
            {
                if (item == listBox2.SelectedItem)
                {
                    //calcuates value to take away from total
                    value = listBox1.Items[listBox1.FindString(item) + 2].ToString();
                    value = value.Remove(0, 1);
                    holder = Convert.ToDouble(value);
                    break;
                }
            }

            listBox2.Items.Remove(listBox2.SelectedItem);
            total = total - holder;

            //Sets total if no items are in listbox
            if ((listBox2.Items.Count) <= 0)
            {
                total = 0.00;
            }
            
            label1.Text = String.Format("Total = {0:C}", total);

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            int randomNumber = rnd.Next(0, 100);
            int itemNum;
            orderNumber = randomNumber;
            MySQLClient sqlClient = new MySQLClient("localhost", "demo", "Conrad", "Conrad2015", 3306);

            sqlClient.Insert("order", "Order_ID, Table_ID, Status", "'" + randomNumber + "','" + intTableNumber.ToString() + "', 'Recieved'");
            
            if (listBox2.Items.Count > 0)
            {
                itemNum = 1;

                foreach (string s in listBox2.Items)
                {
                    sqlClient.Insert("order_item", "Order_ID, Item_Name, Item_Num", "'" + randomNumber + "', '" + s + "', '" + itemNum + "'");
                    itemNum++;
                }
                FrmPayment pay = new FrmPayment(strTotal, this, orderNumber);
                pay.Show();
            }
            else
            {
                MessageBox.Show("No items");
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            label1.Text = "Total = £0.00";
            total = 0.00;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //if the user clicks on the description or price of an order it will 
            //select the order title instead.
            if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 0)
            {

            }
            else if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 1)
            {
                listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 1, true);
            }
            else if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 2)
            {
                listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 2, true);
            }
            else

                if (listBox1.SelectedItem == " ")
                {
                    listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 3, true);
                }
        }

        #endregion

        #region (food Menu catagories)
        
        //sets buttons to equal all available starter types
        private void btnStarter_Click(object sender, EventArgs e)
        {
            tablecheck = 1;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "Bread / Nibbles";
            button11.Visible = true;
            button11.Text = "Starters";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Starters";
        }
        
        //sets buttons to equal all available mains types
        private void btnMain_Click(object sender, EventArgs e)
        {
            tablecheck = 2;
            button8.Visible = true;
            button8.Text = "Pizza";
            button9.Visible = true;
            button9.Text = "Pasta";
            button10.Visible = true;
            button10.Text = "Meat";
            button11.Visible = true;
            button11.Text = "Sides";
            button12.Visible = true;
            button12.Text = "Salads";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Mains";
        }
        
        //sets buttons to equal all available desserts types
        private void btnDessert_Click(object sender, EventArgs e)
        {
            tablecheck = 3;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "Desserts";
            button11.Visible = true;
            button11.Text = "Sundaes";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Desserts";
        }

        //sets buttons to equal all available starter types
        private void btnDrinks_Click(object sender, EventArgs e)
        {
            tablecheck = 4;
            button9.Visible = false;
            button11.Visible = false;
            button8.Visible = true;
            button8.Text = "Hot Drinks";
            button10.Visible = true;
            button10.Text = "Soft Drinks";
            button12.Visible = true;
            button12.Text = "Alcohol";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Drinks";
        }

        #endregion

        #region (food sub catagories)

        //to change server info such as ip or port change the string below.
        //put the ip after datasorce and the port after port.
        //change the username after username and the password to the server password.
        string conection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";

        //Pizza and Hot Drinks
        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 2) //Pizza
            {                
                try
                {
                    //this code recieves a list of items, descriptions and prices from the server.
                    //each line of the server table is put into listBox1 in the following order:
                    // meal name 
                    // description 
                    // price 
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Pizza' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        
                        //Sets price to curency 
                        double price = Convert.ToDouble(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add(" ");
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //calls text wrap methods refreshing listbox once complete
                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Pizza";
            }

            else if (tablecheck == 4) //Hot Drinks 
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Hot Drinks' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add(" ");       
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Drinks: Hot Drinks";
            }
        }

        //Nibbles, Pasta and Desserts
        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 1)    //Bread / Nibbles
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Bread + Nibbles' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");        
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();
                
                lblFoodGroup.Text = "Starters: Bread + Nibbles";
            }
            else if (tablecheck == 2)   //Pasta
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Pasta' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Pasta";
            }
            else if (tablecheck == 3)   //Desserts
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Dessert' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");    
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Desserts";
            }
        }

        //Meat and Soft Drinks
        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 2)    //Meat
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Meat + Fish' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add(" ");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Meat + Fish";
            }
            else if (tablecheck == 4)   //Soft Drinks
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Soft Drinks' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");    
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Drinks: Soft Drinks";
            }
        }

        //Starters, Sides and Sundaes
        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 1)    //Starters
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Starters' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Starters";
            }
            else if (tablecheck == 2) //Sides
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Sides' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();
                
                lblFoodGroup.Text = "Mains: Sides";
            }
            else if (tablecheck == 3) //Sundaes
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Gelato Sundaes' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();
                
                lblFoodGroup.Text = "Dessrts: Gelato Sundaes";
            }
        }

        //Salads and Alcohol
        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 2)    //Salads
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Salad' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Salad";
            }
            else if (tablecheck == 4)   //Alcohol
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Beer + Cider' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));

                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        
                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Drinks: Beer + Cider";
            }
        }

        #endregion
       
        #region (Text Wrap Methods)
        
        //Calculates height of listbox item
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, listBox1.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
        
        #endregion

        public void closeForm()
        {
            this.Close();
        }
    }
}
